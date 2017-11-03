using System.Data.Entity;

namespace CarsDB.Classes
{
    public class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public Context()
            : base("Cars")
        { }
    }
}