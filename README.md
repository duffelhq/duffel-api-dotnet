[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/duffelhq/duffel-api-dotnet/main/LICENSE)
[![Nuget](https://img.shields.io/nuget/dt/Duffel.ApiClient?label=Nuget.org%20Downloads&style=flat-square&color=blue)](https://www.nuget.org/packages/Duffel.ApiClient)

# duffel-api-dotnet
DotNet client library for the Duffel API

## Getting started
```shell
Install-Package Duffel.ApiClient -Version 0.0.1-alpha
```

## Usage

You first need to set the API token you can find in the Duffel [dashboard](https://app.duffel.com) under the section
Developers > Access Tokens.

```c#
using Duffel.ApiClient;

var accessToken = Environment.GetEnvironmentVariable("DUFFEL_ACCESS_TOKEN");
var client = new DuffelApiClient(accessToken: accessToken, production: false);
```

After you have a client you can interact with, you can make calls to the Duffel API:

```c#
var response = await client.OfferRequests.Create(offersRequest, returnOffers: false);

var selectedOffer = response.Offers.First();

var pricedOffer = await client.Offers.Get(selectedOffer.Id, returnAvailableServices: true);
```

You can find a complete e2e examples in [./Examples](./Examples) folder
