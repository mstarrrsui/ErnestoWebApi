Setting Up Our Tables from Command Line

    dotnet ef dbcontext scaffold "Server=RSUITSTDB;Database=RSMSMIRROR;User Id=sa;Password=tropical;" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --output-dir Data/EntitiesDefault --context-dir Data/ContextsDefault --context RsuiDbContext --table REFERENCE_TYPE --table REFERENCE_CATEGORY --table BRANCHES --table DEPARTMENTS --table EMPLOYEE --table Task --table TaskType --table TaskSubType --table TaskHistory --table TaskEventCode --table ClaimTeam --table ClaimTeamXrefEmployee --table PEOPLE --table PEOPLE_ADDRESS --table PEOPLE_CATEGORY --table PEOPLE_LOCATION_XREF --table PEOPLE_PHONE --table LOCATION --table LOCATION_XREF --table COMPANY --table CORPORATE_GROUP --table SUBMISSION --table QUOTE_BINDER --table claims --table POLICY_SYMBOL --table INSURANCE_COMPANIES --table ProfitCenter