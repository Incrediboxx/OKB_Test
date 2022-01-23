namespace OKB_Test.Model
{
    /// <summary>
    /// Класс описывающий валюту
    /// </summary>
    public class Currency
    {
        public string Id { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; } 
    }
}
