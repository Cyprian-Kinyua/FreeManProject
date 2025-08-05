using System;
using System.Collections.Generic;
using FreeManProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeManProject.Data;

public partial class FreemanDbContext : DbContext
{
    public FreemanDbContext(DbContextOptions<FreemanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassBooking> ClassBookings { get; set; }

    public virtual DbSet<ClassType> ClassTypes { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentCategory> EquipmentCategories { get; set; }

    public virtual DbSet<EquipmentMaintenance> EquipmentMaintenances { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityType> FacilityTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberMembership> MemberMemberships { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PersonalTrainingSession> PersonalTrainingSessions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_as_cs")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.HasIndex(e => e.ClassTypeId, "class_type_id");

            entity.HasIndex(e => e.FacilityId, "facility_id");

            entity.HasIndex(e => e.TrainerId, "trainer_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CancellationReason)
                .HasColumnType("text")
                .HasColumnName("cancellation_reason");
            entity.Property(e => e.ClassDate).HasColumnName("class_date");
            entity.Property(e => e.ClassTypeId).HasColumnName("class_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentBookings)
                .HasDefaultValueSql("'0'")
                .HasColumnName("current_bookings");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.MaxParticipants).HasColumnName("max_participants");
            entity.Property(e => e.SpecialNotes)
                .HasColumnType("text")
                .HasColumnName("special_notes");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Scheduled','In Progress','Completed','Cancelled')")
                .HasColumnName("status");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WaitlistCount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("waitlist_count");
        });

        modelBuilder.Entity<ClassBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("class_bookings");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.AmountPaid)
                .HasPrecision(10, 2)
                .HasColumnName("amount_paid");
            entity.Property(e => e.AttendanceMarked)
                .HasDefaultValueSql("'0'")
                .HasColumnName("attendance_marked");
            entity.Property(e => e.BookingDate)
                .HasColumnType("datetime")
                .HasColumnName("booking_date");
            entity.Property(e => e.BookingStatus)
                .HasDefaultValueSql("'Confirmed'")
                .HasColumnType("enum('Confirmed','Waitlisted','Cancelled','No Show','Attended')")
                .HasColumnName("booking_status");
            entity.Property(e => e.CancellationDate)
                .HasColumnType("datetime")
                .HasColumnName("cancellation_date");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PaymentStatus)
                .HasDefaultValueSql("'Free'")
                .HasColumnType("enum('Free','Paid','Pending')")
                .HasColumnName("payment_status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ClassType>(entity =>
        {
            entity.HasKey(e => e.ClassTypeId).HasName("PRIMARY");

            entity.ToTable("class_types");

            entity.Property(e => e.ClassTypeId).HasColumnName("class_type_id");
            entity.Property(e => e.AdditionalFee)
                .HasPrecision(10, 2)
                .HasColumnName("additional_fee");
            entity.Property(e => e.CaloriesBurnedEstimate).HasColumnName("calories_burned_estimate");
            entity.Property(e => e.ClassTypeStatus)
                .HasDefaultValueSql("'Active'")
                .HasColumnType("enum('Active','Inactive')")
                .HasColumnName("class_type_status");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasColumnType("enum('Beginner','Intermediate','Advanced','All Levels')")
                .HasColumnName("difficulty_level");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.EquipmentRequired)
                .HasColumnType("text")
                .HasColumnName("equipment_required");
            entity.Property(e => e.MaxParticipants).HasColumnName("max_participants");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.EquipmentCategory, "FK_equipment_equipment_type");

            entity.HasIndex(e => e.SerialNumber, "serial_number").IsUnique();

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.EquipmentCategory).HasColumnName("equipment_category");
            entity.Property(e => e.EquipmentStatus)
                .HasDefaultValueSql("'Operational'")
                .HasColumnType("enum('Operational','Under Maintenance','Out of Order','Retired')")
                .HasColumnName("equipment_status");
            entity.Property(e => e.LastMaintenanceDate).HasColumnName("last_maintenance_date");
            entity.Property(e => e.LocationArea)
                .HasMaxLength(100)
                .HasColumnName("location_area");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NextMaintenanceDue).HasColumnName("next_maintenance_due");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.PurchasePrice)
                .HasPrecision(10, 2)
                .HasColumnName("purchase_price");
            entity.Property(e => e.SafetyNotes)
                .HasColumnType("text")
                .HasColumnName("safety_notes");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(100)
                .HasColumnName("serial_number");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UsageInstructions)
                .HasColumnType("text")
                .HasColumnName("usage_instructions");
            entity.Property(e => e.WarrantyExpiryDate).HasColumnName("warranty_expiry_date");
        });

        modelBuilder.Entity<EquipmentCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("equipment_category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<EquipmentMaintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PRIMARY");

            entity.ToTable("equipment_maintenance");

            entity.HasIndex(e => e.EquipmentId, "equipment_id");

            entity.HasIndex(e => e.StaffId, "staff_id");

            entity.Property(e => e.MaintenanceId).HasColumnName("maintenance_id");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.MaintenanceDate).HasColumnName("maintenance_date");
            entity.Property(e => e.MaintenanceType)
                .HasColumnType("enum('Routine','Repair','Emergency','Inspection')")
                .HasColumnName("maintenance_type");
            entity.Property(e => e.NextMaintenanceDate).HasColumnName("next_maintenance_date");
            entity.Property(e => e.PartsReplaced)
                .HasColumnType("text")
                .HasColumnName("parts_replaced");
            entity.Property(e => e.PerformedBy)
                .HasColumnType("enum('Internal','External')")
                .HasColumnName("performed_by");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Completed','In Progress','Scheduled')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .HasColumnName("vendor_name");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("PRIMARY");

            entity.ToTable("facilities");

            entity.HasIndex(e => e.FacilityTypeId, "facility_type_id");

            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.AreaSquareFeet)
                .HasPrecision(10, 2)
                .HasColumnName("area_square_feet");
            entity.Property(e => e.AvailabilityHoursEnd)
                .HasColumnType("time")
                .HasColumnName("availability_hours_end");
            entity.Property(e => e.AvailabilityHoursStart)
                .HasColumnType("time")
                .HasColumnName("availability_hours_start");
            entity.Property(e => e.BookingRequired)
                .HasDefaultValueSql("'0'")
                .HasColumnName("booking_required");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.FacilityTypeId).HasColumnName("facility_type_id");
            entity.Property(e => e.HourlyRate)
                .HasPrecision(10, 2)
                .HasColumnName("hourly_rate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SpecialEquipmentRequired)
                .HasColumnType("text")
                .HasColumnName("special_equipment_required");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Available'")
                .HasColumnType("enum('Available','Under Maintenance','Closed')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<FacilityType>(entity =>
        {
            entity.HasKey(e => e.FacilityTypeId).HasName("PRIMARY");

            entity.ToTable("facility_type");

            entity.Property(e => e.FacilityTypeId).HasColumnName("facility_type_id");
            entity.Property(e => e.FacilityName)
                .HasMaxLength(100)
                .HasColumnName("facility_name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PRIMARY");

            entity.ToTable("invoices");

            entity.HasIndex(e => e.InvoiceNumber, "invoice_number").IsUnique();

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.AmountPaid)
                .HasPrecision(10, 2)
                .HasColumnName("amount_paid");
            entity.Property(e => e.BalanceDue)
                .HasPrecision(10, 2)
                .HasColumnName("balance_due");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DiscountAmount)
                .HasPrecision(10, 2)
                .HasColumnName("discount_amount");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(100)
                .HasColumnName("invoice_number");
            entity.Property(e => e.InvoiceStatus)
                .HasDefaultValueSql("'Draft'")
                .HasColumnType("enum('Draft','Sent','Paid','Overdue','Cancelled')")
                .HasColumnName("invoice_status");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(100)
                .HasColumnName("payment_terms");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<InvoiceLineItem>(entity =>
        {
            entity.HasKey(e => e.LineItemId).HasName("PRIMARY");

            entity.ToTable("invoice_line_items");

            entity.HasIndex(e => e.InvoiceId, "invoice_id");

            entity.Property(e => e.LineItemId).HasColumnName("line_item_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ItemReferenceId).HasColumnName("item_reference_id");
            entity.Property(e => e.ItemType)
                .HasColumnType("enum('Membership','Training Session','Class','Product')")
                .HasColumnName("item_type");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberRegno).HasName("PRIMARY");

            entity.ToTable("member");

            entity.HasIndex(e => e.MemberId, "member_id").IsUnique();

            entity.HasIndex(e => e.MemberRegno, "member_regno").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phone_number").IsUnique();

            entity.Property(e => e.MemberRegno)
                .HasMaxLength(50)
                .HasColumnName("member_regno");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(100)
                .HasColumnName("emergency_contact_name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(13)
                .HasColumnName("emergency_contact_phone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MemberId)
                .ValueGeneratedOnAdd()
                .HasColumnName("member_id");
            entity.Property(e => e.MemberStatus)
                .HasMaxLength(10)
                .HasColumnName("member_status");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .HasColumnName("phone_number");
            entity.Property(e => e.PostalAddress).HasColumnName("postal_address");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.ProfilePhotoUrl)
                .HasMaxLength(250)
                .HasColumnName("profile_photo_url");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<MemberMembership>(entity =>
        {
            entity.HasKey(e => e.MemberMembershipId).HasName("PRIMARY");

            entity.ToTable("member_memberships");

            entity.HasIndex(e => e.MemberMembershipId, "member_membership_id").IsUnique();

            entity.HasIndex(e => e.MemberRegno, "member_regno");

            entity.HasIndex(e => e.MembershipTypeId, "membership_type_id");

            entity.Property(e => e.MemberMembershipId).HasColumnName("member_membership_id");
            entity.Property(e => e.AutoRenewal).HasColumnName("auto_renewal");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MemberMembershipStatus)
                .HasMaxLength(10)
                .HasColumnName("member_membership_status");
            entity.Property(e => e.MemberRegno)
                .HasMaxLength(50)
                .HasColumnName("member_regno");
            entity.Property(e => e.MembershipTypeId).HasColumnName("membership_type_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.MembershipTypeId).HasName("PRIMARY");

            entity.ToTable("membership_type");

            entity.HasIndex(e => e.MembershipTypeId, "membership_type_id").IsUnique();

            entity.Property(e => e.MembershipTypeId).HasColumnName("membership_type_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.DurationDays).HasColumnName("duration_days");
            entity.Property(e => e.MembershipTypeStatus)
                .HasMaxLength(10)
                .HasColumnName("membership_type_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payments");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.HasIndex(e => e.StaffId, "staff_id");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DiscountApplied)
                .HasPrecision(10, 2)
                .HasColumnName("discount_applied");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasColumnType("enum('Cash','Credit Card','Bank Transfer','Online','Mobile Payment')")
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("enum('Pending','Completed','Failed','Refunded','Partially Paid')")
                .HasColumnName("payment_status");
            entity.Property(e => e.PaymentType)
                .HasColumnType("enum('Membership Fee','Personal Training','Class Fee','Equipment Rental')")
                .HasColumnName("payment_type");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PersonalTrainingSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PRIMARY");

            entity.ToTable("personal_training_sessions");

            entity.HasIndex(e => e.FacilityId, "facility_id");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.HasIndex(e => e.TrainerId, "trainer_id");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.AmountCharged)
                .HasPrecision(10, 2)
                .HasColumnName("amount_charged");
            entity.Property(e => e.AttendanceStatus)
                .HasDefaultValueSql("'Absent'")
                .HasColumnType("enum('Present','Absent','Late')")
                .HasColumnName("attendance_status");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.Goals)
                .HasColumnType("text")
                .HasColumnName("goals");
            entity.Property(e => e.MemberFeedback)
                .HasColumnType("text")
                .HasColumnName("member_feedback");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("enum('Paid','Pending','Cancelled')")
                .HasColumnName("payment_status");
            entity.Property(e => e.PersonalTrainingSessionStatus)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Scheduled','In Progress','Completed','Cancelled','No Show')")
                .HasColumnName("personal_training_session_status");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.SessionDate).HasColumnName("session_date");
            entity.Property(e => e.SessionType)
                .HasColumnType("enum('Assessment','Regular Training','Specialized')")
                .HasColumnName("session_type");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.TrainerNotes)
                .HasColumnType("text")
                .HasColumnName("trainer_notes");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffRegno).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.HasIndex(e => e.PhoneNumber, "phone_number").IsUnique();

            entity.HasIndex(e => e.StaffId, "staff_id").IsUnique();

            entity.HasIndex(e => e.StaffRegno, "staff_regno").IsUnique();

            entity.Property(e => e.StaffRegno)
                .HasMaxLength(50)
                .HasColumnName("staff_regno");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Department)
                .HasMaxLength(20)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(100)
                .HasColumnName("emergency_contact_name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(13)
                .HasColumnName("emergency_contact_phone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .HasColumnName("phone_number");
            entity.Property(e => e.Position)
                .HasMaxLength(20)
                .HasColumnName("position");
            entity.Property(e => e.PostalAddress).HasColumnName("postal_address");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.ProfilePhotoUrl)
                .HasMaxLength(250)
                .HasColumnName("profile_photo_url");
            entity.Property(e => e.Salary)
                .HasPrecision(10)
                .HasColumnName("salary");
            entity.Property(e => e.StaffId)
                .ValueGeneratedOnAdd()
                .HasColumnName("staff_id");
            entity.Property(e => e.StaffStatus)
                .HasMaxLength(10)
                .HasColumnName("staff_status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PRIMARY");

            entity.ToTable("trainers");

            entity.HasIndex(e => e.StaffRegno, "staff_regno").IsUnique();

            entity.HasIndex(e => e.TrainerId, "trainer_id").IsUnique();

            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.Bio)
                .HasMaxLength(200)
                .HasColumnName("bio");
            entity.Property(e => e.ClassWeeklyFrequency).HasColumnName("class_weekly_frequency");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");
            entity.Property(e => e.HourlyRate).HasColumnName("hourly_rate");
            entity.Property(e => e.SessionsForMonth).HasColumnName("sessions_for_month");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasColumnName("specialization");
            entity.Property(e => e.StaffRegno)
                .HasMaxLength(50)
                .HasColumnName("staff_regno");
            entity.Property(e => e.TotalSessionsConducted).HasColumnName("total_sessions_conducted");
            entity.Property(e => e.TrainerStatus)
                .HasMaxLength(20)
                .HasColumnName("trainer_status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
