zxingnetapi
===========

[Web API](http://zxingnetapi.azurewebsites.net/) into [ZXing.NET](http://zxingnet.codeplex.com/) barcode methods.

##Currently Available

###Barcode Image Generation

* `/barcode/qrcode/?` ([demo](http://zxingnetapi.azurewebsites.net/barcode/qrcode/?value=I+did+it&height=500&width=500]))
  * `value=this+value+is+encoded+into+the+barcode`
  * [`width=x`]
  * [`height=y`]
  
* `/barcode/code128/?` ([demo](http://zxingnetapi.azurewebsites.net/barcode/code128/?value=I+did+it))
  * `value=this+value+is+encoded+into+the+barcode`
    * length = 1..81 (else 400 error in JSON).

##Coming Soon

* Other 
* Barcode Reading
