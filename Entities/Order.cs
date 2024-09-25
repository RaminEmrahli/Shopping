namespace Shopping.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string EmailAdress { get; set; }
		public string Phone { get; set; }
		public string Location { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Amount { get; set; }
		public double Subtotal { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
	}
}
