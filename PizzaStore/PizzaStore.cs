using System;
using PizzaStore.Offers;
using PizzaStore;
using PizzaStore.PizzaItems;

namespace PizzaStore
{
    public class PizzaStore
    {
        private readonly List<IOffer> _offers = new List<IOffer>();
        private PizzaBuilder _pizzaBuilder = new PizzaBuilder();

        public PizzaStore(List<IOffer> offers)
        {
            this._offers = offers;
        }

        public void TakeOrder()
        {
            _pizzaBuilder.Reset();

            int Option;
            int[]? MultipleOptions;

            Option = SelectItem(PizzaBase.getAll());
            if (Option != -1)
                _pizzaBuilder.WithPizzaBase(PizzaBase.getAll()[Option]);

            Option = SelectItem(Sauce.getAll());
            if (Option != -1)
                _pizzaBuilder.WithSauce(Sauce.getAll()[Option]);

            MultipleOptions = SelectMultipleItems(Topping.getAll());
            if (MultipleOptions != null)
            {
                foreach (var index in MultipleOptions)
                    _pizzaBuilder.WithTopping(Topping.getAll()[index]);

            }

            Option = SelectItem(Drink.getAll(), true);
            if (Option != -1)
                _pizzaBuilder.WithDrink(Drink.getAll()[Option]);

            Option = SelectItem(Dessert.getAll(), true);
            if (Option != -1)
                _pizzaBuilder.WithDessert(Dessert.getAll()[Option]);

            Pizza pizza = _pizzaBuilder.Create();
            Console.WriteLine(pizza);

            double Amount = pizza.Price;
            List<double> Discounts = new List<double>();

            _offers.ForEach((offer) => {
                Discounts.Add(offer.Apply(pizza));
            });

            double DiscountApplied = Discounts.Max();
            Amount -= DiscountApplied;

            Console.WriteLine($"Discount applied: {DiscountApplied} RS");
            Console.WriteLine($"Amount to be paid: {Amount} RS");
        }



        private int SelectItem(PizzaItem[] items, bool optional = false)
        {
            if (optional)
            {
                Console.Write($"Would you like any {items[0].GetType().Name} [y/n] (default - y) : ");
                char Wants = Console.ReadLine()[0];
                if (Wants == 'n' || Wants == 'N')
                    return -1;
            }

            Console.WriteLine($"Available {items[0].GetType().Name}s:");
            for (int index = 0; index < items.Length; index++)
            {
                Console.WriteLine($"{index}. {items[index].Name}");
            }

            Console.Write("Choose an option: ");
            int Option = Convert.ToInt32(Console.ReadLine());

            if (Option < 0 || Option >= items.Length)
                throw new ArgumentException($"Entered option {Option} out of range");

            return Option;
        }

        private int[]? SelectMultipleItems(PizzaItem[] items, bool optional = false)
        {
            if (optional)
            {
                Console.Write($"Would you like any {items[0].GetType().Name} [y/n] (default - y) : ");
                char Wants = Console.ReadLine()[0];
                if (Wants == 'n' || Wants == 'N')
                    return null;
            }

            Console.WriteLine($"Available {items[0].GetType().Name}s:");
            for (int index = 0; index < items.Length; index++)
            {
                Console.WriteLine($"{index}. {items[index].Name}");
            }

            Console.Write("Choose one or more options (Enter space seperated options): ");
            int[] Options = Array.ConvertAll(Console.ReadLine().Split(' '), (item) => Convert.ToInt32(item));

            foreach (int index in Options)
                if (index < 0 || index >= items.Length)
                    throw new ArgumentException($"Entered option {index} is out of range");

            return Options;
        }
	}
}

