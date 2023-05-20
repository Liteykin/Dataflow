using System.Text.Json.Serialization;

namespace Dataflow.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    Admin = 1,
    Moderator = 2,
    Developer = 3,
    User = 4
}