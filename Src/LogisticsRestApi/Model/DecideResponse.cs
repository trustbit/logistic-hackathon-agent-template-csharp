using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LogisticsRestApi.Model;

[JsonConverter(typeof(StringEnumConverter))]
public enum DecisionResponseType
{
    [EnumMember(Value = "DELIVER")] Deliver, [EnumMember(Value = "SLEEP")] Sleep, [EnumMember(Value = "ROUTE")] Route,
}

public abstract record DecideResponse(
    DecisionResponseType Command = DecisionResponseType.Sleep
);

public record DeliverResponse(int Argument) : DecideResponse(DecisionResponseType.Deliver)
{
}

public record SleepResponse(int Argument) : DecideResponse(DecisionResponseType.Sleep)
{
}

public record RouteResponse(string Argument) : DecideResponse(DecisionResponseType.Deliver)
{
}