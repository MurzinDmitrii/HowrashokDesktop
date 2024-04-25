using System;
using System.Collections.Generic;

namespace HowrashokDescktop.Model;

public partial class AdminPassword
{
    public int Id { get; set; }

    public byte[] Password { get; set; } = null!;

    public virtual Admin IdNavigation { get; set; } = null!;
}
