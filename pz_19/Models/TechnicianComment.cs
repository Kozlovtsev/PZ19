using System;
using System.Collections.Generic;

namespace pz_19;

public partial class TechnicianComment
{
    public int CommentId { get; set; }

    public int RequestId { get; set; }

    public string CommentText { get; set; } = null!;

    public int SpecialistId { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual SpecialistsType Specialist { get; set; } = null!;
}
