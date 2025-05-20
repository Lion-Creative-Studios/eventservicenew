using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;

/* Updated by chatgpt 40 generated code to correctly map with packages */
public class CreateEventRequest
{
    public string? Image { get; set; }
    public string? Title { get; set; }
    public DateTime EventDate { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }

    public List<CreatePackageDto> Packages { get; set; } = [];
}

public class CreatePackageDto
{
    public string Title { get; set; } = null!;
    public string? SeatingArrangement { get; set; }
    public string? Placement { get; set; }
    public decimal? Price { get; set; }
    public string? Currency { get; set; }
}

/* Updated by chatgpt 40 generated code to correctly map with packages */
