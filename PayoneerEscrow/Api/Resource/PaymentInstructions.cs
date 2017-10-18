namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class PaymentInstructions
	/// </summary>
	public class PaymentInstructions : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new PaymentInstructions resource object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public PaymentInstructions(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }
	}
}
