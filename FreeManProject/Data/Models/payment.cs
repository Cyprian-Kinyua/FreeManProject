using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? MemberId { get; set; }

    public string? PaymentType { get; set; }

    public int? ReferenceId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? PaymentStatus { get; set; }

    public string? TransactionId { get; set; }

    public string? Description { get; set; }

    public decimal? DiscountApplied { get; set; }

    public int? StaffId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
