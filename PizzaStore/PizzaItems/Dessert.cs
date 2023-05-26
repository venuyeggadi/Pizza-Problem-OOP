using System;

namespace PizzaStore.PizzaItems
{
	public class Dessert : PizzaItem
	{
        public static readonly Dessert LAVA_CAKE = new Dessert("Lava cake", 95);
        public static readonly Dessert CHOCOLATE = new Dessert("Chocolate Brownie", 86);

        public Dessert(string name, int price) : base(name, price)
		{
		}

        public static Dessert[] getAll()
        {
            return new Dessert[] {
                LAVA_CAKE,
                CHOCOLATE
            };
        }
    }
}

