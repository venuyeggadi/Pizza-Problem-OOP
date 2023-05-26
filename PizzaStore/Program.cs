using PizzaStore.Offers;
using PizzaStore.PizzaItems;

namespace PizzaStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IOffer> offers = new List<IOffer>();

            offers.Add(new PercentageRateCutOffer(5, (pizza) =>
            {
                return pizza.Dessert != null && pizza.Drink != null;
            }));

            offers.Add(new PercentageRateCutOffer(10, (pizza) =>
            {
                return pizza.PizzaBase == PizzaBase.WHOLE_WHEAT && pizza.Sauce == Sauce.PESTO_SAUCE;
            }));

            offers.Add(new FixedRateCutOffer(20, (pizza) =>
            {
                return pizza.Toppings.Contains(Topping.CHEDDAR_CHEESE);
            }));

            new PizzaStore(offers).TakeOrder();
        }
    }
}