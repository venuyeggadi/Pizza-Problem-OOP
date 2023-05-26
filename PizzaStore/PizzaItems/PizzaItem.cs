using System;
namespace PizzaStore.PizzaItems
{
	public abstract class PizzaItem
	{
        public string Name { get; }
        public int Price { get; }

        protected PizzaItem(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}

