using System;
namespace PizzaStore.PizzaItems
{
	public class Sauce : PizzaItem
	{
        public static readonly Sauce MARINARA_SAUCE = new Sauce("Marinara sauce", 0);
        public static readonly Sauce PESTO_SAUCE = new Sauce("Pesto sauce", 0);

        public Sauce(string name, int price) : base(name, price)
        {
        }

        public static Sauce[] getAll()
        {
            return new Sauce[] {
                MARINARA_SAUCE,
                PESTO_SAUCE
            };
        }
    }
}

