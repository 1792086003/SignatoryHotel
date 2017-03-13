using System.Data.Entity;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity.DataAccess
{
    public class SignatoryHotelContext:DbContext
    {
       //返回所有表的所有数据集
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
