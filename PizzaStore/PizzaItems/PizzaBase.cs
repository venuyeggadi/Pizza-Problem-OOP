using System;
namespace PizzaStore.PizzaItems
{
	public class PizzaBase : PizzaItem
	{
        public static readonly PizzaBase REGULAR = new PizzaBase("Regular", 50);
        public static readonly PizzaBase WHOLE_WHEAT = new PizzaBase("Whole Wheat", 75);

        public PizzaBase(string name, int price) : base(name, price)
		{
		}

        public static PizzaBase[] getAll()
        {
            return new PizzaBase[] {
                REGULAR,
                WHOLE_WHEAT
            };
        }
    }
}
