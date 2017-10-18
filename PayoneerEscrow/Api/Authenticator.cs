namespace PayoneerEscrow.Api {
	/// <summary>
	/// Class Authenticator
	/// </summary>
	public class Authenticator {

		///////////////////////////////////////////////////////////////////////
		// PROPERTIES ////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Your API key.
		/// </summary>
		protected string api_key;

		/// <summary>
		/// Your API secret.
		/// </summary>
		protected string api_secret;

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct an authenticator object to handle authenticating requests made to API.
		/// </summary>
		/// <param name="api_key">Your API key.</param>
		/// <param name="api_secret">Your API secret.</param>
		public Authenticator(string api_key, string api_secret) {
			this.api_key = api_key;
			this.api_secret = api_secret;
		}

		///////////////////////////////////////////////////////////////////////
		// PUBLIC METHODS ////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Generate a set of secure request authentication headers.
		/// </summary>
		/// <param name="method">The HTTP request method (GET, POST).</param>
		/// <param name="uri">The request URI.</param>
		/// <returns>The secure request authentication headers in JSON</returns>
		public System.Collections.Generic.Dictionary<string, string> SecureHeaders(string method, string uri) {
			string timestamp = this.GetCurrentTimeStamp();
			System.Collections.Generic.Dictionary<string, string> headers = new System.Collections.Generic.Dictionary<string, string>();
			headers.Add("X-ARMORPAYMENTS-APIKEY", this.api_key);
			headers.Add("X-ARMORPAYMENTS-REQUESTTIMESTAMP", timestamp);
			headers.Add("X-ARMORPAYMENTS-SIGNATURE", this.GetRequestSignature(method, uri, timestamp));

			return headers;
		}

		///////////////////////////////////////////////////////////////////////
		// PROTECTED METHODS /////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Generate a Payoneer Escrow API accepted timestamp for the secure headers.
		/// </summary>
		/// <returns>Returns a timestamp.</returns>
		protected string GetCurrentTimeStamp() {
			return System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
		}

		/// <summary>
		/// Generate the signature part of the secure headers.
		/// </summary>
		/// <param name="method">The HTTP request method (GET, POST)</param>
		/// <param name="uri">The request URI</param>
		/// <param name="timestamp">The current time</param>
		/// <returns>Returns a hashed value of the API secret, request method, URI, and timestamp combined.</returns>
		protected string GetRequestSignature(string method, string uri, string timestamp) {
			// Trim any URI params off of the URI to sign
			uri = uri.Split('?')[0];

			return this.Hash(this.api_secret + ":" + method.ToUpper() + ":" + uri + ":" + timestamp);
		}

		/// <summary>
		/// Generate a hash value using the sha512 hashing algorithm.
		/// </summary>
		/// <param name="input">The string to be hashed.</param>
		/// <returns>Returns the hashed value of the specified string.</returns>
		protected string Hash(string input) {
			System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512.Create();
			byte[] data = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
			string hash = System.BitConverter.ToString(data).Replace("-", System.String.Empty).ToUpper();

			return hash;
		}
	}
}
