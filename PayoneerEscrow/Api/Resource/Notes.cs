namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Notes
	/// </summary>
	public class Notes : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new PayoneerEscrow.Api.Resource.Notes object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Notes(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// CRUD METHODS //////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>Create a new order note:   See PayoneerEscrow.Api.Resource.Orders.Notes()</para>
		/// <para>Create a new dispute note: See PayoneerEscrow.Api.Resource.Disputes.Notes()</para>
		/// <para>Create a new offer note:   See PayoneerEscrow.Api.Resource.Offers.Notes()</para>
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new note.</returns>
		public object Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}
	}
}
