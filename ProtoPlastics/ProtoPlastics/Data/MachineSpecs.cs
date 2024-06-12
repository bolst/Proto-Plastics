using System.Text.Json.Serialization;

namespace ProtoPlastics.Data
{
    public class ClampSpec
    {
        [JsonPropertyName("label")] public string? Label { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
        [JsonPropertyName("unit")] public string? Unit { get; set; }
    }

    public class InjectionSpec
    {
        [JsonPropertyName("label")] public string? Label { get; set; }
        [JsonPropertyName("value")] public string? Value { get; set; }
        [JsonPropertyName("unit")] public string? Unit { get; set; }
    }

    public class MachineSpecs
    {
        [JsonPropertyName("specs")] public List<Spec>? Specs { get; set; }
    }

    public class Spec
    {
        [JsonPropertyName("name")] public string? Name { get; set; }

        [JsonPropertyName("clamp specs")] public List<ClampSpec>? ClampSpecs { get; set; }

        [JsonPropertyName("injection specs")] public List<InjectionSpec>? InjectionSpecs { get; set; }
    }


}