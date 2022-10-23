using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_04.Pages
{
    public class UploadModel : PageModel
    {
        private string imagesDir;
        [BindProperty]
        public IFormFile Upload { get; set; }

        public UploadModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                string extension = ".jpg";
                switch (Upload.ContentType)
                {
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                }
                var fileName =
                Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) +
                extension;
                using (var fs = System.IO.File.OpenWrite(Path.Combine(imagesDir, fileName)))
                {
                    Upload.CopyTo(fs);
                }
            }
            return RedirectToPage("Index");
        }
    }
}
