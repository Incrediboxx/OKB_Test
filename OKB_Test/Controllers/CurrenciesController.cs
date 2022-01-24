using Microsoft.AspNetCore.Mvc;
using OKB_Test.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <summary>
        /// Все коды валют
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCurrencies()
        {
            var CharCodes = from currency in _context.Сurrencies
                            select currency.CharCode;

            return CharCodes.ToList();
        }

        /// <summary>
        /// Получение значения валюты по ее коду
        /// </summary>
        /// <param name="charCode">Код валюты</param>
        /// <returns></returns>
        [HttpGet("ValueByCode")]
        public async Task<ActionResult<decimal>> GetCurrencyValueByCode(string charCode)
        {
            if (string.IsNullOrEmpty(charCode))
                return BadRequest("Empty currency charCode");

            var value = from currency in _context.Сurrencies
                        where currency.CharCode == charCode
                        select currency.Value;

            if (value.Count() == 0)
                return BadRequest("There is no currency with this code");

            return value.First();
        }
    }
}
