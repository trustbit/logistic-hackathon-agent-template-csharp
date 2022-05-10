using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record TruckState(
    int Uid,
    double Balance,
    string Loc,
    [property: JsonPropertyName("driving_non_stop")] double DrivingNonStop,
    double Time
);