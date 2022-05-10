using System.Text.Json.Serialization;

namespace LogisticsRestApi.Model;

public record DecideRequest(TruckState Truck, ICollection<CargoOffer> Offers, bool IsFleet )
{
}

public record TruckState(
    int Uid,
    double Balance,
    String Loc,
    [property: JsonPropertyName("driving_non_stop")] double DrivingNonStop,
    double Time
)
{
}