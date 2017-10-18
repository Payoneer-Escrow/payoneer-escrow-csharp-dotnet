namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Users
	/// </summary>
	public class Users : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Users resource object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Users(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create a new user: See PayoneerEscrow.Api.Resource.Accounts.Users()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Succcessful requests will return the new user.</returns>
		public string Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}

		/// <summary>
		/// Update an existing user: See PayoneerEscrow.Api.Resource.Accounts.Users()
		/// </summary>
		/// <param name="user_id">The user's user_id.</param>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the updated user.</returns>
		public string Update(string user_id, Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(user_id), data).Wait();
			return this.api_response;
		}

		///////////////////////////////////////////////////////////////////////
		// METHODS: PUBLIC ///////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Access the authentications resource
		/// </summary>
		/// <param name="user_id"></param>
		/// <returns></returns>
		public Authentications Authentications(string user_id) {
			return new Authentications(
				this.host,
				this.authenticator,
				this.Uri(user_id));
		}
	}
}
