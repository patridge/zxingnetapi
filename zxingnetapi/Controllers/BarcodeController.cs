using System;
using System.Drawing;
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
        public HttpResponseMessage GetCode128(string value, int? height = null) {
            if (value == null || value.Length == 1 || value.Length > 80) {
                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Error = "Value must be between 1 and 80 characters." })),
                };
                return errorResponse;
            }

            var response = new HttpResponseMessage();
            var writer = new BarcodeWriter() {
                Format = BarcodeFormat.CODE_128,
            };
            if (height.HasValue) {
                writer.Options.Hints[ZXing.EncodeHintType.HEIGHT] = height.Value;
            }

            Bitmap barcodeBitmap = writer.Write(value);
            using (var pngStream = new MemoryStream()) {
                barcodeBitmap.Save(pngStream, ImageFormat.Png);
                response.Content = new ByteArrayContent(pngStream.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
        }
        [Route("Barcode/QrCode")]
        public HttpResponseMessage GetQrCode(string value, int? width = null, int? height = null) {
            var response = new HttpResponseMessage();
            var writer = new BarcodeWriter() {
                Format = BarcodeFormat.QR_CODE,
            };
            int? widthHint = width ?? height;
            int? heightHint = height ?? width;
            if (widthHint.HasValue) {
                writer.Options.Hints[ZXing.EncodeHintType.WIDTH] = widthHint.Value;
            }
            if (heightHint.HasValue) {
                writer.Options.Hints[ZXing.EncodeHintType.HEIGHT] = heightHint.Value;
            }

            Bitmap barcodeBitmap = writer.Write(value);
            using (var pngStream = new MemoryStream()) {
                barcodeBitmap.Save(pngStream, ImageFormat.Png);
                response.Content = new ByteArrayContent(pngStream.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return response;
            }
        }
    }
}
