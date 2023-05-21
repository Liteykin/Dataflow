using System.Text.Json.Serialization;

namespace Dataflow.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Tier
{
    Tier1,
    Tier2,
    Tier3
}