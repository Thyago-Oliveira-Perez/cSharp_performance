using api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessPhotosController
    {
        private readonly ILogger<ProcessPhotosController> _logger;

        public ProcessPhotosController(ILogger<ProcessPhotosController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string ProcessPhotos([FromBody] ProcessPostDto dto)
        {

            this._logger.Log(LogLevel.Trace, "processing...");

            return dto.Method.ToString();
        }
    }
}