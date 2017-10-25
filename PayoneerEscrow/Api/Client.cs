namespace PayoneerEscrow.Api {
	/// <summary>
	/// Class Client
	/// </summary>
	public class Client {

		///////////////////////////////////////////////////////////////////////
		// PROPERTIES ////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// The authenticator object that handles authenticating requests made to the API.
		/// </summary>
		protected Authenticator authenticator;

		/// <summary>
		/// A flag to tell the client to make requests to the sandbox environment.
		/// </summary>
		protected bool use_sandbox;

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new client for making requests to the Payoneer Escrow API.
		/// </summary>
		/// <param name="api_key">Your API key.</param>
		/// <param name="api_secret">Your API secret.</param>
		/// <param name="sandbox">Use the sandbox environment?</param>
		public Client(string api_key, string api_secret, bool sandbox = false) {
			this.authenticator = new Authenticator(api_key, api_secret);
			this.use_sandbox   = sandbox;
		}

		///////////////////////////////////////////////////////////////////////
		// PUBLIC ////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>
		/// Get an Accounts resource object to make requests to:
		///     /accounts
		/// </para>
		/// <para>
		/// Example call to get all accounts:
		///     Function call:    client.Accounts().All();
		///     Makes request to: /accounts
		/// </para>
		/// <para>
		/// Example call to get a single account:
		///     Function call:    client.Accounts().Get(account_id);
		///     Makes request to: /accounts/{account_id}
		/// </para>
		/// <para>
		/// Example call to create a new account:
		///     Function call:    client.Accounts().Create(data);
		///     Makes request to: /accounts
		/// </para>
		/// <para>
		/// Example call to update an existing account:
		///     Function call:    client.Accounts().Update(account_id, data);
		///     Makes request to: /accounts/{account_id}
		/// </para>
		/// </summary>
		/// <returns>Returns an Accounts resource object.</returns>
		public Resource.Accounts Accounts() {
			return new Resource.Accounts(
				this.GetApiHostname(),
				this.authenticator,
				"");
		}

		///////////////////////////////////////////////////////////////////////
		// PROTECTED /////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Get the Payoneer Escrow application hostname to use for requests.
		/// </summary>
		/// <returns>Returns the Payoneer Escrow hostname to use for requests.</returns>
		protected string GetApiHostname() {
			if (this.use_sandbox) {
				return "https://sandbox.armorpayments.com";
			}

			return "https://pay.payoneer.com";
		}
	}
}
