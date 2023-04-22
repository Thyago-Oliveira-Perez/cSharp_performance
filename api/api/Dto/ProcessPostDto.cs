using api.Enums;

namespace api.Dto
{
    public class ProcessPostDto
    {
        public ProcessType Method { get; set; }
        public List<IFormFile>? Photos { get; set; }
    }
}
