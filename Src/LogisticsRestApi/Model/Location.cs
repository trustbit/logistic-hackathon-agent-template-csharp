namespace LogisticsRestApi.Model;

public record Location(String Name, Dictionary<String, Double> Roads)
{
}