using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace EndToEnd.Models
{
      public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BusinessName { get; set; }



        // public string MyProperty { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }




    public class FinCoreDB : IdentityDbContext<ApplicationUser>
    {
        public FinCoreDB()
            : base("FinCore", throwIfV1Schema: false)
        {

        }

        public static FinCoreDB Create()
        {
            return new FinCoreDB();
        }

        public DbSet<BankDetail> BankDetails { get; set; }

        public DbSet<Purchases> Purchases { get; set; }

        public DbSet<SmsTransaction> SmsPurchaseTransaction { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<StaffLogin>StaffLogins { get; set; }

        public DbSet<SmsAmount> SmsAmount { get; set; }

        public DbSet<ConfirmPurchase> ConfirmPurchase { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<SmsUser> SmsUsers { get; set; }

        public DbSet<SmsUnit> SmsUnits { get; set; }

        public DbSet<PurchaseSms> PurchaseSms { get; set; }

        public DbSet<SendSms> SendSms { get; set; }

        public DbSet<CreateChargeRate> CreateChargeRates { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<UserTokenBalance> UserTokenBalances { get; set; }

          }
}