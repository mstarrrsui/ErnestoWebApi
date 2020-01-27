using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Data.Contexts
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

        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<ClaimTeam> ClaimTeam { get; set; }
        public virtual DbSet<ClaimTeamXrefEmployee> ClaimTeamXrefEmployee { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CorporateGroup> CorporateGroup { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<InsuranceCompanies> InsuranceCompanies { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationXref> LocationXref { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PeopleAddress> PeopleAddress { get; set; }
        public virtual DbSet<PeopleCategory> PeopleCategory { get; set; }
        public virtual DbSet<PeopleLocationXref> PeopleLocationXref { get; set; }
        public virtual DbSet<PeoplePhone> PeoplePhone { get; set; }
        public virtual DbSet<PolicySymbol> PolicySymbol { get; set; }
        public virtual DbSet<ProfitCenter> ProfitCenter { get; set; }
        public virtual DbSet<QuoteBinder> QuoteBinder { get; set; }
        public virtual DbSet<ReferenceCategory> ReferenceCategory { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<TaskEntity> Task { get; set; }
        public virtual DbSet<TaskEventCode> TaskEventCode { get; set; }
        public virtual DbSet<TaskHistory> TaskHistory { get; set; }
        public virtual DbSet<TaskSubType> TaskSubType { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(e => e.BranchNumber)
                    .HasName("PK__BRANCHES__7720AD13");

                entity.Property(e => e.BranchNumber).ValueGeneratedNever();

                entity.Property(e => e.BranchDescription).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ClaimTeam>(entity =>
            {
                entity.HasKey(e => e.CtKey)
                    .HasName("PK__ClaimTeam__1786BA2A");

                entity.Property(e => e.CtDescr).IsUnicode(false);
            });

            modelBuilder.Entity<ClaimTeamXrefEmployee>(entity =>
            {
                entity.HasKey(e => e.CtxeKey)
                    .HasName("PK__ClaimTeamXrefEmp__196F029C");
            });

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasIndex(e => e.ClaimPolicyKey)
                    .HasName("IDX_ClaimPolicyKey");

                entity.HasIndex(e => e.Guid)
                    .HasName("UIX_Claims_GUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.ClaimKey, e.ClaimPolicyKey })
                    .HasName("IDX_ClaimKeyClaimPolicyKey");

                entity.HasIndex(e => new { e.ClaimNumber, e.ClaimOffice })
                    .HasName("idx_ClaimNumberOffice")
                    .IsUnique();

                entity.HasIndex(e => new { e.ClaimKey, e.ClaimPolicyKey, e.MasterClaimKey })
                    .HasName("idx_claims_masterclaimkey_Includes");

                entity.Property(e => e.AccidentAddress1).IsUnicode(false);

                entity.Property(e => e.AccidentAddress2).IsUnicode(false);

                entity.Property(e => e.AccidentCity).IsUnicode(false);

                entity.Property(e => e.AccidentState)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccidentZip).IsUnicode(false);

                entity.Property(e => e.As400claimNumber)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClaimStatus)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Companion).HasDefaultValueSql("(0)");

                entity.Property(e => e.Converted)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrossOverTypeKey).HasDefaultValueSql("(1)");

                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.InsuredLocationCode).IsUnicode(false);

                entity.Property(e => e.InvoiceNotes).IsUnicode(false);

                entity.Property(e => e.IsFlaggedForFraud).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsoreportComplete).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsoreportNumber).IsUnicode(false);

                entity.Property(e => e.LongDescription).IsUnicode(false);

                entity.Property(e => e.Master).HasDefaultValueSql("(0)");

                entity.Property(e => e.NoDeductible).HasDefaultValueSql("(0)");

                entity.Property(e => e.NoPayment).HasDefaultValueSql("(0)");

                entity.Property(e => e.NonScanableImageStored).HasDefaultValueSql("(0)");

                entity.Property(e => e.PotentialEeoccharge).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProRateExpenses).HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordOnly).HasDefaultValueSql("(0)");

                entity.Property(e => e.ReportToReinsurer).HasDefaultValueSql("(0)");

                entity.Property(e => e.ShortDescription).IsUnicode(false);

                entity.Property(e => e.SplitBills).HasDefaultValueSql("(0)");

                entity.Property(e => e.ThirdPartyDeductible).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.MasterClaimKeyNavigation)
                    .WithMany(p => p.InverseMasterClaimKeyNavigation)
                    .HasForeignKey(d => d.MasterClaimKey)
                    .HasConstraintName("FK_claims_claims");

                entity.HasOne(d => d.ModByNavigation)
                    .WithMany(p => p.ClaimsModByNavigation)
                    .HasForeignKey(d => d.ModBy)
                    .HasConstraintName("FK_Claims_EMPLOYEE");

                entity.HasOne(d => d.TpamonitorKeyNavigation)
                    .WithMany(p => p.ClaimsTpamonitorKeyNavigation)
                    .HasForeignKey(d => d.TpamonitorKey)
                    .HasConstraintName("FK_Claims_TPAMonitor");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanySkey)
                    .HasName("PK__COMPANY__6F4A8121");

                entity.HasIndex(e => e.CompanyType)
                    .HasName("XIF268COMPANY");

                entity.HasIndex(e => e.CorpGrpSkey)
                    .HasName("XIF470COMPANY");

                entity.HasIndex(e => e.ReinsType)
                    .HasName("XIF269COMPANY");

                entity.Property(e => e.CompanySkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CompanyPrefix).IsUnicode(false);

                entity.Property(e => e.DomicileCity).IsUnicode(false);

                entity.Property(e => e.DomicileStateAbbr)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FederalTaxId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HomeDirectory).IsUnicode(false);

                entity.Property(e => e.NaiccompanyCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Naicname).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.NextQuoteNumber).HasDefaultValueSql("((1000))");

                entity.Property(e => e.OldCompanyType).IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.WebPage).IsUnicode(false);
            });

            modelBuilder.Entity<CorporateGroup>(entity =>
            {
                entity.HasKey(e => e.CorpGrpSkey)
                    .HasName("PK__CORPORATE_GROUP__019E3B86");

                entity.HasIndex(e => e.OldCorpgroupNumber)
                    .HasName("XAK1CORPORATE_GROUP")
                    .IsUnique();

                entity.Property(e => e.CorpGrpSkey).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ContactName).IsUnicode(false);

                entity.Property(e => e.ContactTitle).IsUnicode(false);

                entity.Property(e => e.FaxNumber)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WebPage).IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasIndex(e => e.AccountingGroupTypeKey)
                    .HasName("idx_AccountingGroupTypeKey");

                entity.Property(e => e.DepartmentNumber).ValueGeneratedNever();

                entity.Property(e => e.ClaimsFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepartmentDescription).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("(1)");

                entity.Property(e => e.ProgramFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShortDescription).IsUnicode(false);

                entity.Property(e => e.UnderwritingFlag)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpRecordNumber)
                    .HasName("PK__EMPLOYEE__5CF9F418")
                    .IsClustered(false);

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

                entity.Property(e => e.EmpActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

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

                entity.Property(e => e.StateAbbreviation)
                    .IsUnicode(false)
                    .IsFixedLength();

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

                entity.HasOne(table => table.EmpDepartment)
                    .WithMany()
                    .HasForeignKey(table => table.EmpDepartmentNumber);
            });

            modelBuilder.Entity<InsuranceCompanies>(entity =>
            {
                entity.HasKey(e => e.CompanyRecordNumber)
                    .HasName("PK__INSURANCE_COMPAN__51300E55");

                entity.HasIndex(e => e.OrgNumber)
                    .HasName("XIF702INSURANCE_COMPANIES");

                entity.Property(e => e.CompanyRecordNumber).ValueGeneratedNever();

                entity.Property(e => e.Admitted)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CedeToRic).HasDefaultValueSql("(0)");

                entity.Property(e => e.CompanyCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.DecCompanyDescription).IsUnicode(false);

                entity.Property(e => e.SecondaryDescription).IsUnicode(false);

                entity.HasOne(d => d.CompanySkeyNavigation)
                    .WithMany(p => p.InsuranceCompanies)
                    .HasForeignKey(d => d.CompanySkey)
                    .HasConstraintName("FK_INSURANCE_COMPANIES_COMPANY");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationSkey)
                    .HasName("PK__LOCATION__76EBA2E9");

                entity.HasIndex(e => e.CompanySkey)
                    .HasName("XIF261LOCATION");

                entity.HasIndex(e => new { e.LocationSkey, e.CompanySkey, e.InternalName, e.ActiveCode, e.Mgaidentifier })
                    .HasName("IDX_ActiveMGAid");

                entity.Property(e => e.LocationSkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdmittedLiquorYn)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AuditEmailAddress).IsUnicode(false);

                entity.Property(e => e.DocucorpVersion).IsUnicode(false);

                entity.Property(e => e.InternalName).IsUnicode(false);

                entity.Property(e => e.LibraryVersion).IsUnicode(false);

                entity.Property(e => e.OldCompanyType).IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.RoyalNumber).IsUnicode(false);

                entity.Property(e => e.SurplusStampSignatureText).IsUnicode(false);

                entity.Property(e => e.TreatyFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CompanySkeyNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CompanySkey)
                    .HasConstraintName("FK__LOCATION__COMPAN__7ABC33CD");
            });

            modelBuilder.Entity<LocationXref>(entity =>
            {
                entity.HasKey(e => e.LocationXrefSkey)
                    .HasName("PK__LOCATION_XREF__5A846E65");

                entity.HasIndex(e => e.LocationSkey)
                    .HasName("XIF260LOCATION_XREF");

                entity.HasIndex(e => new { e.LocationSkey, e.DepartmentNumber, e.BranchNumber })
                    .HasName("XAK1LOCATION_XREF")
                    .IsUnique();

                entity.Property(e => e.LocationXrefSkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OldCompanyType).IsUnicode(false);

                entity.HasOne(d => d.LocationSkeyNavigation)
                    .WithMany(p => p.LocationXref)
                    .HasForeignKey(d => d.LocationSkey)
                    .HasConstraintName("FK__LOCATION___LOCAT__091F61BD");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PeopleSkey)
                    .HasName("PK__PEOPLE__14B10FFA");

                entity.HasIndex(e => e.PeopleType)
                    .HasName("XIF274PEOPLE");

                entity.Property(e => e.PeopleSkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssistantName).IsUnicode(false);

                entity.Property(e => e.ChildName1).IsUnicode(false);

                entity.Property(e => e.ChildName2).IsUnicode(false);

                entity.Property(e => e.ChildName3).IsUnicode(false);

                entity.Property(e => e.ChildName4).IsUnicode(false);

                entity.Property(e => e.ChildSex1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChildSex2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChildSex3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChildSex4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.EmailAddress1).IsUnicode(false);

                entity.Property(e => e.EmailAddress2).IsUnicode(false);

                entity.Property(e => e.EmailAddress3).IsUnicode(false);

                entity.Property(e => e.ExternalLogin).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.ManagerName).IsUnicode(false);

                entity.Property(e => e.Nickname).IsUnicode(false);

                entity.Property(e => e.OldPeopleType).IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Sex)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpouseName).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.PeopleTypeNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.PeopleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE__PEOPLE_T__178D7CA5");
            });

            modelBuilder.Entity<PeopleAddress>(entity =>
            {
                entity.HasKey(e => new { e.PeopleSkey, e.AddressType })
                    .HasName("PK__PEOPLE_ADDRESS__37D02F05");

                entity.HasIndex(e => e.PeopleSkey)
                    .HasName("XIF454PEOPLE_ADDRESS");

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.AddressTypeNavigation)
                    .WithMany(p => p.PeopleAddress)
                    .HasForeignKey(d => d.AddressType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_AD__ADDRE__3A779186");

                entity.HasOne(d => d.PeopleSkeyNavigation)
                    .WithMany(p => p.PeopleAddress)
                    .HasForeignKey(d => d.PeopleSkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_AD__PEOPL__23F3538A");
            });

            modelBuilder.Entity<PeopleCategory>(entity =>
            {
                entity.HasKey(e => new { e.PeopleSkey, e.CategorySkey })
                    .HasName("PK__PEOPLE_CATEGORY__3AAC9BB0");

                entity.HasIndex(e => e.PeopleSkey)
                    .HasName("XIF263PEOPLE_CATEGORY");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PeopleSkeyNavigation)
                    .WithMany(p => p.PeopleCategory)
                    .HasForeignKey(d => d.PeopleSkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_CA__PEOPL__26CFC035");
            });

            modelBuilder.Entity<PeopleLocationXref>(entity =>
            {
                entity.HasKey(e => new { e.PeopleSkey, e.LocationXrefSkey })
                    .HasName("PK__PEOPLE_LOCATION___2B354DF6");

                entity.HasIndex(e => e.LocationXrefSkey)
                    .HasName("XIF254PEOPLE_LOCATION_XREF");

                entity.HasIndex(e => e.PeopleSkey)
                    .HasName("XIF301PEOPLE_LOCATION_XREF");

                entity.Property(e => e.ActiveCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.LocationXrefSkeyNavigation)
                    .WithMany(p => p.PeopleLocationXref)
                    .HasForeignKey(d => d.LocationXrefSkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_LO__LOCAT__3E48226A");

                entity.HasOne(d => d.PeopleSkeyNavigation)
                    .WithMany(p => p.PeopleLocationXref)
                    .HasForeignKey(d => d.PeopleSkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_LO__PEOPL__24E777C3");
            });

            modelBuilder.Entity<PeoplePhone>(entity =>
            {
                entity.HasKey(e => new { e.PeopleSkey, e.PhoneType })
                    .HasName("PK__PEOPLE_PHONE__4341E1B1");

                entity.HasIndex(e => e.PeopleSkey)
                    .HasName("XIF455PEOPLE_PHONE");

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PeopleSkeyNavigation)
                    .WithMany(p => p.PeoplePhone)
                    .HasForeignKey(d => d.PeopleSkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_PH__PEOPL__22FF2F51");

                entity.HasOne(d => d.PhoneTypeNavigation)
                    .WithMany(p => p.PeoplePhone)
                    .HasForeignKey(d => d.PhoneType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEOPLE_PH__PHONE__3F3C46A3");
            });

            modelBuilder.Entity<PolicySymbol>(entity =>
            {
                entity.HasKey(e => e.SymbolSkey)
                    .HasName("PK__POLICY_SYMBOL__6AEFE058");

                entity.HasIndex(e => new { e.DepartmentNumber, e.OrgNumber })
                    .HasName("XIF473POLICY_SYMBOL");

                entity.Property(e => e.SymbolSkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClaimsFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodeDescription).IsUnicode(false);

                entity.Property(e => e.PolicyCode).IsUnicode(false);

                entity.Property(e => e.UnderwritingFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DepartmentNumberNavigation)
                    .WithMany(p => p.PolicySymbol)
                    .HasForeignKey(d => d.DepartmentNumber)
                    .HasConstraintName("FK_POLICY_SYMBOL_DEPARTMENTS");
            });

            modelBuilder.Entity<ProfitCenter>(entity =>
            {
                entity.HasKey(e => e.ProfitCenterKey)
                    .IsClustered(false);

                entity.Property(e => e.ProfitCenterName).IsUnicode(false);

                entity.Property(e => e.UltiProCode).IsUnicode(false);
            });

            modelBuilder.Entity<QuoteBinder>(entity =>
            {
                entity.HasKey(e => new { e.SubRecordNumber, e.QbSequenceNo })
                    .HasName("PK__QUOTE_BINDER__070DC770");

                entity.HasIndex(e => e.SubRecordNumber)
                    .HasName("XIF373QUOTE_BINDER");

                entity.Property(e => e.Coastal).HasDefaultValueSql("(0)");

                entity.Property(e => e.DecPageFileName).IsUnicode(false);

                entity.Property(e => e.DecPagePath).IsUnicode(false);

                entity.Property(e => e.DecPageTwoFilename).IsUnicode(false);

                entity.Property(e => e.DecPageTwoPath).IsUnicode(false);

                entity.Property(e => e.FormScheduleFileName).IsUnicode(false);

                entity.Property(e => e.FormSchedulePath).IsUnicode(false);

                entity.Property(e => e.ImportantNoticeFilename).IsUnicode(false);

                entity.Property(e => e.ImportantNoticePath).IsUnicode(false);

                entity.Property(e => e.InstallFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsExcess).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsIndication).HasDefaultValueSql("(0)");

                entity.Property(e => e.NyfreeTradeZone).HasDefaultValueSql("(0)");

                entity.Property(e => e.QbAdditionalInfo).IsUnicode(false);

                entity.Property(e => e.QbAdjustablePer).IsUnicode(false);

                entity.Property(e => e.QbCoverageComment).IsUnicode(false);

                entity.Property(e => e.QbDeductibleComment).IsUnicode(false);

                entity.Property(e => e.QbExcessComment).IsUnicode(false);

                entity.Property(e => e.QbLeadCompanyName).IsUnicode(false);

                entity.Property(e => e.QbLimitComment).IsUnicode(false);

                entity.Property(e => e.QbName).IsUnicode(false);

                entity.Property(e => e.QbOtherComment).IsUnicode(false);

                entity.Property(e => e.QbPremiumComment).IsUnicode(false);

                entity.Property(e => e.QbPrintTbdFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QbPurgeFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QbRemarks).IsUnicode(false);

                entity.Property(e => e.QbRevisionComment).IsUnicode(false);

                entity.Property(e => e.QbStatus)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QbType).IsUnicode(false);

                entity.Property(e => e.RejectTria)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RejectUim)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RsuiFormName).IsUnicode(false);

                entity.Property(e => e.UnderlyingFormName).IsUnicode(false);

                entity.Property(e => e.UnderlyingFormType)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VersionTimestamp).HasDefaultValueSql("(1 / 1 / 1900)");

                entity.HasOne(d => d.AssumedFromCompanySkeyNavigation)
                    .WithMany(p => p.QuoteBinder)
                    .HasForeignKey(d => d.AssumedFromCompanySkey)
                    .HasConstraintName("FK_QUOTE_BINDER_COMPANY");

                entity.HasOne(d => d.CompanyRecordNumberNavigation)
                    .WithMany(p => p.QuoteBinder)
                    .HasForeignKey(d => d.CompanyRecordNumber)
                    .HasConstraintName("FK__QUOTE_BIN__COMPA__08F60FE2");

                entity.HasOne(d => d.SubRecordNumberNavigation)
                    .WithMany(p => p.QuoteBinder)
                    .HasForeignKey(d => d.SubRecordNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QUOTE_BIN__SUB_R__09EA341B");
            });

            modelBuilder.Entity<ReferenceCategory>(entity =>
            {
                entity.HasKey(e => e.CategorySkey)
                    .HasName("PK__REFERENCE_CATEGO__1A69E950");

                entity.Property(e => e.CategorySkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.HasKey(e => e.TypeSkey)
                    .HasName("PK__REFERENCE_TYPE__2E11BAA1");

                entity.Property(e => e.TypeSkey).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LockedFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OldType).IsUnicode(false);

                entity.HasOne(d => d.CategorySkeyNavigation)
                    .WithMany(p => p.ReferenceType)
                    .HasForeignKey(d => d.CategorySkey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REFERENCE__CATEG__5418334F");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.SubRecordNumber)
                    .HasName("PK__SUBMISSION");

                entity.HasIndex(e => e.PriorSubRecordNumber)
                    .HasName("IDX_PriorSubRecordNumber");

                entity.HasIndex(e => e.SubInsuredName)
                    .HasName("IDX_SubInsuredName");

                entity.HasIndex(e => e.SubPolicyNumber)
                    .HasName("IDX_PolicyNumber");

                entity.HasIndex(e => new { e.DepartmentNumber, e.SubSubmissionNumber, e.SubRecordNumber })
                    .HasName("IDX_DeptSubNbrSubRecNbr");

                entity.HasIndex(e => new { e.SubRecordNumber, e.PeopleSkey, e.LocationSkey, e.CompanyRecordNumber, e.SubEffectiveDate, e.SubPolicySymbol, e.SubPolicyNumber, e.SubPolicySuffix, e.SubCancellationDate, e.SubInsuredName, e.CreateDate, e.IssuedDate, e.DepartmentNumber, e.SubCurrentExpirationDate, e.QbSequenceNo })
                    .HasName("IDX_DeptCurExpQBSeqNo");

                entity.Property(e => e.ClientSubmissionId).IsUnicode(false);

                entity.Property(e => e.HomeState)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InsuredState)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LocationAppointedBrokerName).IsUnicode(false);

                entity.Property(e => e.PriorStatusCode).IsUnicode(false);

                entity.Property(e => e.StatusCode).IsUnicode(false);

                entity.Property(e => e.SubComment).IsUnicode(false);

                entity.Property(e => e.SubCoverageInForce)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubDoProfitOrNonProfit)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubDoProgramApplies)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubInsuredCity).IsUnicode(false);

                entity.Property(e => e.SubInsuredName).IsUnicode(false);

                entity.Property(e => e.SubNoticeSent)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubPurgeFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubRenewalCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubRenewalFlag)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsiInd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VersionTimestamp).HasDefaultValueSql("(((1)/(1))/(1900))");

                entity.HasOne(d => d.AccountContact)
                    .WithMany(p => p.SubmissionAccountContact)
                    .HasForeignKey(d => d.AccountContactId)
                    .HasConstraintName("FK_SubmissionAccountContactPeople");

                entity.HasOne(d => d.CompanyRecordNumberNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.CompanyRecordNumber)
                    .HasConstraintName("FK__SUBMISSIO__COMPA__5FD33367");

                entity.HasOne(d => d.EmpRecordNumberNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.EmpRecordNumber)
                    .HasConstraintName("FK__SUBMISSIO__EMP_R__6497E884");

                entity.HasOne(d => d.LocationSkeyNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.LocationSkey)
                    .HasConstraintName("FK__SUBMISSIO__LOCAT__62AFA012");

                entity.HasOne(d => d.PeopleSkeyNavigation)
                    .WithMany(p => p.SubmissionPeopleSkeyNavigation)
                    .HasForeignKey(d => d.PeopleSkey)
                    .HasConstraintName("FK__SUBMISSIO__PEOPL__63A3C44B");

                entity.HasOne(d => d.SubCompanyTypeNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.SubCompanyType)
                    .HasConstraintName("FK_SUBMISSION_REFERENCE_TYPE");

                entity.HasOne(d => d.SubPolicySymbolNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.SubPolicySymbol)
                    .HasConstraintName("FK__SUBMISSIO__SUB_P__5EDF0F2E");
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

                entity.HasOne(d => d.BrokerCurrentlyAssignedToNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.BrokerCurrentlyAssignedTo)
                    .HasConstraintName("FK_Task_PEOPLE");

                entity.HasOne(d => d.ClaimKeyNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ClaimKey)
                    .HasConstraintName("FK_Task_ClaimKey");

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

                entity.HasOne(d => d.SubRecordNumberNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.SubRecordNumber)
                    .HasConstraintName("FK_Task_Submission");

                entity.HasOne(d => d.SuspensedByNavigation)
                    .WithMany(p => p.TaskSuspensedByNavigation)
                    .HasForeignKey(d => d.SuspensedBy)
                    .HasConstraintName("FK_Task_SuspenseEmployee");
            });

            modelBuilder.Entity<TaskEventCode>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.HasIndex(e => new { e.AssignedBy, e.CreateDate })
                    .HasName("IDX_AssignedBy_CreateDate");

                entity.HasIndex(e => new { e.BrokerAssignedTo, e.BrokerCreatedBy })
                    .HasName("IDX_TaskHistory_PeopleSkey");

                entity.HasIndex(e => new { e.CreateDate, e.TaskId })
                    .HasName("_dta_index_TaskHistory_17_231697365__K5_9");

                entity.HasIndex(e => new { e.CreateDate, e.TaskId, e.TaskHistoryId })
                    .HasName("_dta_index_TaskHistory_17_231697365__K5_K1_9");

                entity.Property(e => e.BrokerNote).IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.VersionTimestamp).HasDefaultValueSql("(((1)/(1))/(1901))");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.TaskHistoryAssignedByNavigation)
                    .HasForeignKey(d => d.AssignedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistory_Employee2");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.TaskHistoryAssignedToNavigation)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_TaskHistory_Employee1");

                entity.HasOne(d => d.BrokerAssignedToNavigation)
                    .WithMany(p => p.TaskHistoryBrokerAssignedToNavigation)
                    .HasForeignKey(d => d.BrokerAssignedTo)
                    .HasConstraintName("FK_TaskHistory_PEOPLE");

                entity.HasOne(d => d.BrokerCreatedByNavigation)
                    .WithMany(p => p.TaskHistoryBrokerCreatedByNavigation)
                    .HasForeignKey(d => d.BrokerCreatedBy)
                    .HasConstraintName("FK_TaskHistory_PEOPLE2");

                entity.HasOne(d => d.TaskEvent)
                    .WithMany(p => p.TaskHistory)
                    .HasForeignKey(d => d.TaskEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistory_TaskEventCode");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskHistory)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistory_Task");

                entity.HasOne(d => d.TaskSubType)
                    .WithMany(p => p.TaskHistory)
                    .HasForeignKey(d => d.TaskSubTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistory_TaskSubType");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.TaskHistory)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskHistory_TaskType");
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

                entity.HasOne(d => d.ProfitCenterKeyNavigation)
                    .WithMany(p => p.TaskType)
                    .HasForeignKey(d => d.ProfitCenterKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskType_ProfitCenter");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
