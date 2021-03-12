using Warehouse.Data;

namespace WH
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new WHContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
