using api.Dto;
using api.Enums;
using System.Diagnostics;

namespace api.Services
{
    public class InfosService
    {
        public InfosDto GetInfos()
        {
            string[] processTypes = new string[]
            {
                Enum.GetName(ProcessType.Assinc),
                Enum.GetName(ProcessType.Paralel),
                Enum.GetName(ProcessType.Conc),
            };

            string[] filesExtensions = new string[]
            {
                ".PNG"
            };

            return new InfosDto(processTypes.ToList(), filesExtensions.ToList());
        }

    }
}
