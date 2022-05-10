namespace LogisticsRestApi.Model;

public record DecideRequest(TruckState Truck, ICollection<CargoOffer> Offers, bool IsFleet);