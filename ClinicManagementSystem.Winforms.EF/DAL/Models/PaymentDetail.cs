using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PaymentDetail
{
    public int PaymentDetailId { get; set; }

    public int PaymentId { get; set; }

    public string ItemType { get; set; }

    public int? ItemId { get; set; }

    public string Description { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? Amount { get; set; }

    public virtual Payment Payment { get; set; }
}
