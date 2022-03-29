using HMS.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Data
{
    public class HMSContext : IdentityDbContext<HMSUser>
    {
        public HMSContext() : base("HMSConnectionString")
        {

        }
        public static HMSContext Create()
        {
            return new HMSContext();
        }
        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
   


    }

   
}


