[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/duffelhq/duffel-api-dotnet/main/LICENSE)
[![Nuget](https://img.shields.io/nuget/dt/Duffel.ApiClient?label=Nuget.org%20Downloads&style=flat-square&color=blue)](https://www.nuget.org/packages/Duffel.ApiClient)

# duffel-api-dotnet
DotNet client library for the Duffel API

## Getting started
Installing latest version:
```shell
Install-Package Duffel.ApiClient
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

## Error handling
The call to API can result in an error, which will then throw one out of two exceptions:

```c#
try
{
  var response = await client.OfferRequests.Create(offersRequest, returnOffers: false);
}
catch (ApiException apiEx)
{
    // apiEx.Errors - list of errors returned by the the API
    // apiEx.Metadata.RequestId - a Duffel id of the request
    // apiEx.StatusCode - an Http status code returned by the API    
}
catch (ApiDeserializationException desEx)
{
    // desEx.Payload - contains payload returned by the API
    // apiEx.StatusCode - an Http status code returned by the API
}
```

For more detailed information about error handling, see: [https://duffel.com/docs/api/overview/errors](https://duffel.com/docs/api/overview/errors)

## Examples

You can find a complete e2e examples in [./Examples](https://github.com/duffelhq/duffel-api-dotnet/tree/main/examples) folder
