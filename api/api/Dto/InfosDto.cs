using api.Enums;

namespace api.Dto
{
    public class InfosDto
    {
        public InfosDto(List<string> possibleMethods, List<string> possibleFilesExtensions)
        {
            this.possibleMethods = possibleMethods;
            this.possibleFilesExtensions = possibleFilesExtensions;
        }

        public List<string> possibleMethods { get; set; }
        public List<string> possibleFilesExtensions { get; set; }
    }
}
