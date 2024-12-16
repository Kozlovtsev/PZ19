using System;
using System.Collections.Generic;

namespace pz_19;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int SpecialistId { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual SpecialistsType Specialist { get; set; } = null!;
}
