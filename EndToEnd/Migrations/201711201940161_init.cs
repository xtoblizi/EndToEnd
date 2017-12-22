namespace EndToEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        BankName = c.Int(nullable: false),
                        Address = c.String(),
                        State = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConfirmPurchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        StatusOfPurchase = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfPayment = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CreateChargeRates",
                c => new
                    {
                        CreateChargeRateId = c.Int(nullable: false, identity: true),
                        SmsUnitId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(),
                        EffectedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CreateChargeRateId)
                .ForeignKey("dbo.SmsUnits", t => t.SmsUnitId, cascadeDelete: true)
                .Index(t => t.SmsUnitId);
            
            CreateTable(
                "dbo.SmsUnits",
                c => new
                    {
                        SmsUnitID = c.Int(nullable: false, identity: true),
                        Unit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        EnteredBy = c.String(),
                    })
                .PrimaryKey(t => t.SmsUnitID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BankCode = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseType = c.Int(nullable: false),
                        BankName = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PurchaseSms",
                c => new
                    {
                        PurchaseSmsId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(nullable: false),
                        PurchaseSucceded = c.Boolean(),
                        SmsUnitID = c.Int(nullable: false),
                        SmsUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseSmsId)
                .ForeignKey("dbo.SmsUnits", t => t.SmsUnitID, cascadeDelete: true)
                .ForeignKey("dbo.SmsUsers", t => t.SmsUserId)
                .Index(t => t.SmsUnitID)
                .Index(t => t.SmsUserId);
            
            CreateTable(
                "dbo.SmsUsers",
                c => new
                    {
                        SmsUserId = c.String(nullable: false, maxLength: 128),
                        DesiredNameForSms = c.String(),
                        IsBusiness = c.Boolean(nullable: false),
                        BusinessName = c.String(),
                        IsIndividual = c.Boolean(nullable: false),
                        Slogan = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        Passport = c.Binary(),
                    })
                .PrimaryKey(t => t.SmsUserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentType = c.String(),
                        BankName = c.String(),
                        DateOfPayment = c.DateTime(nullable: false),
                        TellerId = c.String(),
                        SmsUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.SmsUsers", t => t.SmsUserId)
                .Index(t => t.SmsUserId);
            
            CreateTable(
                "dbo.StaffLogins",
                c => new
                    {
                        StaffLoginId = c.Int(nullable: false, identity: true),
                        StaffName = c.String(),
                        Description = c.String(),
                        DateOfLogin = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StaffId = c.String(maxLength: 128),
                        SmsUser_SmsUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffLoginId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .ForeignKey("dbo.SmsUsers", t => t.SmsUser_SmsUserId)
                .Index(t => t.StaffId)
                .Index(t => t.SmsUser_SmsUserId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.String(nullable: false, maxLength: 128),
                        BankCode = c.String(),
                        StaffCode = c.String(),
                        Level = c.String(),
                        UserGroupList = c.Int(nullable: false),
                        UserPassword = c.String(),
                        TokenID = c.Int(nullable: false),
                        AuthID = c.Int(nullable: false),
                        UserTypeID = c.Int(nullable: false),
                        SmsPurchaseTransactionID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        Passport = c.Binary(),
                        Authentication_AuthenticationId = c.Int(),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Authentications", t => t.Authentication_AuthenticationId)
                .Index(t => t.Authentication_AuthenticationId);
            
            CreateTable(
                "dbo.Authentications",
                c => new
                    {
                        AuthenticationId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthenticationId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        TokenBalance = c.Decimal(precision: 18, scale: 2),
                        SmsUserId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.SmsUsers", t => t.SmsUserId)
                .Index(t => t.SmsUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SendSms",
                c => new
                    {
                        SendSmsId = c.Int(nullable: false, identity: true),
                        SendTo = c.String(),
                        Message = c.String(),
                        SendFrom = c.String(),
                        MsgHeader = c.String(),
                        DateTimeDelivered = c.DateTime(),
                        HasDelivered = c.Boolean(),
                        AunthenticationId = c.Int(nullable: false),
                        Authentication_AuthenticationId = c.Int(),
                    })
                .PrimaryKey(t => t.SendSmsId)
                .ForeignKey("dbo.Authentications", t => t.Authentication_AuthenticationId)
                .Index(t => t.Authentication_AuthenticationId);
            
            CreateTable(
                "dbo.SmsAmounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SmsUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SmsPurchaseTransactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseTypeID = c.Int(nullable: false),
                        BankCode = c.String(),
                        PurchaseType = c.Int(nullable: false),
                        Description = c.String(),
                        StatusOfPurchase = c.Int(nullable: false),
                        SmsUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasedBy = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BusinessName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTokenBalancess",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TokenBalance = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SendSms", "Authentication_AuthenticationId", "dbo.Authentications");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseSms", "SmsUserId", "dbo.SmsUsers");
            DropForeignKey("dbo.Tokens", "SmsUserId", "dbo.SmsUsers");
            DropForeignKey("dbo.StaffLogins", "SmsUser_SmsUserId", "dbo.SmsUsers");
            DropForeignKey("dbo.StaffLogins", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "Authentication_AuthenticationId", "dbo.Authentications");
            DropForeignKey("dbo.Payments", "SmsUserId", "dbo.SmsUsers");
            DropForeignKey("dbo.PurchaseSms", "SmsUnitId", "dbo.SmsUnits");
            DropForeignKey("dbo.CreateChargeRates", "SmsUnitId", "dbo.SmsUnits");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SendSms", new[] { "Authentication_AuthenticationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tokens", new[] { "SmsUserId" });
            DropIndex("dbo.Staffs", new[] { "Authentication_AuthenticationId" });
            DropIndex("dbo.StaffLogins", new[] { "SmsUser_SmsUserId" });
            DropIndex("dbo.StaffLogins", new[] { "StaffId" });
            DropIndex("dbo.Payments", new[] { "SmsUserId" });
            DropIndex("dbo.PurchaseSms", new[] { "SmsUserId" });
            DropIndex("dbo.PurchaseSms", new[] { "SmsUnitId" });
            DropIndex("dbo.CreateChargeRates", new[] { "SmsUnitId" });
            DropTable("dbo.UserTokenBalancess");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserGroups");
            DropTable("dbo.SmsPurchaseTransactions");
            DropTable("dbo.SmsAmounts");
            DropTable("dbo.SendSms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tokens");
            DropTable("dbo.Authentications");
            DropTable("dbo.Staffs");
            DropTable("dbo.StaffLogins");
            DropTable("dbo.Payments");
            DropTable("dbo.SmsUsers");
            DropTable("dbo.PurchaseSms");
            DropTable("dbo.Purchases");
            DropTable("dbo.SmsUnits");
            DropTable("dbo.CreateChargeRates");
            DropTable("dbo.ConfirmPurchases");
            DropTable("dbo.BankDetails");
        }
    }
}
