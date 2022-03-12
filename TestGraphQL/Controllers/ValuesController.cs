using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGraphQL.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CompanyConsumer _consumer;

        public ValuesController(CompanyConsumer _consumer)
        {
            this._consumer = _consumer;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _consumer.GetCompany();
            return Ok();
        }

        [HttpPost]
         public async Task<IActionResult> Post(Domains domains)
          {
                var createdComapny = await _consumer.CreateComapny(domains);
                return Ok(createdComapny);
          }

        

      
    }
}
