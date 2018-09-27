using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

namespace WSConvertisseur.Controllers
{
    [Produces("application/json")]
    [Route("api/Devise")]
    public class DeviseController : Controller
    {

        private List<Devise> _devises;

        public DeviseController()
        {
            _devises = new List<Devise>();
            _devises.Add(new Devise(1, "Dollar", 1.08));
            _devises.Add(new Devise(2, "Franc Suisse", 1.07));
            _devises.Add(new Devise(3, "Yen", 120));
        }

        // GET: api/Devise
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return _devises;
        }

        // GET: api/Devise/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult Get(int id)
        {
            Devise devise = _devises.FirstOrDefault((d) => d.Id == id);
            if(devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }
        
        // POST: api/Devise
        [HttpPost]
        public IActionResult Post([FromBody]Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }
        
        // PUT: api/Devise/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Devise devise = _devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            _devises.Remove(devise);
            return Ok(devise);
          
        }
    }
}
