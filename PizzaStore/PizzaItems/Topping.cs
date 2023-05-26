using System;
namespace PizzaStore.PizzaItems
{
	public class Topping : PizzaItem
	{
        public static readonly Topping MOZZARELLA_CHEESEE = new Topping("Mozzarella cheese", 30);
        public static readonly Topping CHEDDAR_CHEESE = new Topping("Cheddar cheese", 35);
        public static readonly Topping SPINACH = new Topping("Spinach", 20);
        public static readonly Topping CORN = new Topping("Corn", 15);
        public static readonly Topping MUSHROOM = new Topping("Mushroom", 15);
        public static readonly Topping CHICKEN = new Topping("Chicken", 50);
        public static readonly Topping PEPPARONI = new Topping("Pepparoni", 45);

        public Topping(string name, int price) : base(name, price)
        {
        }

        public static Topping[] getAll()
        {
            return new Topping[] {
                MOZZARELLA_CHEESEE,
                CHEDDAR_CHEESE,
                SPINACH,
                CORN,
                MUSHROOM,
                CHICKEN,
                PEPPARONI
            };
        }
    }
}

