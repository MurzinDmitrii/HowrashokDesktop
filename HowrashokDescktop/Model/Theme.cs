using System;
using System.Collections.Generic;

namespace HowrashokDescktop.Model;

public partial class Theme
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
