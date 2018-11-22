using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fachada;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace GeneradorUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        FachadaUI _fachadaUI = new FachadaUI();

        [HttpPost]
        public async Task<ActionResult<string>> postForm([FromBody] DefaultModel defaultModel)
        {
            string response = await _fachadaUI.GenerarHTML(defaultModel);
            response += await _fachadaUI.GenerarScript(defaultModel);

            return response;
        }
    }
}