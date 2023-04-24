using api.Dto;
using api.Enums;
using ImageProcessor;
using ImageProcessor.Imaging;
using System.Drawing;
using System.IO;

namespace api.Services
{
    public class ProcessPhotosService
    {

        public string ProcessPhotos(ProcessPostDto dto)
        {

            ProcessType type = dto.Method;

            if (type == ProcessType.Assinc) return this.Paralel(dto.Photos);
            if (type == ProcessType.Paralel) return this.Assinc(dto.Photos);
            if (type == ProcessType.Conc) return this.Conc(dto.Photos);

            return "Method doesn't exist";
        }

        private string Paralel(List<IFormFile> photos)
        {
            return "Paralel: " + photos.First().FileName;
        }

        private string Assinc(List<IFormFile> photos)
        {
            string dirPath = "../AssincPhotos/";
            string message = "Processing with Assinc method.";

            foreach (IFormFile photo in photos)
            {
                Task.Run(async () =>
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }

                        await photo.CopyToAsync(memoryStream);

                        string savePath = Path.Combine(dirPath, photo.FileName);

                        using (var fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            await memoryStream.CopyToAsync(fileStream);
                        }
                    }
                });
            }

            return message;
        }

        private string Conc(List<IFormFile> photos)
        {
            return "Conc: " + photos.First().FileName;
        }
    }
}
