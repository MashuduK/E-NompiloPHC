namespace E_NompiloPHC.Models
{
    public class ImageOperations
    {

        IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ImageUpload(IFormFile file)
        {
            string filename = null;
            if (filename != null)
            {
                string fileDirectory = Path.Combine(_env.WebRootPath, "Images");
                filename = Guid.NewGuid() + "-" + file.FileName;
                string filepath = Path.Combine(fileDirectory, filename);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }

            }
            return filename;
        }

    }
}
