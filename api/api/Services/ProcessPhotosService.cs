using api.Dto;
using api.Enums;
using System.Drawing;
using System.Drawing.Imaging;

namespace api.Services
{
    public class ProcessPhotosService
    {

        public string ProcessPhotos(ProcessPostDto dto)
        {

            ProcessType type = dto.Method;

            if (type == ProcessType.Assinc)
            {
                string message = "Processing with Assinc method.";
                Assinc(dto.Photos);
                return message;
            }
            if (type == ProcessType.Paralel) return this.Paralel(dto.Photos);
            if (type == ProcessType.Conc) return this.Conc(dto.Photos);

            return "Method doesn't exist";
        }

        private string Paralel(List<IFormFile> photos)
        {
            return "Paralel: " + photos.First().FileName;
        }

        private static async void Assinc(List<IFormFile> photos)
        {
            string dirPath = "../Assinc_Photos/";
            
            List<Task> tasks = new List<Task>();

            foreach (IFormFile photo in photos)
            {
                Task task = Task.Run(async () =>
                {
                    HandlePhotos(photo, dirPath);
                });
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private string Conc(List<IFormFile> photos)
        {
            return "Conc: " + photos.First().FileName;
        }

        #region HELPERS

        private static void HandlePhotos(IFormFile photo, string dirPath)
        {

            VerifyDirectory(dirPath);

            using (var stream = photo.OpenReadStream()) 
            {
                using (var memoryStream = new MemoryStream()) 
                {
                    stream.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (var img = Image.FromStream(memoryStream))
                    {
                        var height = (300 * img.Height) / img.Width;
                        var thumbnail = img.GetThumbnailImage(300, height, null, IntPtr.Zero);

                        string savePath = Path.Combine(dirPath, photo.FileName);

                        using (var fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            thumbnail.Save(fileStream, ImageFormat.Jpeg);
                        }
                    }
                }
            }
        }

        private static void VerifyDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion
    }
}
