using System;
using System.Collections.Generic;
using CardiologyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CardiologyApp;

public partial class CardiologyDepartmentContext : DbContext
{
    public CardiologyDepartmentContext()
    {
    }

    public CardiologyDepartmentContext(DbContextOptions<CardiologyDepartmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<HistoryPreparation> HistoryPreparations { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<MedEquipment> MedEquipments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientLog> PatientLogs { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Preparation> Preparations { get; set; }

    public virtual DbSet<PreparationLog> PreparationLogs { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    public virtual DbSet<WardMedEquipment> WardMedEquipments { get; set; }
    public virtual DbSet<LargestPreparationUsageResult> LargestPreparationUsageResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CardiologyDepartment;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LargestPreparationUsageResult>().HasNoKey();

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__F39A317C8F3B22E5");

            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.FullName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("full_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("phone_Number");
            entity.Property(e => e.PositionId).HasColumnName("position_ID");

            entity.HasOne(d => d.Position).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Doctor__position__45F365D3");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__History__096FB7017FAE3E59");

            entity.ToTable("History");

            entity.Property(e => e.HistoryId).HasColumnName("history_ID");
            entity.Property(e => e.Diagnos)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("diagnos");
            entity.Property(e => e.DischargeDate).HasColumnName("discharge_Date");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_ID");
            entity.Property(e => e.NumberHistory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number_History");
            entity.Property(e => e.PatientId).HasColumnName("patient_ID");
            entity.Property(e => e.ReceiptDate).HasColumnName("receipt_Date");
            entity.Property(e => e.WardId).HasColumnName("ward_ID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Histories)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__History__doctor___4D94879B");

            entity.HasOne(d => d.Patient).WithMany(p => p.Histories)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__History__patient__4CA06362");

            entity.HasOne(d => d.Ward).WithMany(p => p.Histories)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__History__ward_ID__4E88ABD4");
        });

        modelBuilder.Entity<HistoryPreparation>(entity =>
        {
            entity.HasKey(e => e.HistoryPreparationId).HasName("PK__History___37E125D26353E137");

            entity.ToTable("History_Preparation", tb => tb.HasTrigger("historyPreparationCreateTrigger"));

            entity.Property(e => e.HistoryPreparationId).HasColumnName("history_Preparation_ID");
            entity.Property(e => e.HistoryId).HasColumnName("history_ID");
            entity.Property(e => e.PreparationId).HasColumnName("preparation_ID");

            entity.HasOne(d => d.History).WithMany(p => p.HistoryPreparations)
                .HasForeignKey(d => d.HistoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__History_P__histo__5629CD9C");

            entity.HasOne(d => d.Preparation).WithMany(p => p.HistoryPreparations)
                .HasForeignKey(d => d.PreparationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__History_P__prepa__571DF1D5");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufact__16306DF83AA491DB");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(122)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("company_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("phone_Number");
        });

        modelBuilder.Entity<MedEquipment>(entity =>
        {
            entity.HasKey(e => e.MedEquipmentId).HasName("PK__Med_Equi__9CCBEC69FAB725D4");

            entity.ToTable("Med_Equipment");

            entity.Property(e => e.MedEquipmentId).HasColumnName("med_Equipment_ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.WearLevel).HasColumnName("wear_Level");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__4D45DFBEAA877E14");

            entity.ToTable("Patient", tb => tb.HasTrigger("patientsLogs"));

            entity.Property(e => e.PatientId).HasColumnName("patient_ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FullName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("full_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("phone_Number");
        });

        modelBuilder.Entity<PatientLog>(entity =>
        {
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__99A3EA2C48D15722");

            entity.ToTable("Position");

            entity.Property(e => e.PositionId).HasColumnName("position_ID");
            entity.Property(e => e.Position1)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("position");
        });

        modelBuilder.Entity<Preparation>(entity =>
        {
            entity.HasKey(e => e.PreparationId).HasName("PK__Preparat__7705015858C0612B");

            entity.ToTable("Preparation", tb => tb.HasTrigger("createPreparationTrigger"));

            entity.Property(e => e.PreparationId).HasColumnName("preparation_ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DateReceipt).HasColumnName("date_Receipt");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_Date");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_ID");
            entity.Property(e => e.Price)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Preparations)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Preparati__manuf__534D60F1");
        });

        modelBuilder.Entity<PreparationLog>(entity =>
        {
            entity.Property(e => e.AttemptDate).HasColumnType("datetime");
            entity.Property(e => e.AttemptType).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(255);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PK__Ward__396CB5D54BA91ABE");

            entity.ToTable("Ward");

            entity.Property(e => e.WardId).HasColumnName("ward_ID");
            entity.Property(e => e.NumBeds).HasColumnName("num_Beds");
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Price)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.WardType)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ward_Type");
        });

        modelBuilder.Entity<WardMedEquipment>(entity =>
        {
            entity.HasKey(e => e.WardMedEquipmentId).HasName("PK__Ward_Med__B15D922E2C702BC2");

            entity.ToTable("Ward_Med_Equipment");

            entity.Property(e => e.WardMedEquipmentId).HasColumnName("ward_Med_Equipment_ID");
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.EntryDate).HasColumnName("entry_Date");
            entity.Property(e => e.MedEquipmentId).HasColumnName("medEquipment_ID");
            entity.Property(e => e.ReviewDate).HasColumnName("review_Date");
            entity.Property(e => e.WardId).HasColumnName("ward_ID");

            entity.HasOne(d => d.MedEquipment).WithMany(p => p.WardMedEquipments)
                .HasForeignKey(d => d.MedEquipmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Ward_Med___medEq__5CD6CB2B");

            entity.HasOne(d => d.Ward).WithMany(p => p.WardMedEquipments)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Ward_Med___ward___5BE2A6F2");
        });

        base.OnModelCreating(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
