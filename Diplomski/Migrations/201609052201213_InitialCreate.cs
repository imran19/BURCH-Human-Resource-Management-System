namespace Diplomski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CountryName);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DepartmentName);
            
            CreateTable(
                "dbo.ElectoralPeriods",
                c => new
                    {
                        ElectoralPeriodName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ElectoralPeriodName);
            
            CreateTable(
                "dbo.EmploymentStatus",
                c => new
                    {
                        EmploymentName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmploymentName);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FacultyName);
            
            CreateTable(
                "dbo.LeaveRequestForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        Department = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Title = c.String(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        BeginningOfLeave = c.DateTime(nullable: false),
                        EndOfLeave = c.DateTime(nullable: false),
                        EmployeeRegNum = c.Int(nullable: false),
                        AnnualLeave = c.Boolean(nullable: false),
                        LeaveDueToAnExcuse = c.Boolean(nullable: false),
                        LeaveDueToAnIllness = c.Boolean(nullable: false),
                        LeaveWithoutPay = c.Boolean(nullable: false),
                        Explanation = c.String(),
                        Signature = c.Boolean(nullable: false),
                        ExplanationForRejection = c.String(),
                        HeadValidation = c.Boolean(nullable: false),
                        HeadApprovedDate = c.DateTime(nullable: false),
                        DeanValidation = c.Boolean(nullable: false),
                        DeanApprovedDate = c.DateTime(nullable: false),
                        StartingDateOfEmployment = c.DateTime(nullable: false),
                        DurationOfLeave = c.Int(nullable: false),
                        HRMValidation = c.Boolean(nullable: false),
                        HRMApprovedDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        EmployeeRegNum = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Faculty = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        EmploymentStatus = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        ElectoralPeriod = c.String(nullable: false),
                        ContractExpiration = c.DateTime(nullable: false),
                        NumberOfLeaveDays = c.Int(nullable: false),
                        Stay = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(nullable: false),
                        ChiefHRManager = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stays",
                c => new
                    {
                        StayName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StayName);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TitleName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequestForms", "UserID", "dbo.Users");
            DropIndex("dbo.LeaveRequestForms", new[] { "UserID" });
            DropTable("dbo.Titles");
            DropTable("dbo.Stays");
            DropTable("dbo.Users");
            DropTable("dbo.LeaveRequestForms");
            DropTable("dbo.Faculties");
            DropTable("dbo.EmploymentStatus");
            DropTable("dbo.ElectoralPeriods");
            DropTable("dbo.Departments");
            DropTable("dbo.Countries");
        }
    }
}
