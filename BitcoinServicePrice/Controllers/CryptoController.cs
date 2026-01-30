using BitcoinServicePrice.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinServicePrice.Controllers
{
    [ApiController]
    [Route("api/crypto")]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoService _service;

        public CryptoController(CryptoService service)
        {
            _service = service;
        }

        [HttpGet("Price")]
        public async Task<IActionResult> GetPrice(string symbol)
        {
            return Ok(await _service.GetPricesAsync(symbol));
        }
    }
}
