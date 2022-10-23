using System.ComponentModel.DataAnnotations;

namespace System.ComponentModel;

public abstract class Entity
{
    public int Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = default!;
}
