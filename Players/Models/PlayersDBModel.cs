namespace Players.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlayersDBModel : DbContext
    {
        public PlayersDBModel()
            : base("name=PlayersApp")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.Position)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.Nationality)
                .IsFixedLength();
        }
    }
}
