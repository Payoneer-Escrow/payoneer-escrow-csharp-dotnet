namespace PayoneerEscrow.Api.Resource {
	/// <summary>
	/// Class Accounts
	/// </summary>
	public class Accounts : Resource {

		///////////////////////////////////////////////////////////////////////
		// CONSTRUCTOR ///////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Construct a new Accounts resource object.
		/// </summary>
		/// <param name="host">The Payoneer Escrow API hostname being used for requests.</param>
		/// <param name="authenticator">The authenticator object.</param>
		/// <param name="uri_root">The resource's root URI.</param>
		public Accounts(string host, PayoneerEscrow.Api.Authenticator authenticator, string uri_root)
			: base (host, authenticator, uri_root) { }

		///////////////////////////////////////////////////////////////////////
		// METHODS: CRUD /////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
        /// Create a new account: See PayoneerEscrow.Api.Client.Accounts()
		/// </summary>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the new account.</returns>
		public dynamic Create(dynamic data) {
			this.Request("POST", this.Uri(), data).Wait();
			return this.api_response;
		}

		/// <summary>
        /// Update an existing account: See PayoneerEscrow.Api.Client.Accounts()
		/// </summary>
		/// <param name="account_id">The account's account_id.</param>
		/// <param name="data">The params to pass with the request.</param>
		/// <returns>Returns a response. Successful requests will return the updated account.</returns>
		public dynamic Update(string account_id, dynamic data) {
			this.Request("POST", this.Uri(account_id), data).Wait();
			return this.api_response;
		}

		///////////////////////////////////////////////////////////////////////
		// METHODS: PUBLIC ///////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////

		/// <summary>
		/// <para>
		/// Get a BankAccounts resource object to make requests to:
		///     /accounts/{account_id}/bankaccounts
		/// </para>
		/// <para>
		/// Example call to get all bank accounts:
		///     Function call:    client.Accounts().BankAccounts(account_id).All();
		///     Makes request to: /accounts/{account_id}/bankaccounts
		/// </para>
		/// <para>
		/// Example call to get a single bank account:
		///     Function call:    client.Accounts().BankAccounts(account_id).Get(bank_account_id);
		///     Makes request to: /accounts/{account_id}/bankaccounts/{bank_account_id}
		/// </para>
		/// <para>
		/// Example call to create a new bank account:
		///     Function call:    client.Accounts().Bankaccounts(account_id).Create(data);
		///     Makes request to: /accounts/{account_id}/bankaccounts
		/// </para>
		/// </summary>
		/// <param name="account_id">The account_id associated with the bank account(s).</param>
		/// <returns>Returns a BankAccounts resource object.</returns>
		public BankAccounts BankAccounts(string account_id) {
			return new BankAccounts(
				this.host,
				this.authenticator,
				this.Uri(account_id));
		}

		/// <summary>
		/// <para>
		/// Get a Documents resource object to make requests to:
		///     /accounts/{account_id}/documents
		/// </para>
		/// <para>
		/// Example call to get all documents:
		///     Function call:    client.Accounts().Documents(account_id).All();
		///     Makes request to: /accounts/{account_id}/documents
		/// </para>
		/// <para>
		/// Example call to get a single document:
		///     Function call:    client.Accounts().Documents(account_id).Get(document_id);
		///     Makes request to: /accounts/{account_id}/documents/{document_id}
		/// </para>
		/// <para>
		/// Example call to create a new document:
		///     Function call:    client.Accounts().Documents(account_id).Create(data);
		///     Makes request to: /accounts/{account_id}/documents
		/// </para>
		/// </summary>
		/// <param name="account_id">The account_id associated with the documents(s).</param>
		/// <returns>Returns a Documents resource object.</returns>
		public Documents Documents(string account_id) {
			return new Documents(
				this.host,
				this.authenticator,
				this.Uri(account_id));
		}

		/// <summary>
		/// <para>
		/// Get a Orders resource object to make requests to:
		///     /accounts/{account_id}/orders
		/// </para>
		/// <para>
		/// Example call to get all orders:
		///     Function call:    client.Accounts().Orders(account_id).All();
		///     Makes request to: /accounts/{account_id}/orders
		/// </para>
		/// <para>
		/// Example call to get a single order:
		///     Function call:    client.Accounts().Orders(account_id).Get(order_id);
		///     Makes request to: /accounts/{account_id}/orders/{order_id}
		/// </para>
		/// </summary>
		/// <param name="account_id">The account_id associated with the order(s).</param>
		/// <returns>Returns an Orders resource object.</returns>
		public Orders Orders(string account_id) {
			return new Orders(
				this.host,
				this.authenticator,
				this.Uri(account_id));
		}

		/// <summary>
		/// <para>
		/// Get a Users resource object to make requests to:
		///     /accounts/{account_id}/documents
		/// </para>
		/// <para>
		/// Example call to get all users:
		///     Function call:    client.Accounts().Users(account_id).All();
		///     Makes request to: /accounts/{account_id}/users
		/// </para>
		/// <para>
		/// Example call to get a single user:
		///     Function call:    client.Accounts().Users(account_id).Get(user_id);
		///     Makes request to: /accounts/{account_id}/users/{user_id}
		/// </para>
		/// <para>
		/// Example call to create a new user:
		///     Function call:    client.Accounts().Users(account_id).Create(data);
		///     Makes request to: /accounts/{account_id}/users
		/// </para>
		/// <para>
		/// Example call to update a user:
		///     Function call:    client.Accounts().Users(account_id).Update(user_id, data);
		///     Makes request to: /accounts/{account_id}/users/{user_id}
		/// </para>
		/// </summary>
		/// <param name="account_id">The account_id associated with the user(s).</param>
		/// <returns>Returns a Users resource object.</returns>
		public Users Users(string account_id) {
			return new Users(
				this.host,
				this.authenticator,
				this.Uri(account_id));
		}
	}
}
