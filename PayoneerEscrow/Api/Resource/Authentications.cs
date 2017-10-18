namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Authentications
	/// </summary>
	public class Authentications : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Authentications object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Authentications(string host, Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create an authenticated URL for opening authenticated lightboxes.
		/// </summary>
		/// <param name="data">The params to send with the request.</param>
		/// <returns>Returns a response. Successful requests will return the an authentications entity.</returns>
		public object Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}
	}
}