using System;
using System.Collections.Generic;

namespace Search_MVC_SQL_Server.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; }

    public int IdCategory { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;
}
