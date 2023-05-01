using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("infos")]
    public class InfosController
    {
        private readonly ILogger<ProcessPhotosController> _logger;
        private readonly InfosService _infosService;

        public InfosController(ILogger<ProcessPhotosController> logger, InfosService infosService)
        {
            _logger = logger;
            _infosService = infosService;
        }

        [HttpGet]
        public InfosDto GetInfos()
        {
            return _infosService.GetInfos();
        }
    }
}