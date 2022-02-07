using Microsoft.AspNetCore.Mvc;

namespace MVCAndRazorSamples.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public IActionResult UploadPictureSample()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> UploadPictureSample(IFormFile datei)
        {
            if (datei == null)
                ModelState.AddModelError("datei", "Bitte eine Datei auswählen");


            if (ModelState.IsValid)
            {
                FileInfo fileInfo = new FileInfo(datei.FileName);

                //absoluten Pfad der Uploaddatei
                string savePath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

                using (FileStream stream = new FileStream(savePath, FileMode.Create))
                {
                    await datei.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(UploadPictureSample));
            }

            return View();
        }


        [HttpGet]
        public IActionResult PictureGallery()
        {
            string imageDiretoryPath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";

            string[] pictures = Directory.GetFiles(imageDiretoryPath);

            return View(pictures);
        }


        [HttpGet]
        public IActionResult FormattedPictureGallery()
        {
            string imageDiretoryPath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";

            string[] pictures = Directory.GetFiles(imageDiretoryPath);

            return View(pictures);
        }
    }
}
