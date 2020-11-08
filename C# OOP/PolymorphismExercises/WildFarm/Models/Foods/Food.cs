
namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        public Food(int qty)
        {
            Quantity = qty;
        }
        public int Quantity { get; private set; }
    }
}
