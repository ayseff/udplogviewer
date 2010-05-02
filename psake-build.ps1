# based on my fork - http://github.com/stej/psake

$framework = '4.0' 
$nunitPath = (join-path $psflashbak data\src\.net\lib\nunit\nunit-console.exe)

properties {
  $dir     = (join-path $psflashbak data\src\.net\UdpLogViewer)
  $slnPath = (join-path $dir UdpLogViewer.Express2010.sln)
  $verbose = $false
  $configuration = 'Release' #Release/Debug
}

Add-Module Nunit -verbose

& {
  $script:context.Peek().properties | % { . $_ }
  write-host Base directory: $dir -fore Green
  write-host Solution path: $slnPath -fore Green
  write-host Verbose: $verbose -fore Green
  write-host Configuration `(Debug/Release`): $configuration -fore Green
}

FormatTaskName { write-host ("-"*25) "[$args]" ("-"*25) -foreground Blue -back White }

task default     -depends Full
# high level tasks
task Full        -depends Rebuild, RunTests, CleanBin, CopyToBin
task RebuildOnly -depends Rebuild
task Publish     -depends CopyToBin

# low level tasks
task Rebuild -depends Clean,Build

task Build { 
  exec { msbuild $slnPath '/t:Build' /ds /v:$(if($verbose){'n'}else{'m'}) /p:Configuration=$configuration }
}

task Clean { 
  exec { msbuild $slnPath '/t:Clean' /ds /v:$(if($verbose){'n'}else{'m'}) /p:Configuration=$configuration }
}

task RunTests {
  #exec { & (join-path $dir FormsViewer\Test\bin\$configuration\Test.exe) }
  #exec { & $nunitPath (join-path $psflashBak data\src\.net\UdpLogViewer\FormsViewer\Test\bin\$configuration\FormsViewer.Test.dll) }
  
  $testAssembly = (join-path $psflashBak data\src\.net\UdpLogViewer\FormsViewer\Test\bin\$configuration\FormsViewer.Test.dll)
  "Running tests for $testAssembly" | Write-ScriptInfo
  nunit -assembly $testAssembly -silent
}

task CleanBin `
	-precondition { test-path "$dir\bin\" } `
	-action       { gci "$dir\bin\" | Remove-Item -Force -ea Stop }

task CopyToBin {
 Get-ChildItem "$dir\FormsViewer\bin\$configuration\*" -include *.dll,*.exe,*.config | 
 	Write-ScriptInfo "Copying {0} to bin" -pass |
	Copy-Item -Dest "$dir\bin\"
 Get-ChildItem "$dir\FormsViewer\*" -include config.py,definitions.py,rules.py,uiconfig.py | 
 	Write-ScriptInfo "Copying {0} to bin" -pass |
	Copy-Item -Dest "$dir\bin"
}