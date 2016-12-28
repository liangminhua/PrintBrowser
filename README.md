# PrintBrowser

PrintBrowser is a client for printing content in front-end without extra popups.
Using [Xaml](https://msdn.microsoft.com/library/cc295302.aspx) as the print template language makes it easier to print complex content than using the ESC / TSC command.

## Feature ##

* [Internal.getPrinters](#getprinters)

* [Internal.print](#print)

### getPrinters ###

Get all printers include virtual printer.

```javascript
var printers = Internal.getPrinters(); //It is an array containing the name of the printer.
```
### print ###
Print Xaml template to printer.

* printerName = string -Should be vaild printer name.
* template = string - Just use the [FlowDocument](https://msdn.microsoft.com/library/system.windows.documents.paragraph.aspx) 
and its child content. All content will *wrap*.

```javascript
var printerName =""; //use Internal.getPrinters method get printers' name.
var template = ' \
<FlowDocument PagePadding="0" \
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"> \
    <Paragraph TextAlignment="Center">Print Test</Paragraph> \
</FlowDocument>';
Internal.print(printerName,template);
// If you want to get the error
try{
    Internal.print(printerName,template);
}catch(e)
{
    console.log(e);
}
```

## More information ##

[中文ReadMe](chinese.md)
