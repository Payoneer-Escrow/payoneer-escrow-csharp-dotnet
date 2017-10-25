# Payoneer Escrow

This is intended to be a clean, idiomatic client for the [Armor Payments API](https://escrow.payoneer.com/api). This will handle generating the authenticated headers and constructing the properly nested request URI, as well as parsing any response JSON for you.

Current package version: 1.0.0

---

## Dependencies

**.NETStandard 1.3**

* NETStandard.Library (>= 1.6.1)
* Newtonsoft.Json (>= 10.0.3)

**.NETStandard 1.4**

* NETStandard.Library (>= 1.6.1)
* Newtonsoft.Json (>= 10.0.3)

**.NETStandard 1.5**

* NETStandard.Library (>= 1.6.1)
* Newtonsoft.Json (>= 10.0.3)

**.NETStandard 1.6**

* NETStandard.Library (>= 1.6.1)
* Newtonsoft.Json (>= 10.0.3)

**.NETStandard 2.0**

* Newtonsoft.Json (>= 10.0.3)
* System.Security.Cryptography.Algorithms (>= 4.3.0)

## Installation

You can install using:
* [NuGet Package Manager](#nuget-package-manager)
* [NuGet Gallery](#nuget-gallery) (to download raw `nupkg` file)
* [.NET Core command-line interface (CLI)](#net-core-command-line-interface-cli)
* [Git](#git)

### NuGet Package Manager

```
PM> Install-Package PayoneerEscrow -Version 1.0.0
```
*Note: You can also use Visual Studio's NuGet Package Manager and add the package from there*

### NuGet Gallery

You can download the raw `nupkg` file at [https://www.nuget.org/packages/PayoneerEscrow](https://www.nuget.org/packages/PayoneerEscrow). Once you've downloaded the `nupkg` file, configure your NuGet Package Manager's sources to include the directory of the `nupkg` file. The `PayoneerEscrow` NuGet package will be available to download after you configure your sources.

### .NET Core command-line interface (CLI)

```
dotnet add package PayoneerEscrow --version 1.0.0
```

### Git

```
cd path/to/your/project

git clone https://github.com/Payoneer-Escrow/payoneer-escrow-csharp-dotnet.git

git checkout version-1.0.0
```

## Usage

The Payoneer Escrow API is REST-ish and nested, so the client relies on chaining. We return an object (or array of objects) decoded from the JSON response, if possible.

View the [Integration Guide](https://escrow.payoneer.com/api) for more information on use cases.
View the [Full Documentation](https://escrow.payoneer.com/api/pages/gettingStarted.html) for information on web requests, obtaining an API key, webhooks, and more.

### Get PayoneerEscrow.Api.Client for making web requests

```csharp
/**
 * Instantiate a new PayoneerEscrow.Api.Client and provide your API key and
 * secret. The third argument is a boolean flag. Set it to true to make web
 * requests to Payoneer Escrow's sandbox environment. Set it to false (or don't
 * include this argument) to make web requests to Payoneer Escrow's production
 * environment.
 */

PayoneerEscrow.Api.Client client = new PayoneerEscrow.Api.Client(
    "your_api_key",
    "your_api_secret",
    use_sandbox);
```

### Making requests: GET

```csharp
/**
 * There are two top-level resources: Accounts and ShipmentCarriers. Querying
 * users and orders requires an account_id.
 */

// Get all accounts
client.Accounts().All();

// Get a single account
client.Accounts().Get("account_id");

// Get all shipment carriers
client.Accounts().All();

// Get a single shipment carrier
client.ShipmentCarriers().Get("carrier_id");

/**
 * From Accounts, we chain BankAccounts, Documents, Orders, and Users. These
 * calls require an account_id.
 */

// Get all bank accounts associated with an account
client.Accounts().BankAccounts("account_id").All();

// Get a single bank account associated with an account
client.Accounts().BankAccounts("account_id").Get("bank_account_id");

// Get all documents associated with an account
client.Accounts().Documents("account_id").All();

// Get a single document associated with an account
client.Accounts().Documents("account_id").Get("document_id");

// Get all orders associated with an account
client.Accounts().Orders("account_id").All();

// Get a single order associated with an account
client.Accounts().Orders("account_id").Get("order_id");

// Get all users associated with an account
client.Accounts().Users("account_id").All();

// Get a single user associated with an account
client.Accounts().Users("account_id").Get("user_id");

/**
 * From Orders, many things can be chained: Documents, Notes, Disputes,
 * Milestones, OrderEvents, PaymentInstructions, and Shipments. These calls
 * require an account_id and order_id.
 */

// Get all documents associated with an order
client.Accounts().Orders("account_id").Documents("order_id").All();

// Get a single document associated with an order
client.Accounts().Orders("account_id").Documents("order_id").Get("document_id");

// Get all notes associated with an order
client.Accounts().Orders("account_id").Notes("order_id").All();

// Get a single note associated with an order
client.Accounts().Orders("account_id").Notes("order_id").Get("note_id");

// Get all disputes associated with an order
client.Accounts().Orders("account_id").Disputes("order_id").All();

// Get a single dispute associated with an order
client.Accounts().Orders("account_id").Disputes("order_id").Get("dispute_id");

// Get all milestones associated with an order
client.Accounts().Orders("account_id").Milestones("order_id").All();

// Get all order events associated with an order
client.Accounts().Orders("account_id").OrderEvents("order_id").All();

// Get a single order event associated with an order
client.Accounts().Orders("account_id").OrderEvents("order_id").Get("event_id");

// Get all payment instructions for an order
client.Accounts().Orders("account_id").PaymentInstructions().All();

// Get all shipments associated with an order
client.Accounts().Orders("account_id").Shipments("order_id").All();

// Get a single shipment associated with an order
client.Accounts().Orders("account_id").Shipments("order_id").Get("shipment_id");

/**
 * From Disputes, further things can be chained: Documents, Notes, and Offers.
 * These calls require an account_id, order_id, and dispute_id.
 */

// Get all documents associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Documents("dispute_id").All();

// Get a single document associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Documents("dispute_id").Get("document_id");

// Get all notes associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Notes("dispute_id").All();

// Get a single note associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Notes("dispute_id").Get("note_id");

// Get all offers associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").All();

// Get a single offer associated with a dispute on an order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Get("offer_id");


/**
 * From Offers, Documents and Notes can be chained. These calls require an
 * account_id, order_id, dispute_id, and offer_id.
 */

// Get all documents associated with an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Documents("offer_id").All();

// Get a single document associated with an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Documents("offer_id").Get("offer_id");

// Get all notes associated with an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Notes("offer_id").All();

// Get a single note associated with an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Notes("offer_id").Get("note_id");
```

### Making requests: POST

```csharp
/**
 * Some of the resource endpoints support Create/Update POST operations, and
 * this client aims to support those as well. POST operations use the
 * Newtonsoft.Json package to serialize objects as JSON. You can pass your POST
 * data as a Dictionary, JObject, or even an anonymous object.
 */

/**
 * CREATE methods. These methods allow you to execute CREATE operations.
 */

// Create a new account
// This example shows how to use a Dictionary for the POST params
Dictionary<string, string> data = new Dictionary<string, string> {
    { "account_type":    "1" },
    { "company":         "ACME Inc." },
    { "user_name":       "John Doe" },
    { "user_email":      "j.doe@example.com" },
    { "user_phone":      "+1 8005551234" },
    { "address":         "123 Main St." },
    { "city":            "Anytown" },
    { "state":           "CA" },
    { "zip":             "12345" },
    { "country":         "us" },
    { "email_confirmed": "true" },
    { "agreed_terms":    "true" }
};
client.Accounts().Create(data);

// Create a new order
// This example shows how to use a JObject for the POST params
JObject data = new JObject {
    { "seller_id", "seller_user_id" },
    { "buyer_id",  "buyer_user_id" },
    { "amount",    "10000" },
    { "summary",   "Test Order from Payoneer Escrow C#.NET SDK" }
};
client.Accounts().Orders("account_id").Create(data);

// Create an authenticated lightbox URL (for opening lightboxes)
// This example shows how to use an anonymous object for the POST params.
// Note: The URL is the value of the url property on the returned object.
var data = new {
  uri    = "/accounts/account_id",
  action = "view"
};
client.Accounts().Users("account_id").Authentications("user_id").Create(data);

// Create a user on an account
client.Accounts().Users("account_id").Create(data);

// Add a document to an account
client.Accounts().Documents("account_id").Create(data);

// Add a document to an order
client.Accounts().Orders("account_id").Documents("order_id").Create(data);

// Add a document to a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Documents("dispute_id").Create(data);

// Add a document to an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Documents("offer_id").Create(data);

// Add a note to an order
client.Accounts().Orders("account_id").Notes("order_id").Create(data);

// Add a note to a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Notes("dispute_id").Create(data);

// Add a note to an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Notes("offer_id").Create(data);

// Add a shipment to an order
client.Accounts().Orders("account_id").Shipments("order_id").Create(data);

/**
 * UPDATE methods. These methods allow you to execute UPDATE operations.
 */

// Update an account
var params = new {
    address     = "1234 Address Street",
    city        = "Los Angeles",
    phone       = "+1 8005551234",
    postal_code = "90046",
    state       = "CA",
    country     = "us",
};
client.Accounts().Update("account_id", params);

// Update an order
var params = new {
    { "action",            "add_payment" },
    { "confirm",           "true" },
    { "source_account_id", "buyer_account_id" },
    { "amount",            "10000" }
};
client.Accounts().Orders("account_id").Update("order_id", data);

// Update an offer on a disputed order
client.Accounts().Orders("account_id").Disputes("order_id").Offers("dispute_id").Update("offer_id", data);
```

## Contributing

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request
