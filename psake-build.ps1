# based on my fork - http://github.com/stej/psake

$framework = '4.0' 
$nunitPath = (join-path $psflashbak data\src\.net\lib\nunit\nunit-console.exe)

properties {
  $root     = (join-path $codeplexSrcBak UdpLogViewer)
  $slnPath = (join-path $root UdpLogViewer.Express2010.sln)
  $verbose = $false
  $configuration = 'Release' #Release/Debug
}

& {
  $script:context.Peek().properties | % { . $_ }
  write-host Base directory: $root -fore Green
  write-host Solution path: $slnPath -fore Green
  write-host Verbose: $verbose -fore Green
  write-host Configuration `(Debug/Release`): $configuration -fore Green
}

#FormatTaskName { write-host ("-"*25) "[$args]" ("-"*25) -foreground Blue -back White }

task default     -depends Full
# high level tasks
task Full        -depends Rebuild, RunTests, CleanBin, CopyToBin
task RebuildOnly -depends Rebuild
task Publish     -depends CleanBin, CopyToBin

# low level tasks
task Rebuild -depends Clean,Build

task ImportNunit {
  ipmo (join-path $psflashbak data\src\PowerShell\dev\psake-contrib\nunit.psm1) -argumentList $nunitPath
}

task Build { 
  exec { msbuild $slnPath '/t:Build' /ds /v:$(if($verbose){'n'}else{'m'}) /p:Configuration=$configuration }
}

task Clean { 
  exec { msbuild $slnPath '/t:Clean' /ds /v:$(if($verbose){'n'}else{'m'}) /p:Configuration=$configuration }
}

task RunTests -depend ImportNunit {
  #exec { & (join-path $root FormsViewer\Test\bin\$configuration\Test.exe) }
  #exec { & $nunitPath (join-path $psflashBak data\src\.net\UdpLogViewer\FormsViewer\Test\bin\$configuration\FormsViewer.Test.dll) }
  
  $testAssembly = (join-path $root FormsViewer\Test\bin\$configuration\FormsViewer.Test.dll)
  write-host "Running tests for $testAssembly" -fore Green
  nunit -assembly $testAssembly -silent
}

task CleanBin `
	-precondition { test-path "$root\bin\" } `
	-action       { gci "$root\bin\" | Remove-Item -Force -ea Stop }

task CopyToBin {
 Get-ChildItem "$root\FormsViewer\bin\$configuration\*" -include *.dll,*.exe,*.config | 
  ? { $_.Name -notmatch 'vshost' } |
 	% { write-host "Copying $_ to bin"; $_ } |
	Copy-Item -Dest "$root\bin\"
 Get-ChildItem "$root\FormsViewer\*" -include config.py,definitions.py,example.rules.py,uiconfig.py,xrules.addGrowl.py | 
 	% { write-host "Copying $_ to bin"; $_ } |
	Copy-Item -Dest "$root\bin"
 Get-ChildItem "$root\TestUdpEmitor\bin\$configuration\*" -include *.dll,*.exe,*.config | 
 	% { write-host "Copying $_ to bin"; $_ } |
	Copy-Item -Dest "$root\bin"
}