namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Offers
	/// </summary>
	public class Offers : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Offers resource object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Offers(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }
		
		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create a new dispute offer: See PayoneerEscrow.Api.Resource.Disputes.Offers()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new account.</returns>
		public dynamic Create(dynamic data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}

		/// <summary>
		/// Update an existing offer: See PayoneerEscrow.Api.Resource.Disputes.Offers()
		/// </summary>
		/// <param name="offer_id">The offer's offer_id.</param>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the updated offer.</returns>
		public dynamic Update(string offer_id, dynamic data) {
			this.Request("POST", this.Uri(offer_id), data).Wait();
			return this.api_response;
		}
		///////////////////////////////////////////////////////////////////////
		// METHODS: PUBLIC ///////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>
		/// Get a Documents resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/documents
		/// </para>
		/// <para>
		/// Example call to get all documents:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Offers().Documents(offer_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/documents
		/// </para>
		/// <para>
		/// Example call to get a single document:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Documents(offer_id).Get(document_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/documents/{document_id}
		/// </para>
		/// <para>
		/// Example call to create a new offer document:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Documents(offer_id).Create(data);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/documents
		/// </para>
		/// </summary>
		/// <param name="offer_id">The offer_id associated with the document(s).</param>
		/// <returns>Returns a Documents resource object.</returns>
		public Documents Documents(string offer_id) {
			return new Documents(
				this.host,
				this.authenticator,
				this.Uri(offer_id));
		}

		/// <summary>
		/// <para>
		/// Get a Notes resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/notes
		/// </para>
		/// <para>
		/// Example call to get all notes:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Offers().Notes(offer_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/notes
		/// </para>
		/// <para>
		/// Example call to get a single note:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Notes(offer_id).Get(note_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}/notes/{note_id}
		/// </para>
		/// </summary>
		/// <param name="offer_id">The offer_id associated with the note(s).</param>
		/// <returns>Returns a Notes resource object.</returns>
		public Notes Notes(string offer_id) {
			return new Notes(
				this.host,
				this.authenticator,
				this.Uri(offer_id));
		}
	}
}
