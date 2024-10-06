using Microsoft.AspNetCore.Mvc;

namespace DENEME.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                ViewBag.Error = "Пожалуйста, введите действительный текст.";
                return View("Index");
            }

            byte[] qrCodeImage = QRCodeHelper.GenerateQRCode(text);
            string base64Image = Convert.ToBase64String(qrCodeImage);

            ViewBag.QRCodeImage = $"data:image/png;base64,{base64Image}";
            return View("Index");
        }
    }
}
