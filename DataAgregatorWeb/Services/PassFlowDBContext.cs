using DataAgregatorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAgregatorWeb.Services
{
    public class PassFlowDBContext : DbContext
    {
        public PassFlowDBContext()
        {
        }

        public PassFlowDBContext(DbContextOptions<PassFlowDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trip> Trips { get; set; }

        public virtual DbSet<Way> Ways { get; set; }

        public virtual DbSet<Bus> Buses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("trip_pkey");

                entity.ToTable("trip");

                entity.HasOne(t => t.Way).WithMany(w => w.Trips)
                    .HasForeignKey(t => t.WayId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("trip_way_fkey");

                entity.HasOne(t => t.Bus).WithMany(b => b.Trips)
                    .HasForeignKey(t => t.BusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("trip_bus_fkey");
            });

            modelBuilder.Entity<Way>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("way_pkey");

                entity.ToTable("way");

                entity.HasIndex(e => e.Name, "name_unique").IsUnique();
            });

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("bus_pkey");

                entity.ToTable("bus");
            });
            
            base.OnModelCreating(modelBuilder);
            //OnModelCreatingPartial(modelBuilder);
        }
    }
}
