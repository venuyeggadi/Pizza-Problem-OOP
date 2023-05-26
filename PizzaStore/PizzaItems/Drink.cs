using System;
namespace PizzaStore.PizzaItems
{
	public class Drink : PizzaItem
	{
        public static readonly Drink PEPSI = new Drink("Pepsi", 17);
        public static readonly Drink SEVENUP = new Drink("7-up", 19);
        public static readonly Drink COKE = new Drink("Coke", 20);

        public Drink(string name, int price) : base(name, price)
		{
		}

        public static Drink[] getAll()
        {
            return new Drink[] {
                PEPSI,
                SEVENUP,
                COKE
            };
        }
    }
}

