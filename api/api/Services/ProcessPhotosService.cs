using api.Dto;
using api.Enums;

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
            return "Assinc: " + photos.First().FileName;
        }

        private string Conc(List<IFormFile> photos)
        {
            return "Conc: " + photos.First().FileName;
        }
    }
}
