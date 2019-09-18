using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatoriskOpgave1_CSharpAndUnitTest;

namespace RestBogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogsController : ControllerBase
    {
        private static readonly List<Bog> bogList = new List<Bog>()
        {
            new Bog("C Sharp 101", "Morten", 598, "ISBN123456789"),
            new Bog("HTML 101", "Morten", 258, "ISBN123456788"),
            new Bog("CSS 101", "Morten", 198, "ISBN123456777"),
            new Bog("TypeScript 101", "Morten", 123, "ISBN123456666"),
            new Bog("SCRUM 101", "Morten", 999, "ISBN123455555")
        };

        // GET: api/Bogs
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return bogList;
        }

        // GET: api/Bogs/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Bog Get(string isbn13)
        {
            return bogList.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Bogs
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            bogList.Add(value);
        }

        // PUT: api/Bogs/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog value)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Isbn13 = value.Isbn13;
                bog.Forfatter = value.Forfatter;
                bog.Sidetal = value.Sidetal;
                bog.Titel = value.Titel;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog bog = Get(isbn13);
            bogList.Remove(bog);
        }
    }
}
