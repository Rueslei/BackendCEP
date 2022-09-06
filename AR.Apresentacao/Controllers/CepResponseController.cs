using Microsoft.AspNetCore.Mvc;
using Refit;

namespace AR.Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepResponseController : ControllerBase
    {
        private const string V = "erro na consulta de cep:";

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> IndexAsync(string cepInformado)
        {           
            try
            {
                var cepClient = RestService.For<InterfaceCepApiService>("http://viacep.com.br");

                var address = await cepClient.GetAddressAsync(cepInformado.ToString());

                return Ok(address);
            }
            catch (Exception e)
            {
                string str = e.Message;
                //return (IActionResult)JObject.Parse(str);
                return BadRequest(str);
            }
        }
    }
}