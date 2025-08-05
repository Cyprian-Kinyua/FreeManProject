using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? MemberId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly? InvoiceDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? AmountPaid { get; set; }

    public decimal? BalanceDue { get; set; }

    public string? InvoiceStatus { get; set; }

    public string? PaymentTerms { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
