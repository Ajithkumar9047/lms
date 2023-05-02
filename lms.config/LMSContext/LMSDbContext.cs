using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using lms.config.Entities;

namespace lms.config.LMSContext;

public partial class LMSDbContext : DbContext
{
    public LMSDbContext()
    {
    }

    public LMSDbContext(DbContextOptions<LMSDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassifiedLead> ClassifiedLeads { get; set; }

    public virtual DbSet<CrmPushLog> CrmPushLogs { get; set; }

    public virtual DbSet<DealerMasterList> DealerMasterLists { get; set; }

    public virtual DbSet<DealerMediationControl> DealerMediationControls { get; set; }

    public virtual DbSet<DmsPushLog> DmsPushLogs { get; set; }

    public virtual DbSet<EmsPushLog> EmsPushLogs { get; set; }

    public virtual DbSet<ErrorLead> ErrorLeads { get; set; }

    public virtual DbSet<FinancePushLog> FinancePushLogs { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    public virtual DbSet<LeadLog> LeadLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=EPAGE-LD22-142;database=LMSDB;User Id=LMS_LOGIN; Password=Ajith@1997;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassifiedLead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classifi__3213E83F9C35887E");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Lead).WithMany(p => p.ClassifiedLeads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__classifie__lead___4CA06362");
        });

        modelBuilder.Entity<CrmPushLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__crm_push__3213E83FC10B6361");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Lead).WithMany(p => p.CrmPushLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__crm_push___lead___60A75C0F");
        });

        modelBuilder.Entity<DealerMediationControl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dealer_m__3213E83F801D71AE");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DmsPushLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dms_push__3213E83F9AD0678A");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Lead).WithMany(p => p.DmsPushLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dms_push___lead___5BE2A6F2");
        });

        modelBuilder.Entity<EmsPushLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ems_push__3213E83F57A30780");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Lead).WithMany(p => p.EmsPushLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ems_push___lead___571DF1D5");
        });

        modelBuilder.Entity<ErrorLead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__error_le__3213E83FBAF616AE");

            entity.HasOne(d => d.LeadLog).WithMany(p => p.ErrorLeads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__error_lea__lead___3C69FB99");
        });

        modelBuilder.Entity<FinancePushLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__finance___3213E83F209B10A6");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Lead).WithMany(p => p.FinancePushLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__finance_p__lead___52593CB8");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__leads__3213E83F2C242269");

            entity.HasOne(d => d.LeadLog).WithMany(p => p.Leads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__leads__lead_log___403A8C7D");
        });

        modelBuilder.Entity<LeadLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_id_lead_logs");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Error).HasDefaultValueSql("((0))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
