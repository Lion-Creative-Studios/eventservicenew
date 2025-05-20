using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;

public class Event
{
    public string Id { get; set; } = null!;

    public string? Image { get; set; }

    public string? Title { get; set; }

    public DateTime EventDate { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}
