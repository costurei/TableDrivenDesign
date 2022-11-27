namespace System.ComponentModel;

public abstract class EntityViewModel
{
    public int Id { get; set; }

    public byte[] RowVersion { get; set; } = default!;

    public DateTime CreationDate { get; set; }
}
