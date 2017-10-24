using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp_NetFramework461_NetStandard14_20
{
	class Program
	{
		static void Main(string[] args)
		{
			// Get Payoneer Escrow client to make requests
			PayoneerEscrow.Api.Client client = new PayoneerEscrow.Api.Client(
				"your_api_key",
				"your_api_secret",
				true);

			try
			{
				// Get all clients associated with the API key
				Console.WriteLine("\n\nGetting all clients...\n\n");
				dynamic accounts = client.Accounts().All();
				Console.WriteLine(accounts);


				Console.WriteLine("\n\nGetting a single account...\n\n");
				dynamic account = client.Accounts().Get("170246583945");
				Console.WriteLine(account);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			// Keep program open
			Console.Write("\n\nPress [Enter] to quit.");
			Console.ReadLine();
		}
	}
}
