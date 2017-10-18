namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// class Documents
	/// </summary>
	public class Documents : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Documents resource object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Documents(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// CRUD METHODS //////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>Create a new account document: See PayoneerEscrow.Api.Resource.Accounts.Documents()</para>
		/// <para>Create a new order document:   See PayoneerEscrow.Api.Resource.Orders.Documents()</para>
		/// <para>Create a new dispute document: See PayoneerEscrow.Api.Resource.Disputes.Documents()</para>
		/// <para>Create a new offer document:   See PayoneerEscrow.Api.Resource.Offers.Documents()</para>
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new document.</returns>
		public object Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}
	}
}
