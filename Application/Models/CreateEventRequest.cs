using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;

public class CreateEventRequest
{
    public string? Image { get; set; }

    public string? Title { get; set; }

    public DateTime EventDate { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}
