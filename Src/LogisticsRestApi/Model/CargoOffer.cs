using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record CargoOffer(
    int Uid,
    [property: JsonPropertyName("dest")] string? Destination,
    string Name,
    double Price,
    [property: JsonPropertyName("eta_to_cargo")] double EtaToCargo,
    [property: JsonPropertyName("km_to_cargo")] double KmToCargo,
    [property: JsonPropertyName("eta_to_deliver")] double EtaToDeliver,
    [property: JsonPropertyName("km_to_deliver")] double KmToDeliver
);