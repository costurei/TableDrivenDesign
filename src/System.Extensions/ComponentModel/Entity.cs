using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.ComponentModel;

public abstract class Entity
{
    public int Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public DateTime CreationDate { get; set; }

    public Entity()
    {
        RowVersion = new byte[0];
    }
}
