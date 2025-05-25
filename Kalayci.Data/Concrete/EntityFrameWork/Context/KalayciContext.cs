using Kalayci.Data.Concrete.EntityFrameWork.Mappings;
using Kalayci.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Context
{
    public class KalayciContext : IdentityDbContext<KalayciUser, KalayciRole,string>
    {

        public KalayciContext(DbContextOptions<KalayciContext> options) : base(options)
        {
        }




        public DbSet<CircuitDelivery> CircuitDelivery { get; set; }
        public DbSet<CircuitList> CircuitList { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Sending> Sending { get; set; }
        public DbSet<ShipYard> ShipYard { get; set; }
        public DbSet<ShipyardAssembly> ShipyardAssembly { get; set; }
        public DbSet<Spool> Spool { get; set; }
        public DbSet<Welding> Welding { get; set; }
        public DbSet<WorkPlace> WorkPlace { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Point> Point { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ShipYardMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new KalayciUserMap());
            modelBuilder.ApplyConfiguration(new CircuitDeliveryMap());
           
            modelBuilder.ApplyConfiguration(new CircuitListMap());
            modelBuilder.ApplyConfiguration(new SpoolMap());

            modelBuilder.ApplyConfiguration(new WeldingMap());
            modelBuilder.ApplyConfiguration(new WorkPlaceMap());

            modelBuilder.ApplyConfiguration(new PersonelMap());
            modelBuilder.ApplyConfiguration(new PointMap());
            modelBuilder.ApplyConfiguration(new ShipyardAssemblyMap());
            modelBuilder.ApplyConfiguration(new SendingMap());

        }

    }
}
