using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Models;

public class RepositoryResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class RepositoryResult<T> : RepositoryResult
{
    public T? Result { get; set; }
}
