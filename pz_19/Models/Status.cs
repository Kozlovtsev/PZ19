using System;
using System.Collections.Generic;

namespace pz_19;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
