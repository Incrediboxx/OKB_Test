using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OKB_Test.Model;

namespace OKB_Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : Controller
    {
        private readonly CurrerncyContext _context;


        public CurrenciesController(CurrerncyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCurrencies()
        {
            var CharCodes = from currency in _context.Сurrencies
                            select currency.CharCode;

            return CharCodes.ToList();
        }

        [HttpGet("ValueByCode")]
        public async Task<ActionResult<decimal>> GetCurrencyValue(string charCode)
        {
            var value = from currency in _context.Сurrencies
                        where currency.CharCode == charCode
                        select currency.Value;

            return value.First(); 
        }
    }
}
