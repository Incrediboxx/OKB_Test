using Microsoft.EntityFrameworkCore;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace OKB_Test.Model
{
    public class CurrerncyContext : DbContext
    {
        private string CurrencyUrl = @"https://www.cbr-xml-daily.ru/daily_json.js";
        public DbSet<Currency> Сurrencies { get; set; } = null!;

        public CurrerncyContext(DbContextOptions<CurrerncyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var webClient = new WebClient();
            webClient.Proxy = new WebProxy()
            {
                Credentials = CredentialCache.DefaultCredentials
            };

            try
            {
                var currencyJson = webClient.DownloadString(CurrencyUrl);
                var valutes = JObject.Parse(currencyJson)["Valute"].Children();
                List<Currency> currencies = new List<Currency>();

                foreach (var item in valutes)
                {
                    currencies.Add(item.First.ToObject<Currency>());
                }

                modelBuilder.Entity<Currency>().HasData(currencies);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e); 
            }
        }
    }
}
