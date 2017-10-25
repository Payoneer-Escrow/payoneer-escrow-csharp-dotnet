using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ExampleApp_NetFramework46_NetStandard13
{
	class Program
	{
		static void Main(string[] args)
		{
			////////////////////////////////////////////////////////////////////
			// Add your API key and secret before running this example app    //
			////////////////////////////////////////////////////////////////////

			PayoneerEscrow.Api.Client client = new PayoneerEscrow.Api.Client(
				"api_key",
				"api_secret",
				true);

			////////////////////////////////////////////////////////////////////
			// Change sample data below to test proper API calls              //
			////////////////////////////////////////////////////////////////////

			/**
			 * Get all accounts
			 */
			Console.WriteLine("\n\nGet all accounts...\n\n");
			dynamic entity_accounts = client.Accounts().All();
			Console.WriteLine(entity_accounts);

			/**
			 * Get a single account
			 */
			Console.WriteLine("\n\nGet a single account...\n\n");
			dynamic entity_account = client.Accounts().Get("account_id");
			Console.WriteLine(entity_account);

			/**
			 * Get all users associated with an account
			 */
			Console.WriteLine("\n\nGet all users...\n\n");
			dynamic entity_users = client.Accounts().Users("account_id").All();
			Console.WriteLine(entity_users);

			/**
			 * Get a single user associated with an account
			 */
			Console.WriteLine("\n\nGet a single user...\n\n");
			dynamic entity_user = client.Accounts().Users("account_id").Get("user_id");
			Console.WriteLine(entity_user);

			/**
			 * Create an order
			 * 
			 * This example shows that a Dictionary can be used
			 */
			Console.WriteLine("\n\nCreate an order...\n\n");
			Dictionary<string, string> params_orderCreate = new Dictionary<string, string> {
				{ "seller_id", "seller_user_id" },
				{ "buyer_id",  "buyer_user_id" },
				{ "amount",    "10000" },
				{ "summary",   "Test Order from Payoneer Escrow C#.NET SDK" }
			};
			dynamic entity_orderCreated = client.Accounts().Orders("account_id").Create(params_orderCreate);
			Console.WriteLine(entity_orderCreated);

			/**
			 * Add funds to an order
			 * 
			 * This example shows that a JObject can be used
			 */
			Console.WriteLine("\n\nUpdate an order...\n\n");
			JObject params_orderUpdate = new JObject {
				{ "action",            "add_payment" },
				{ "confirm",           "true" },
				{ "source_account_id", "buyer_account_id" },
				{ "amount",            "10000" }
			};
			dynamic entity_orderUpdated = client.Accounts().Orders("account_id").Update("order_id", params_orderUpdate);
			Console.WriteLine(entity_orderUpdated);

			/**
			 * Update an account
			 * 
			 * This example shows that an anonymous object can be used
			 */
			Console.WriteLine("\n\nUpdate an account...\n\n");
			var params_accountUpdate = new
			{
				address = "1234 Address Street",
				city = "Los Angeles",
				phone = "+1 8005551234",
				postal_code = "90046",
				state = "CA",
				country = "us",
			};
			dynamic entity_accountUpdated = client.Accounts().Update("account_id", params_accountUpdate);
			Console.WriteLine(entity_accountUpdated);

			// Keep app open
			Console.Write("\n\nPress [Enter] to exit app.");
			Console.ReadLine();
		}
	}
}
