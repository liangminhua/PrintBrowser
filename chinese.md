# PrintBrowser # 

PrintBrowser是一个网页打印的客户端。
[Xaml](https://msdn.microsoft.com/library/cc295302.aspx)作为打印模板语言，
比使用ESC/TSC命令更容易打印出复杂的内容。

## 功能 ##

*[Internal.getPrinters](#getprinters)

*[Internal.print](#print)

### getPrinters ###

获取所有打印机名字，包括虚拟打印机。

```javascript
var printers = Internal.getPrinters(); //It is an array containing the name of the printer.
```
### print ###
把Xaml模板打印到打印机

* printerName = string -有效的打印机名字.
* template = string - 
只可以使用[FlowDocument](https://msdn.microsoft.com/library/system.windows.documents.paragraph.aspx) 和它的子元素。
所有内容都会**自动换行**。

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
## 相关内容

[ReadMe](README.md)