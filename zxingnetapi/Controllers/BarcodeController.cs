﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ZXing;

namespace zxingnetapi.Controllers {
    public class BarcodeController : ApiController {
        [Route("Barcode/Code128"), HttpGet]
        public HttpResponseMessage GetCode128(string value) {
            if (value == null || value.Length == 1 || value.Length > 80) {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Error = "Value must be between 1 and 80 characters." })),
                };
                return errorResponse;
            }

            HttpResponseMessage response = new HttpResponseMessage();
            IBarcodeWriter writer = new BarcodeWriter() {
                Format = BarcodeFormat.CODE_128,
            };

            Bitmap barcodeBitmap = writer.Write(value);
            using (MemoryStream pngStream = new MemoryStream()) {
                barcodeBitmap.Save(pngStream, ImageFormat.Png);
                response.Content = new ByteArrayContent(pngStream.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
        }
        [Route("Barcode/QrCode")]
        public HttpResponseMessage GetQrCode(string value, int? width = null, int? height = null) {
            HttpResponseMessage response = new HttpResponseMessage();
            ZXing.Common.EncodingOptions encodingOptions = new ZXing.Common.EncodingOptions();
            int? widthHint = width ?? height;
            int? heightHint = height ?? width;
            if (widthHint.HasValue) {
                encodingOptions.Hints.Add(ZXing.EncodeHintType.WIDTH, widthHint.Value);
            }
            if (heightHint.HasValue) {
                encodingOptions.Hints.Add(ZXing.EncodeHintType.HEIGHT, heightHint.Value);
            }
            IBarcodeWriter writer = new BarcodeWriter() {
                Format = BarcodeFormat.QR_CODE,
                Options = encodingOptions,
            };

            Bitmap barcodeBitmap = writer.Write(value);
            using (MemoryStream pngStream = new MemoryStream()) {
                barcodeBitmap.Save(pngStream, ImageFormat.Png);
                response.Content = new ByteArrayContent(pngStream.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
        }
    }
}
