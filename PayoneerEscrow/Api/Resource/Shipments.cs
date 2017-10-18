namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Shipments
	/// </summary>
	public class Shipments : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Shipments resource object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Shipments(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base(host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create a new shipment on an order: See PayoneerEscrow.Api.Resource.Orders.Shipments()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new shipment.</returns>
		public string Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}
	}
}
