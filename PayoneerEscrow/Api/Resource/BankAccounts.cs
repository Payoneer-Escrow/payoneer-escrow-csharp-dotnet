namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class BankAccounts
	/// </summary>
	public class BankAccounts : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new BankAccounts object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public BankAccounts(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create a new bank account: See PayoneerEscrow.Api.Resource.Accounts.BankAccounts()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns></returns>
		public dynamic Create(dynamic data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}
	}
}
