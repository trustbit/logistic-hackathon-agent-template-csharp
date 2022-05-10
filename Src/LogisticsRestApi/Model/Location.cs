namespace LogisticsRestApi.Model;

public record Location(string Name, Dictionary<string, double> Roads);