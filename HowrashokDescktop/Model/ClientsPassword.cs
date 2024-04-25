using System;
using System.Collections.Generic;

namespace HowrashokDescktop.Model;

public partial class ClientsPassword
{
    public int ClientId { get; set; }

    public string Password { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
