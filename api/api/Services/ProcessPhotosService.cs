using api.Dto;

namespace api.Services
{
    public class ProcessPhotosService
    {

        public string ProcessPhotos(ProcessPostDto dto)
        {
            return "Method: " + dto.Method.ToString() + "\nPhotos: " + dto.Photos.First().FileName;
        }

    }
}
