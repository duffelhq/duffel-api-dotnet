using Duffel.ApiClient;
using Duffel.ApiClient.Exceptions;
using Newtonsoft.Json;

try
{
    var accessToken = Environment.GetEnvironmentVariable("DUFFEL_ACCESS_TOKEN");
    var client = new DuffelApiClient(accessToken: accessToken);

    Console.WriteLine("Loading airports...");
    var airports = await client.Airports.GetAll();
    Console.WriteLine($"Retrieved {airports.Count()} airports");
    Console.WriteLine($"Loading single airport {airports.First().PlaceName} {airports.First().IataCode}");
    var airport = await client.Airports.Get(airports.First().Id);
    Console.WriteLine($"Airport is located at geolocation: {airport.Latitude}, {airport.Longitude}");
    Console.WriteLine($"Airport is located in or near {airport.CityName}");

    Console.WriteLine("Loading aircrafts...");
    var aircrafts = await client.Aircraft.GetAll();
    Console.WriteLine($"Retrieved {aircrafts.Count()} aircrafts");
    Console.WriteLine($"Loading single aircraft {aircrafts.First().AircraftName}");
    var aircraft = await client.Aircraft.Get(aircrafts.First().Id);
    Console.WriteLine($"Aircraft IATA: {aircraft.IataCode}");

    Console.WriteLine("Loading airlines...");
    var airlines = await client.Airlines.GetAll();
    Console.WriteLine($"Retrieved {airlines.Count()} airlines");
    Console.WriteLine($"Loading single airline {airlines.First().AirlineName}");
    var airline = await client.Airlines.Get(airlines.First().Id);
    Console.WriteLine($"Airline IATA: {airline.IataCode}");
}
catch (ApiException apiException)
{
    Console.WriteLine($"Failed with status: {apiException.Metadata.Status}, request Id: {apiException.Metadata.RequestId}");

    foreach (var apiExceptionError in apiException.Errors)
    {
        Console.WriteLine(apiExceptionError.Message);
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
