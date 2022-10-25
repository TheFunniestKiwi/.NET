using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ML;

namespace Lab_04.Pages
{
    public class SingleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Image { get; set; }
        private string imagesDir;
        private readonly Inception5h _pred;
        public string Label { get; set; }
        public float Probability { get; set; }

        public SingleModel(IWebHostEnvironment environment, ML.Inception5h pred)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
            _pred = pred;
        }

        public IActionResult OnGet()
        {
            if (System.IO.File.Exists(Path.Combine(imagesDir, Image)))
            {
                (Label, Probability) = _pred.Label(Path.Combine(imagesDir, Image));
                return Page();
            }

            return NotFound();
        }
    }
}
