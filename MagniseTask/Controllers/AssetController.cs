using MagniseTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MagniseTask.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;
        public AssetController(AssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            var assets = await _assetService.GetSupportedAssetsAsync();
            return Ok(assets);
        }
    }
}
