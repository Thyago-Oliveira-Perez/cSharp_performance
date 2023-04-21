using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessPhotosController : ControllerBase
    {
        private readonly ILogger<ProcessPhotosController> _logger;

        public ProcessPhotosController(ILogger<ProcessPhotosController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string ProcessPhotos()
        {
            this._logger.Log(LogLevel.Trace, "processing...");

            return "In development";
        }
    }
}