using Microsoft.AspNetCore.Mvc;
using SinSigGenerator.Models;
using SinSigGenerator.Services;
using System.Drawing;

namespace SinSigGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SignalController : ControllerBase
    {
        private readonly SignalGeneratorService _signalGeneratorService;

        public SignalController (SignalGeneratorService signalGeneratorService)
        {
            _signalGeneratorService = signalGeneratorService;
        }

        [HttpPost]
        public FileStreamResult GetSinSignal(SignalModel sig)
            => RenderImage(_signalGeneratorService.GetSin(sig));

        private FileStreamResult RenderImage (ImageModel model, bool download = true)
        {
            var fs = new FileStream(model.FilePath, FileMode.Open);
            if (download)
                return File(fs, model.MimeType, $"{model.Id}");
            else
                return File(fs, model.MimeType);
        }
    }
}