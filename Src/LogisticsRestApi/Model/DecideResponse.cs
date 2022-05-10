using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Logistics_Hackathon_CSharp.Model;
[JsonConverter(typeof(StringEnumConverter))]
public enum DecisionResponseType {	  [EnumMember(Value = "DELIVER")] Deliver,[EnumMember(Value = "SLEEP")]   Sleep ,[EnumMember(Value = "ROUTE")] Route}

public record DecideResponse(DecisionResponseType? Command, Object? Argument)
{
    public DecideResponse():this(null,null) {
    }

    public static DecideResponse Deliver(int cargoUid)
    {
        return new DecideResponse(DecisionResponseType.Deliver, cargoUid);
    }

    public static DecideResponse Route(String destinationName)
    {
        return new DecideResponse(DecisionResponseType.Route, destinationName);
    }

    public static DecideResponse Sleep(int hours)
    {
        if (hours < 1) { throw new Exception("Hours must be greater than 0"); }

        return new DecideResponse(DecisionResponseType.Sleep, hours);
    }
}
