using System;
using System.Collections.Generic;

namespace pz_19;

public partial class Request
{
    public int RequestId { get; set; }

    public DateTime? RequestDate { get; set; }

    public int? HomeTechId { get; set; }

    public string? FaultType { get; set; }

    public int? UserId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? CompletionDate { get; set; }

    public int? SpecialistId { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual HomeTech? HomeTech { get; set; }

    public virtual SpecialistsType? Specialist { get; set; }

    public virtual Status? Status { get; set; }

    public virtual ICollection<TechnicianComment> TechnicianComments { get; set; } = new List<TechnicianComment>();
}
