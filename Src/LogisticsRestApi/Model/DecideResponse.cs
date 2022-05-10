using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LogisticsRestApi.Model;

[JsonConverter(typeof(StringEnumConverter))]
public enum DecisionResponseType
{
    [EnumMember(Value = "DELIVER")] Deliver,
    [EnumMember(Value = "SLEEP")] Sleep,
    [EnumMember(Value = "DRIVE")] Drive,
    [EnumMember(Value = "LOAD")] Load,
    [EnumMember(Value = "ROUTE")] Route,
    [EnumMember(Value = "UNLOAD")] Unload
}

public record DecideResponse(
    DecisionResponseType Command = DecisionResponseType.Sleep,
    object Argument = default
)
{
    public static DecideResponse Deliver(int cargoUid)
    {
        return new DecideResponse(DecisionResponseType.Deliver, cargoUid);
    }

    public static DecideResponse Route(string destinationName)
    {
        return new DecideResponse(DecisionResponseType.Route, destinationName);
    }

    public static DecideResponse Sleep(int hours)
    {
        if (hours < 1) { throw new Exception("Hours must be greater than 0"); }

        return new DecideResponse(DecisionResponseType.Sleep, hours);
    }
}