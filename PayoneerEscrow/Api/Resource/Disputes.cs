namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Disputes
	/// </summary>
	public class Disputes : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Disputes object.
		///</summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Disputes(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// PUBLIC METHODS ////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>
		/// Get a Documents resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/documents
		/// <para>
		/// </para>
		/// Example call to get all documents:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Documents(dispute_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/documents
		/// <para>
		/// </para>
		/// Example call to get a single document:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Documents(dispute_id).Get(document_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/documents/{document_id}
		/// <para>
		/// </para>
		/// Example call to create a new dispute document:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Documents(dispute_id).Create(data);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/documents
		/// </para>
		/// </summary>
		/// <param name="dispute_id">The dispute_id associated with the document(s).</param>
		/// <returns>Returns a Documents resource object.</returns>
		public Documents Documents(string dispute_id) {
			return new Documents(
				this.host,
				this.authenticator,
				this.Uri(dispute_id));
		}

		/// <summary>
		/// <para>
		/// Get a notes resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/notes
		/// <para>
		/// </para>
		/// Example call to get all notes:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Notes(dispute_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/notes
		/// <para>
		/// </para>
		/// Example call to get a single note:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Notes(dispute_id).Get(note_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/notes/{note_id}
		/// </para>
		/// </summary>
		/// <param name="dispute_id">The dispute_id associated with the notes(s).</param>
		/// <returns>Returns a Notes resource object.</returns>
		public Notes Notes(string dispute_id) {
			return new Notes(
				this.host,
				this.authenticator,
				this.Uri(dispute_id));
		}

		/// <summary>
		/// <para>
		/// Get an offers resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers
		/// <para>
		/// </para>
		/// Example call to get all offers:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Offers(dispute_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers
		/// <para>
		/// </para>
		/// Example call to get a single offer:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Offers(dispute_id).Get(offer_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers/{offer_id}
		/// <para>
		/// </para>
		/// Example call to create a new offer:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Offers(dispute_id).Create(data);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}/offers
		/// </para>
		/// </summary>
		/// <param name="dispute_id">The dispute_id associated with the offer(s).</param>
		/// <returns>Returns an Offers resource object.</returns>
		public Offers Offers(string dispute_id) {
			return new Offers(
				this.host,
				this.authenticator,
				this.Uri(dispute_id));
		}
	}
}
