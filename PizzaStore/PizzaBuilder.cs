using System;
using PizzaStore.PizzaItems;

namespace PizzaStore
{
	public class PizzaBuilder
	{
        public double Price { get; set; } = 0;
        public PizzaBase PizzaBase { get; set; }
        public Sauce Sauce { get; set; }
        public HashSet<Topping> Toppings { get; set; } = new HashSet<Topping>();
        public Drink Drink { get; set; }
        public Dessert Dessert { get; set; }

        public PizzaBuilder()
		{
		}

		public PizzaBuilder WithPizzaBase(PizzaBase pizzaBase)
		{
			this.PizzaBase = pizzaBase;
            this.Price += pizzaBase.Price;
			return this;
		}

        public PizzaBuilder WithSauce(Sauce sauce)
        {
            this.Sauce = sauce;
            this.Price += sauce.Price;
            return this;
        }

        public PizzaBuilder WithTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            this.Price += topping.Price;
            return this;
        }

        public PizzaBuilder WithDrink(Drink drink)
        {
            this.Drink = drink;
            this.Price += drink.Price;
            return this;
        }

        public PizzaBuilder WithDessert(Dessert dessert)
        {
            this.Dessert = dessert;
            this.Price += dessert.Price;
            return this;
        }

        public void Reset()
        {
            PizzaBase = null;
            Sauce = null;
            Toppings = new HashSet<Topping>();
            Drink = null;
            Dessert = null;
            Price = 0;
        }

        public Pizza Create()
        {
            return new Pizza(PizzaBase, Sauce, Toppings, Drink, Dessert, Price);
        }
    }
}

