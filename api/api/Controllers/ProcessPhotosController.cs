using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessPhotosController
    {
        private readonly ILogger<ProcessPhotosController> _logger;
        private readonly ProcessPhotosService _processPhotosService;

        public ProcessPhotosController(ILogger<ProcessPhotosController> logger, ProcessPhotosService processPhotosService)
        {
            _logger = logger;
            _processPhotosService = processPhotosService;
        }

        [HttpPost]
        public ActionResult<string> ProcessPhotos([FromForm]  ProcessPostDto dto)
        {

            this._logger.Log(LogLevel.Trace, "processing...");

            return _processPhotosService.ProcessPhotos(dto);
        }
    }
}