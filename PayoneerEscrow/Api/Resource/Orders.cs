namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Orders
	/// </summary>
	public class Orders : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Orders resource object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Orders(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Create a new order: See PayoneerEscrow.Api.Resource.Accounts.Orders()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new order.</returns>
		public object Create(Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}

		/// <summary>
		/// Update an existing order: See PayoneerEscrow.Api.Resource.Accounts.Orders()
		/// </summary>
		/// <param name="order_id">The orders's order_id.</param>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the updated order.</returns>
		public object Update(string order_id, Newtonsoft.Json.Linq.JObject data) {
			this.Request("POST", this.Uri(order_id), data).Wait();
			return this.api_response;
		}

		///////////////////////////////////////////////////////////////////////
		// METHODS: PUBLIC ///////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>
		/// Get a Documents resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/documents
		/// </para>
		/// <para>
		/// Example call to get all documents:
		///     Function call:    client.Accounts().Orders(account_id).Documents(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/documents
		/// </para>
		/// <para>
		/// Example call to get a single document:
		///     Function call:    client.Accounts().Orders(account_id).Documents(order_id).Get(document_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/documents/{document_id}
		/// </para>
		/// <para>
		/// Example call to create a new order document:
		///     Function call:    client.Accounts().Orders(account_id).Documents(order_id).Create(data);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/documents
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the document(s).</param>
		/// <returns>Returns a Documents resource object.</returns>
		public Documents Documents(string order_id) {
			return new Documents(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get a Notes resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/notes
		/// </para>
		/// <para>
		/// Example call to get all notes:
		///     Function call:    client.Accounts().Orders(account_id).Notes(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/notes
		/// </para>
		/// <para>
		/// Example call to get a single note:
		///     Function call:    client.Accounts().Orders(account_id).Notes(order_id).Get(note_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/notes/{note_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the notes(s).</param>
		/// <returns>Returns a Notes resource object.</returns>
		public Notes Notes(string order_id) {
			return new Notes(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get a Disputes resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/disputes
		/// </para>
		/// <para>
		/// Example call to get all disputes:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes
		/// </para>
		/// <para>
		/// Example call to get a single dispute:
		///     Function call:    client.Accounts().Orders(account_id).Disputes(order_id).Get(dispute_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/disputes/{dispute_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the disputes(s).</param>
		/// <returns>Returns a Disputes resource object.</returns>
		public Disputes Disputes(string order_id) {
			return new Disputes(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get a Milestones resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/milestones
		/// </para>
		/// <para>
		/// Example call to get all milestones:
		///     Function call:    client.Accounts().Orders(account_id).Milestones(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/milestones
		/// </para>
		/// <para>
		/// Example call to get a single milestone:
		///     Function call:    client.Accounts().Orders(account_id).Milestones(order_id).Get(milestone_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/milestones/{milestone_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the milestones(s).</param>
		/// <returns>Returns a Milestones resource object.</returns>
		public Milestones Milestones(string order_id) {
			return new Milestones(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get an OrderEvents resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/orderevents
		/// </para>
		/// <para>
		/// Example call to get all order events:
		///     Function call:    client.Accounts().Orders(account_id).OrderEvents(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/orderevents
		/// </para>
		/// <para>
		/// Example call to get a single order event:
		///     Function call:    client.Accounts().Orders(account_id).OrderEvents(order_id).Get(event_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/orderevents/{event_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the order events(s).</param>
		/// <returns>Returns a OrderEvents resource object.</returns>
		public OrderEvents OrderEvents(string order_id) {
			return new OrderEvents(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get an PaymentInstructions resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/paymentinstructions
		/// </para>
		/// <para>
		/// Example call to get all payment method instructions:
		///     Function call:    client.Accounts().Orders(account_id).PaymentInstructions(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/paymentinstructions
		/// </para>
		/// <para>
		/// Example call to get a instructions for a single payment method:
		///     Function call:    client.Accounts().Orders(account_id).PaymentInstructions(order_id).Get(payer_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/paymentinstructions/{payer_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the payment method instructions.</param>
		/// <returns>Returns a PaymentInstructions resource object.</returns>
		public PaymentInstructions PaymentInstructions(string order_id) {
			return new PaymentInstructions(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}

		/// <summary>
		/// <para>
		/// Get an Shipments resource object to make requests to:
		///     /accounts/{account_id}/orders/{order_id}/shipments
		/// </para>
		/// <para>
		/// Example call to get all shipments:
		///     Function call:    client.Accounts().Orders(account_id).Shipments(order_id).All();
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/shipments
		/// </para>
		/// <para>
		/// Example call to get a single shipment:
		///     Function call:    client.Accounts().Orders(account_id).Shipments(order_id).Get(shipment_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}/shipments/{shipment_id}
		/// </para>
		/// </summary>
		/// <param name="order_id">The order_id associated with the shipment(s).</param>
		/// <returns>Returns a Shipments resource object.</returns>
		public Shipments Shipments(string order_id) {
			return new Shipments(
				this.host,
				this.authenticator,
				this.Uri(order_id));
		}
	}
}
