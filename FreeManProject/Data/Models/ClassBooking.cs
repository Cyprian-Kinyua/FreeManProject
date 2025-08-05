using System;
using System.Collections.Generic;

namespace FreeManProject.Data.Models;

public partial class ClassBooking
{
    public int BookingId { get; set; }

    public int? ClassId { get; set; }

    public int? MemberId { get; set; }

    public DateTime BookingDate { get; set; }

    public string? BookingStatus { get; set; }

    public string? PaymentStatus { get; set; }

    public decimal? AmountPaid { get; set; }

    public DateTime? CancellationDate { get; set; }

    public bool? AttendanceMarked { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
