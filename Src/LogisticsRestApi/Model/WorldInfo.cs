namespace LogisticsRestApi.Model;

public record WorldInfo(IEnumerable<Location> Locations, double FuelCost)
{
}