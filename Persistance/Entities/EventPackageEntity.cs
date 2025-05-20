using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.Entities;

/* Updated by chatgpt 4o generated code to correctly map data */
public class EventPackageEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey(nameof(Event))]
    public string EventId { get; set; } = null!;
    public EventEntity Event { get; set; } = null!;

    public PackageEntity Package { get; set; } = null!;
}

/* Updated by chatgpt 4o generated code to correctly map data */
