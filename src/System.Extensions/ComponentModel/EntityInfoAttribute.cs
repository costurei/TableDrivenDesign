namespace System.ComponentModel;

public class EntityInfoAttribute : Attribute
{
    public string AreaName { get; set; } = default!;

    public string SingleMetaName { get; set; } = default!;

    public string PluralMetaName { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public string SingleName { get; set; } = default!;

    public string PluralName { get; set; } = default!;
}
