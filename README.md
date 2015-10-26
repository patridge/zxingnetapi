zxingnetapi
===========

[Web API](https://zxingnetapi.apphb.com/barcode/qrcode/?value=hello%20world&width=250&height=250) into [ZXing.NET](http://zxingnet.codeplex.com/) barcode methods.

##Currently Available

###Barcode Image Generation

* `/barcode/qrcode/?` ([demo](https://zxingnetapi.apphb.com/barcode/qrcode/?value=I+did+it&height=500))
  * `value=this+value+is+encoded+into+the+barcode`
  * [`width=x`]
  * [`height=y`]
  
* `/barcode/code128/?` ([demo](https://zxingnetapi.apphb.com/barcode/code128/?value=I+did+it))
  * `value=this+value+is+encoded+into+the+barcode`
    * length = 1..81 (else 400 error in JSON).
  * [`height=y`] (17..~65,000, else error)

##Newly Added

* [QR] Allow specifying only one dimension (since result was min of width/height anyway).
* [Code128] Allow height parameter.

##Coming Soon

* Other 
* Barcode Reading

##License

MIT license. If you do something cool with it, though, I'd love to hear about it.
