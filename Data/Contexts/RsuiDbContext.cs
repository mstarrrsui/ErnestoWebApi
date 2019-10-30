using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shared.TaskApi.Data.Entities
{
    public partial class RsuiDbContext : DbContext
    {
        public RsuiDbContext()
        {
        }

        public RsuiDbContext(DbContextOptions<RsuiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<TaskEntity> Task { get; set; }
        public virtual DbSet<TaskSubType> TaskSubType { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RSUITSTDB;Database=RSMSMIRROR;User Id=sa;Password=tropical;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasIndex(e => e.AccountingGroupTypeKey)
                    .HasName("idx_AccountingGroupTypeKey");

                entity.Property(e => e.DepartmentNumber).ValueGeneratedNever();

                entity.Property(e => e.ClaimsFlag).IsUnicode(false);

                entity.Property(e => e.DepartmentDescription).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("(1)");

                entity.Property(e => e.ProgramFlag).IsUnicode(false);

                entity.Property(e => e.ShortDescription).IsUnicode(false);

                entity.Property(e => e.UnderwritingFlag).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpRecordNumber)
                    .HasName("PK__EMPLOYEE__5CF9F418")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.EmpLastName)
                    .HasName("XIE3EMPLOYEE");

                entity.HasIndex(e => e.EmpUserProfile)
                    .HasName("idx_emp_user_profile");

                entity.HasIndex(e => e.UltiProEmployeeId)
                    .HasName("idx_UltiProEmployeeID");

                entity.HasIndex(e => new { e.EmpBranchNumber, e.EmpDepartmentNumber })
                    .HasName("idx_deptbranch");

                entity.Property(e => e.EmpRecordNumber).ValueGeneratedNever();

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.AlternateEmailAddress).IsUnicode(false);

                entity.Property(e => e.CeltypePhone).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.EmpActiveCode).IsUnicode(false);

                entity.Property(e => e.EmpEmailAddress).IsUnicode(false);

                entity.Property(e => e.EmpFaxnumber).IsUnicode(false);

                entity.Property(e => e.EmpFirstName).IsUnicode(false);

                entity.Property(e => e.EmpLastName).IsUnicode(false);

                entity.Property(e => e.EmpMiddleName).IsUnicode(false);

                entity.Property(e => e.EmpPrefix).IsUnicode(false);

                entity.Property(e => e.EmpUserProfile).IsUnicode(false);

                entity.Property(e => e.HomePhone).IsUnicode(false);

                entity.Property(e => e.Initials).IsUnicode(false);

                entity.Property(e => e.IsExecutive).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsExempt).HasDefaultValueSql("(1)");

                entity.Property(e => e.IsFireWarden).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFirstResponder).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsNotaryPublic).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOnPayroll).HasDefaultValueSql("(1)");

                entity.Property(e => e.IsSharePointPowerUser).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobCode).IsUnicode(false);

                entity.Property(e => e.NotifyPhone).IsUnicode(false);

                entity.Property(e => e.QuoteLetterSignatureText).IsUnicode(false);

                entity.Property(e => e.RsutypePhone).IsUnicode(false);

                entity.Property(e => e.Signature).IsUnicode(false);

                entity.Property(e => e.StateAbbreviation).IsUnicode(false);

                entity.Property(e => e.UltiProEmployeeId).IsUnicode(false);

                entity.Property(e => e.UpdatedByUltipro).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkPhone).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.DefaultAssistantNavigation)
                    .WithMany(p => p.InverseDefaultAssistantNavigation)
                    .HasForeignKey(d => d.DefaultAssistant)
                    .HasConstraintName("fk_DefaultAssistant");

                entity.HasOne(d => d.ReportingManager)
                    .WithMany(p => p.InverseReportingManager)
                    .HasForeignKey(d => d.ReportingManagerId)
                    .HasConstraintName("FK_EMPLOYEE_EMPLOYEE1");
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasIndex(e => e.BrokerCurrentlyAssignedTo)
                    .HasName("IDX_Task_BrokerCurrentlyAssignedTo");

                entity.HasIndex(e => e.SuspenseDate)
                    .HasName("IDX_SuspenseDate");

                entity.HasIndex(e => new { e.CurrentlyAssignedTo, e.CompleteDate })
                    .HasName("IDX_TaskAssignedToCompleteDate");

                entity.HasIndex(e => new { e.SubRecordNumber, e.DocRefNumber })
                    .HasName("idx_SubRecAndDocRefNumber");

                entity.HasIndex(e => new { e.SuspensedBy, e.SuspensedOn })
                    .HasName("IDX_SuspensedBy_SuspensedOn");

                entity.HasIndex(e => new { e.CurrentTaskType, e.CurrentlyAssignedTo, e.CompletedBy })
                    .HasName("IDX_CompletedBy");

                entity.HasIndex(e => new { e.TaskId, e.CurrentTaskType, e.SuspenseDate, e.ClaimKey })
                    .HasName("idx_task_claimkey_Includes");

                entity.HasIndex(e => new { e.TaskId, e.SubRecordNumber, e.CurrentlyAssignedTo, e.CurrentSubType, e.CreateDate, e.CompleteDate, e.SuspenseDate, e.IsHighPriority, e.IsRead, e.DocRefNumber, e.VersionTimestamp, e.LastModifiedDate, e.CurrentTaskType })
                    .HasName("IDX_CurrentTaskType");

                entity.Property(e => e.ClosedWithNoIssue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DocRefNumber).IsUnicode(false);

                entity.Property(e => e.LastBrokerNote).IsUnicode(false);

                entity.Property(e => e.LastNote).IsUnicode(false);

                entity.Property(e => e.VersionTimestamp).HasDefaultValueSql("(((1)/(1))/(1901))");

                entity.HasOne(d => d.CompletedByNavigation)
                    .WithMany(p => p.TaskCompletedByNavigation)
                    .HasForeignKey(d => d.CompletedBy)
                    .HasConstraintName("FK_Task_Employee3");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TaskCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Employee2");

                entity.HasOne(d => d.CurrentSubTypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CurrentSubType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskSubType");

                entity.HasOne(d => d.CurrentTaskTypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CurrentTaskType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskType");

                entity.HasOne(d => d.CurrentlyAssignedToNavigation)
                    .WithMany(p => p.TaskCurrentlyAssignedToNavigation)
                    .HasForeignKey(d => d.CurrentlyAssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Employee1");

                entity.HasOne(d => d.SuspensedByNavigation)
                    .WithMany(p => p.TaskSuspensedByNavigation)
                    .HasForeignKey(d => d.SuspensedBy)
                    .HasConstraintName("FK_Task_SuspenseEmployee");
            });

            modelBuilder.Entity<TaskSubType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.TaskSubType)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskSubType_TaskType");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });
        }
    }
}
