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

    public virtual DbSet<class> classes { get; set; }

    public virtual DbSet<class_booking> class_bookings { get; set; }

    public virtual DbSet<class_type> class_types { get; set; }

    public virtual DbSet<equipment> equipment { get; set; }

    public virtual DbSet<equipment_category> equipment_categories { get; set; }

    public virtual DbSet<equipment_maintenance> equipment_maintenances { get; set; }

    public virtual DbSet<facility> facilities { get; set; }

    public virtual DbSet<facility_type> facility_types { get; set; }

    public virtual DbSet<invoice> invoices { get; set; }

    public virtual DbSet<invoice_line_item> invoice_line_items { get; set; }

    public virtual DbSet<member> members { get; set; }

    public virtual DbSet<member_membership> member_memberships { get; set; }

    public virtual DbSet<membership_type> membership_types { get; set; }

    public virtual DbSet<payment> payments { get; set; }

    public virtual DbSet<personal_training_session> personal_training_sessions { get; set; }

    public virtual DbSet<staff> staff { get; set; }

    public virtual DbSet<trainer> trainers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_as_cs")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<class>(entity =>
        {
            entity.HasKey(e => e.class_id).HasName("PRIMARY");

            entity.HasIndex(e => e.class_type_id, "class_type_id");

            entity.HasIndex(e => e.facility_id, "facility_id");

            entity.HasIndex(e => e.trainer_id, "trainer_id");

            entity.Property(e => e.cancellation_reason).HasColumnType("text");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.current_bookings).HasDefaultValueSql("'0'");
            entity.Property(e => e.end_time).HasColumnType("time");
            entity.Property(e => e.special_notes).HasColumnType("text");
            entity.Property(e => e.start_time).HasColumnType("time");
            entity.Property(e => e.status)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Scheduled','In Progress','Completed','Cancelled')");
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.waitlist_count).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<class_booking>(entity =>
        {
            entity.HasKey(e => e.booking_id).HasName("PRIMARY");

            entity.HasIndex(e => e.class_id, "class_id");

            entity.HasIndex(e => e.member_id, "member_id");

            entity.Property(e => e.amount_paid).HasPrecision(10, 2);
            entity.Property(e => e.attendance_marked).HasDefaultValueSql("'0'");
            entity.Property(e => e.booking_date).HasColumnType("datetime");
            entity.Property(e => e.booking_status)
                .HasDefaultValueSql("'Confirmed'")
                .HasColumnType("enum('Confirmed','Waitlisted','Cancelled','No Show','Attended')");
            entity.Property(e => e.cancellation_date).HasColumnType("datetime");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.payment_status)
                .HasDefaultValueSql("'Free'")
                .HasColumnType("enum('Free','Paid','Pending')");
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<class_type>(entity =>
        {
            entity.HasKey(e => e.class_type_id).HasName("PRIMARY");

            entity.Property(e => e.additional_fee).HasPrecision(10, 2);
            entity.Property(e => e.class_type_status)
                .HasDefaultValueSql("'Active'")
                .HasColumnType("enum('Active','Inactive')");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.difficulty_level).HasColumnType("enum('Beginner','Intermediate','Advanced','All Levels')");
            entity.Property(e => e.equipment_required).HasColumnType("text");
            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<equipment>(entity =>
        {
            entity.HasKey(e => e.equipment_id).HasName("PRIMARY");

            entity.HasIndex(e => e.equipment_category, "FK_equipment_equipment_type");

            entity.HasIndex(e => e.serial_number, "serial_number").IsUnique();

            entity.Property(e => e.brand).HasMaxLength(100);
            entity.Property(e => e.equipment_status)
                .HasDefaultValueSql("'Operational'")
                .HasColumnType("enum('Operational','Under Maintenance','Out of Order','Retired')");
            entity.Property(e => e.location_area).HasMaxLength(100);
            entity.Property(e => e.model).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.purchase_price).HasPrecision(10, 2);
            entity.Property(e => e.safety_notes).HasColumnType("text");
            entity.Property(e => e.serial_number).HasMaxLength(100);
            entity.Property(e => e.usage_instructions).HasColumnType("text");
        });

        modelBuilder.Entity<equipment_category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("PRIMARY");

            entity.ToTable("equipment_category");

            entity.Property(e => e.category_name).HasMaxLength(100);
        });

        modelBuilder.Entity<equipment_maintenance>(entity =>
        {
            entity.HasKey(e => e.maintenance_id).HasName("PRIMARY");

            entity.ToTable("equipment_maintenance");

            entity.HasIndex(e => e.equipment_id, "equipment_id");

            entity.HasIndex(e => e.staff_id, "staff_id");

            entity.Property(e => e.cost).HasPrecision(10, 2);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.maintenance_type).HasColumnType("enum('Routine','Repair','Emergency','Inspection')");
            entity.Property(e => e.parts_replaced).HasColumnType("text");
            entity.Property(e => e.performed_by).HasColumnType("enum('Internal','External')");
            entity.Property(e => e.status)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Completed','In Progress','Scheduled')");
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.vendor_name).HasMaxLength(100);
        });

        modelBuilder.Entity<facility>(entity =>
        {
            entity.HasKey(e => e.facility_id).HasName("PRIMARY");

            entity.HasIndex(e => e.facility_type_id, "facility_type_id");

            entity.Property(e => e.area_square_feet).HasPrecision(10, 2);
            entity.Property(e => e.availability_hours_end).HasColumnType("time");
            entity.Property(e => e.availability_hours_start).HasColumnType("time");
            entity.Property(e => e.booking_required).HasDefaultValueSql("'0'");
            entity.Property(e => e.hourly_rate).HasPrecision(10, 2);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.special_equipment_required).HasColumnType("text");
            entity.Property(e => e.status)
                .HasDefaultValueSql("'Available'")
                .HasColumnType("enum('Available','Under Maintenance','Closed')");
        });

        modelBuilder.Entity<facility_type>(entity =>
        {
            entity.HasKey(e => e.facility_type_id).HasName("PRIMARY");

            entity.ToTable("facility_type");

            entity.Property(e => e.facility_name).HasMaxLength(100);
        });

        modelBuilder.Entity<invoice>(entity =>
        {
            entity.HasKey(e => e.invoice_id).HasName("PRIMARY");

            entity.HasIndex(e => e.invoice_number, "invoice_number").IsUnique();

            entity.HasIndex(e => e.member_id, "member_id");

            entity.Property(e => e.amount_paid).HasPrecision(10, 2);
            entity.Property(e => e.balance_due).HasPrecision(10, 2);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.discount_amount).HasPrecision(10, 2);
            entity.Property(e => e.invoice_number).HasMaxLength(100);
            entity.Property(e => e.invoice_status)
                .HasDefaultValueSql("'Draft'")
                .HasColumnType("enum('Draft','Sent','Paid','Overdue','Cancelled')");
            entity.Property(e => e.notes).HasColumnType("text");
            entity.Property(e => e.payment_terms).HasMaxLength(100);
            entity.Property(e => e.subtotal).HasPrecision(10, 2);
            entity.Property(e => e.total_amount).HasPrecision(10, 2);
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<invoice_line_item>(entity =>
        {
            entity.HasKey(e => e.line_item_id).HasName("PRIMARY");

            entity.HasIndex(e => e.invoice_id, "invoice_id");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.item_type).HasColumnType("enum('Membership','Training Session','Class','Product')");
            entity.Property(e => e.total_price).HasPrecision(10, 2);
            entity.Property(e => e.unit_price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<member>(entity =>
        {
            entity.HasKey(e => e.member_regno).HasName("PRIMARY");

            entity.ToTable("member");

            entity.HasIndex(e => e.member_id, "member_id").IsUnique();

            entity.HasIndex(e => e.member_regno, "member_regno").IsUnique();

            entity.HasIndex(e => e.phone_number, "phone_number").IsUnique();

            entity.Property(e => e.member_regno).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.emergency_contact_name).HasMaxLength(100);
            entity.Property(e => e.emergency_contact_phone).HasMaxLength(13);
            entity.Property(e => e.first_name).HasMaxLength(100);
            entity.Property(e => e.gender).HasMaxLength(10);
            entity.Property(e => e.last_name).HasMaxLength(100);
            entity.Property(e => e.member_id).ValueGeneratedOnAdd();
            entity.Property(e => e.member_status).HasMaxLength(10);
            entity.Property(e => e.phone_number).HasMaxLength(13);
            entity.Property(e => e.profile_photo_url).HasMaxLength(250);
        });

        modelBuilder.Entity<member_membership>(entity =>
        {
            entity.HasKey(e => e.member_membership_id).HasName("PRIMARY");

            entity.HasIndex(e => e.member_membership_id, "member_membership_id").IsUnique();

            entity.HasIndex(e => e.member_regno, "member_regno");

            entity.HasIndex(e => e.membership_type_id, "membership_type_id");

            entity.Property(e => e.member_membership_status).HasMaxLength(10);
            entity.Property(e => e.member_regno).HasMaxLength(50);
            entity.Property(e => e.payment_method).HasMaxLength(20);
        });

        modelBuilder.Entity<membership_type>(entity =>
        {
            entity.HasKey(e => e.membership_type_id).HasName("PRIMARY");

            entity.ToTable("membership_type");

            entity.HasIndex(e => e.membership_type_id, "membership_type_id").IsUnique();

            entity.Property(e => e.description).HasMaxLength(200);
            entity.Property(e => e.membership_type_status).HasMaxLength(10);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.price).HasPrecision(10);
        });

        modelBuilder.Entity<payment>(entity =>
        {
            entity.HasKey(e => e.payment_id).HasName("PRIMARY");

            entity.HasIndex(e => e.member_id, "member_id");

            entity.HasIndex(e => e.staff_id, "staff_id");

            entity.Property(e => e.amount).HasPrecision(10, 2);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.discount_applied).HasPrecision(10, 2);
            entity.Property(e => e.payment_date).HasColumnType("datetime");
            entity.Property(e => e.payment_method).HasColumnType("enum('Cash','Credit Card','Bank Transfer','Online','Mobile Payment')");
            entity.Property(e => e.payment_status).HasColumnType("enum('Pending','Completed','Failed','Refunded','Partially Paid')");
            entity.Property(e => e.payment_type).HasColumnType("enum('Membership Fee','Personal Training','Class Fee','Equipment Rental')");
            entity.Property(e => e.transaction_id).HasMaxLength(100);
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<personal_training_session>(entity =>
        {
            entity.HasKey(e => e.session_id).HasName("PRIMARY");

            entity.HasIndex(e => e.facility_id, "facility_id");

            entity.HasIndex(e => e.member_id, "member_id");

            entity.HasIndex(e => e.trainer_id, "trainer_id");

            entity.Property(e => e.amount_charged).HasPrecision(10, 2);
            entity.Property(e => e.attendance_status)
                .HasDefaultValueSql("'Absent'")
                .HasColumnType("enum('Present','Absent','Late')");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.end_time).HasColumnType("time");
            entity.Property(e => e.goals).HasColumnType("text");
            entity.Property(e => e.member_feedback).HasColumnType("text");
            entity.Property(e => e.payment_status).HasColumnType("enum('Paid','Pending','Cancelled')");
            entity.Property(e => e.personal_training_session_status)
                .HasDefaultValueSql("'Scheduled'")
                .HasColumnType("enum('Scheduled','In Progress','Completed','Cancelled','No Show')");
            entity.Property(e => e.session_type).HasColumnType("enum('Assessment','Regular Training','Specialized')");
            entity.Property(e => e.start_time).HasColumnType("time");
            entity.Property(e => e.trainer_notes).HasColumnType("text");
            entity.Property(e => e.updated_at)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<staff>(entity =>
        {
            entity.HasKey(e => e.staff_regno).HasName("PRIMARY");

            entity.HasIndex(e => e.phone_number, "phone_number").IsUnique();

            entity.HasIndex(e => e.staff_id, "staff_id").IsUnique();

            entity.HasIndex(e => e.staff_regno, "staff_regno").IsUnique();

            entity.Property(e => e.staff_regno).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.department).HasMaxLength(20);
            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.emergency_contact_name).HasMaxLength(100);
            entity.Property(e => e.emergency_contact_phone).HasMaxLength(13);
            entity.Property(e => e.first_name).HasMaxLength(100);
            entity.Property(e => e.gender).HasMaxLength(10);
            entity.Property(e => e.last_name).HasMaxLength(100);
            entity.Property(e => e.phone_number).HasMaxLength(13);
            entity.Property(e => e.position).HasMaxLength(20);
            entity.Property(e => e.profile_photo_url).HasMaxLength(250);
            entity.Property(e => e.salary).HasPrecision(10);
            entity.Property(e => e.staff_id).ValueGeneratedOnAdd();
            entity.Property(e => e.staff_status).HasMaxLength(10);
        });

        modelBuilder.Entity<trainer>(entity =>
        {
            entity.HasKey(e => e.trainer_id).HasName("PRIMARY");

            entity.HasIndex(e => e.staff_regno, "staff_regno").IsUnique();

            entity.HasIndex(e => e.trainer_id, "trainer_id").IsUnique();

            entity.Property(e => e.bio).HasMaxLength(200);
            entity.Property(e => e.specialization).HasMaxLength(100);
            entity.Property(e => e.staff_regno).HasMaxLength(50);
            entity.Property(e => e.trainer_status).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
