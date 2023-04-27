using api.Dto;
using api.Enums;
using System.Drawing;
using System.Drawing.Imaging;

namespace api.Services
{
    public class ProcessPhotosService
    {

        public Task ProcessPhotos(ProcessPostDto dto)
        {

            ProcessType type = dto.Method;
            
            //if (type == ProcessType.Paralel) return Paralel(dto.Photos);
            //if (type == ProcessType.Conc) return Conc(dto.Photos);
            
            /*
             * default return is Assinc
             */
            return Assinc(dto.Photos);
        }

        private static async Task Assinc(List<IFormFile> photos)
        {
            string dirPath = "../Assinc_Photos/";
            
            List<Task> tasks = new();

            foreach (IFormFile photo in photos)
            {
                Task task = Task.Run(() =>
                {
                    HandlePhotos(photo, dirPath);
                });
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        //private static Task Paralel(List<IFormFile> photos)
        //{
        //    return "Paralel: " + photos.First().FileName;
        //}

        //private static Task Conc(List<IFormFile> photos)
        //{
        //    return "Conc: " + photos.First().FileName;
        //}

        #region HELPERS

        private static void HandlePhotos(IFormFile photo, string dirPath)
        {

            VerifyDirectory(dirPath);

            try
            {
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
                                thumbnail.Save(fileStream, ImageFormat.Png);
                            }
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
