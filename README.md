zxingnetapi
===========

[Web API](zxingnetapi.apphb.com) into ZXing.NET barcode methods.

##Currently Available

###Barcode Image Generation

* `/barcode/qrcode/?`
  * `value=this+value+is+encoded+into+the+barcode`
  * [`width=x`]
  * [`height=y`]
  
* `/barcode/code128/?`
  * `value=this+value+is+encoded+into+the+barcode`
    * length = 1..81 (else 400 error in JSON).

##Coming Soon

* Other 
* Barcode Reading