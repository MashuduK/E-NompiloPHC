namespace E_NompiloPHC.Models
{
    public class TestPrice
    {
        public int Id { get; set; }

        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Laboratory Laboratory { get; set; }
        public Bill Bill { get; set; }
    }
}
