using System;
using PizzaStore.PizzaItems;

namespace PizzaStore
{
	public class Pizza
	{
        public double Price { get; set; }
		public PizzaBase PizzaBase { get; set; }
        public Sauce Sauce { get; set; }
		public HashSet<Topping> Toppings { get; set; } = new HashSet<Topping>();
        public Drink Drink { get; set; }
		public Dessert Dessert { get; set; }

        public Pizza(PizzaBase pizzaBase, Sauce sauce, HashSet<Topping> toppings, Drink drink, Dessert dessert, double price)
        {
            this.PizzaBase = pizzaBase;
            this.Sauce = sauce;
            this.Toppings = toppings;
            this.Drink = drink;
            this.Dessert = dessert;
            this.Price = price;
        }

        public override string ToString()
        {
            string ToppingsString = $"Toppings: {String.Join(", ", Toppings)}\n";
            string DrinkString = Drink != null ? $"Drink: {Drink}\n" : "";
            string DessertString = Dessert != null ? $"Dessert: {Dessert}\n" : "";

            return "=== Pizza Order Summary ===\n" +
                $"Pizza Base: {PizzaBase.Name}\n" +
                $"Sauce: {Sauce.Name}\n" +
                ToppingsString +
                DrinkString +
                DessertString +
                $"Total price: {Price} RS";
        }
    }
}

