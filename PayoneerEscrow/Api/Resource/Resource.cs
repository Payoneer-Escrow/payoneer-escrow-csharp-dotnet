namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Resource
	/// </summary>
	public abstract class Resource {

		///////////////////////////////////////////////////////////////////////
		// PROPERTIES ////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// The Payoneer Escrow API hostname being used for requests.
		/// </summary>
		protected string host = null;

		/// <summary>
		/// The response received from a request.
		/// </summary>
		protected dynamic api_response = null;
		
		/// <summary>
		/// The resource's root URI.
		/// </summary>
		protected string uri_root = null;
	
		/// <summary>
		/// The authenticator object that handles authenticating requests made to the API.
		/// </summary>
		protected PayoneerEscrow.Api.Authenticator authenticator = null;

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Resource resource object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		protected Resource(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root) {
			this.host          = host;
			this.authenticator = authenticator;
			this.uri_root      = uri_root;
		}

		///////////////////////////////////////////////////////////////////////
		// PUBLIC ////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Get the URI to use for the request.
		/// </summary>
		/// <param name="object_id">(optional) The id of the object to get (e.g., account_id)</param>
		/// <returns>Returns the URI.</returns>
		public string Uri(string object_id = null) {
			string uri = string.IsNullOrEmpty(object_id)
				? ""
				: ("/" + object_id);
            return this.uri_root + "/" + this.ResourceName() + uri;
		}

		/// <summary>
		/// Get all objects (waits for the task to complete).
		/// </summary>
		/// <returns>Returns a response. Successful requests will all objects.</returns>
		public dynamic All() {
			this.Request("GET", this.Uri()).Wait();
			return this.api_response;
		}

		/// <summary>
		/// Get a single object (waits for the task to complete).
		/// </summary>
		/// <returns>Returns a response. Successfull requests will return a single object.</returns>
		public dynamic Get(string object_id) {
			this.Request("GET", this.Uri(object_id)).Wait();
			return this.api_response;
		}

		///////////////////////////////////////////////////////////////////////
		// PROTECTED /////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Make a request.
		/// </summary>
		/// <param name="method">The HTTP method (e.g, GET).</param>
		/// <param name="uri">The URI to use for the request.</param>
		/// <param name="data">(optional) The data to pass with the request.</param>
		/// <returns></returns>
		protected async System.Threading.Tasks.Task Request(string method, string uri, dynamic data = null) {
			// Get a new HttpClient and declare HttpRequestMessage
			System.Net.Http.HttpClient client            = new System.Net.Http.HttpClient();
			System.Net.Http.HttpRequestMessage request   = new System.Net.Http.HttpRequestMessage();
			System.Net.Http.HttpResponseMessage response = null;

			// Set the request headers
			System.Collections.Generic.Dictionary<string, string> secureHeaders = this.authenticator.SecureHeaders(method, uri);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("X-ARMORPAYMENTS-APIKEY",           secureHeaders["X-ARMORPAYMENTS-APIKEY"]);
			client.DefaultRequestHeaders.Add("X-ARMORPAYMENTS-REQUESTTIMESTAMP", secureHeaders["X-ARMORPAYMENTS-REQUESTTIMESTAMP"]);
			client.DefaultRequestHeaders.Add("X-ARMORPAYMENTS-SIGNATURE",        secureHeaders["X-ARMORPAYMENTS-SIGNATURE"]);

			// Create the full URL
			string url = this.host + uri;

			// What kind of request is being sent? Set the correct one.
			switch (method.ToUpper()) {
				case "GET":
					request.Method = System.Net.Http.HttpMethod.Get;
					request.RequestUri = new System.Uri(url);
					// Are there any query/request params to attach?
					string queryParams = null;
					if (data != null) {
						foreach (System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken> set in data) {
							queryParams += ($"{set.Key}={set.Value}");
						}
						if (!string.IsNullOrEmpty(queryParams)) {
							url += ($"?{queryParams}");
						}
					}
					response = await client.SendAsync(request);
					break;
				case "POST":
					if (data != null) {
						data            = Newtonsoft.Json.JsonConvert.SerializeObject(data);
						request.Content = new System.Net.Http.StringContent(data, System.Text.Encoding.UTF8, "application/json");
					}
					response = await client.PostAsync(url, request.Content);
					break;
				default:
					throw new System.Exception("HTTP method not found.");
			}

			// Deserialize the JSON string that was returned from the request
			this.api_response = await response.Content.ReadAsStringAsync();
			this.api_response = Newtonsoft.Json.JsonConvert.DeserializeObject(this.api_response);
		}

		/// <summary>
		/// Get the name of the class, which is the name of the resource
		/// </summary>
		/// <returns>Returns the name of the resource</returns>
		protected string ResourceName() {
			return this.GetType().Name.ToLower();
		}
	}
}
