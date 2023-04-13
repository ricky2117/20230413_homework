using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Invoice invoice = new Invoice();

			Console.Write("請輸入未稅金額:");
			int price;
			while(! int.TryParse(Console.ReadLine(),out price) )
			{
                Console.WriteLine("請輸入有效的未稅金額:");
            }
			invoice.Price = price;


			Console.Write("請輸入營業稅率(單位%):");
			int tax;
			while (!int.TryParse(Console.ReadLine(), out tax))
			{
				Console.WriteLine("請輸入有效的營業稅(單位%):");
			}
			invoice.Tax = tax;
		

			Invoice inclusivePrice = new Invoice(invoice.Price,invoice.Tax);
			Console.WriteLine("含稅金額:"+inclusivePrice.InclusivePrice.ToString("N0"));

			Console.ReadLine();

		}
	}
	public class Invoice
	{
		public int Price { get; set; }

		public int Tax { get; set; }
		public int InclusivePrice { get; } 
		public Invoice() { }

		public Invoice(int price,int tax) 
		{
		   double tax_num =  (tax *0.01) +1;
		   double result = price * tax_num; 

		   InclusivePrice = (int)Math.Round(result,MidpointRounding.AwayFromZero);
		}
	}
}
