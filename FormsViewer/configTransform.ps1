# rules transformation from previous vesions of the udp log viewer

$config = [xml](gc c:\prgs\moje\Vyvoj\zaloha\FormsViewer.exe.config )
$nodes = $config.configuration.ConditionsConfig | 
    select-xml -XPath '*' | 
    Select-Object -exp Node
$res = $nodes | % { 
    $r = $_.regex -replace "'", "''"
    if ($_.Name -eq 'SwallowByCondition') { 
        $s = "Swallow(r'$r')"
        if ($_.disabled -eq 'true') { $s = '#'+$s }
        $s
    } else {
        $s = ''
        if ($_.disabled -eq 'true') { $s = '#' }
        $s += "Show(r'$r'"
        if ($_.color)     { $s += ", color=Color.$($_.color)"}
        if ($_.backColor) { $s += ", backColor=Color.$($_.backColor)"}
        if ($_.regexOnLogger) { $s += ", regexOnLogger=$(if($_.regexOnLogger -eq 'true'){'True'}else{'False'})"}
        $s += ")"
        $s
    }
}
$res -replace '^',"`t" -join ",`r`n" | clip