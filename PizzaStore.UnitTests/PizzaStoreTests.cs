using PizzaStore;
using PizzaStore.Offers;

namespace PizzaStore.UnitTests;

public class PizzaStoreTests
{
    [Test]
    public void TakeOrder_WithoutDrinkAndDessert_AppliesNoOffer()
    {
        string ConsoleInput = "0\n" + "0\n" + "0\n" + "n\n" + "n\n";
        string ExpectedConsoleOutput = "Available Pizza Bases:\n" +
            "0. Regular\n" +
            "1. Whole Wheat\n" +
            "Choose an option: " +
            "Available Sauces:\n" +
            "0. Marinara sauce\n" +
            "1. Pesto sauce\n" +
            "Choose an option: " +
            "Available Toppings:\n" +
            "0. Mozzarella cheese\n" +
            "1. Cheddar cheese\n" +
            "2. Spinach\n" +
            "3. Corn\n" +
            "4. Mushroom\n" +
            "5. Chicken\n" +
            "6. Pepparoni\n" +
            "Choose one or more options (Enter space seperated options): " +
            "Would you like any Drink [y/n] (default - y) : " +
            "Would you like any Dessert [y/n] (default - y) : " +
            "Pizza Base: Regular\n" +
            "Sauce: Marinara sauce\n" +
            "Topping: Mozzarella cheese\n" +
            "Amount to be paid: 80 RS\n";
        StringWriter ConsoleOutputWriter = new StringWriter();
        Console.SetOut(ConsoleOutputWriter);
        Console.SetIn(new StringReader(ConsoleInput));

        List<IOffer> offers = new List<IOffer>();
        offers.Add(new PercentageRateCutOffer(5, (items) =>
        {
            return items.Exists((item) => item.Type == "Drink") && items.Exists((item) => item.Type == "Dessert");
        }));
        new PizzaStore(offers).TakeOrder();
        string ActualConsoleOutput = ConsoleOutputWriter.ToString();

        Assert.That(ActualConsoleOutput, Is.EqualTo(ExpectedConsoleOutput));
    }

    [Test]
    public void TakeOrder_WithDrinkAndDessert_AppliesFivePercentOff()
    {
        string ConsoleInput = "1\n" + "1\n" + "0 6\n" + "y\n" + "2\n" + "y\n" + "0\n";
        string ExpectedConsoleOutput = "Available Pizza Bases:\n" +
            "0. Regular\n" +
            "1. Whole Wheat\n" +
            "Choose an option: " +
            "Available Sauces:\n" +
            "0. Marinara sauce\n" +
            "1. Pesto sauce\n" +
            "Choose an option: " +
            "Available Toppings:\n" +
            "0. Mozzarella cheese\n" +
            "1. Cheddar cheese\n" +
            "2. Spinach\n" +
            "3. Corn\n" +
            "4. Mushroom\n" +
            "5. Chicken\n" +
            "6. Pepparoni\n" +
            "Choose one or more options (Enter space seperated options): " +
            "Would you like any Drink [y/n] (default - y) : " +
            "Available Drinks:\n" +
            "0. Pepsi\n" +
            "1. 7-up\n" +
            "2. Coke\n" +
            "Choose an option: " +
            "Would you like any Dessert [y/n] (default - y) : " +
            "Available Desserts:\n" +
            "0. Lava cake\n" +
            "1. Chocolate Brownie\n" +
            "Choose an option: " +
            "Pizza Base: Whole Wheat\n" +
            "Sauce: Pesto sauce\n" +
            "Topping: Mozzarella cheese\n" +
            "Topping: Pepparoni\n" +
            "Drink: Coke\n" +
            "Dessert: Lava cake\n" +
            "Amount to be paid: 251.75 RS\n";
        StringWriter ConsoleOutputWriter = new StringWriter();
        Console.SetOut(ConsoleOutputWriter);
        Console.SetIn(new StringReader(ConsoleInput));

        List<IOffer> offers = new List<IOffer>();
        offers.Add(new PercentageRateCutOffer(5, (items) =>
        {
            return items.Exists((item) => item.Type == "Drink") && items.Exists((item) => item.Type == "Dessert");
        }));
        new PizzaStore(offers).TakeOrder();
        string ActualConsoleOutput = ConsoleOutputWriter.ToString();

        Assert.That(ActualConsoleOutput, Is.EqualTo(ExpectedConsoleOutput));
    }

    [Test]
    public void TakeOrder_WhenEligibleForMultipleOffers_AppliesOfferWithMaximumDiscount()
    {
        string ConsoleInput = "1\n" + "1\n" + "0 1 6\n" + "n\n" + "n\n";
        string ExpectedConsoleOutput = "Available Pizza Bases:\n" +
            "0. Regular\n" +
            "1. Whole Wheat\n" +
            "Choose an option: " +
            "Available Sauces:\n" +
            "0. Marinara sauce\n" +
            "1. Pesto sauce\n" +
            "Choose an option: " +
            "Available Toppings:\n" +
            "0. Mozzarella cheese\n" +
            "1. Cheddar cheese\n" +
            "2. Spinach\n" +
            "3. Corn\n" +
            "4. Mushroom\n" +
            "5. Chicken\n" +
            "6. Pepparoni\n" +
            "Choose one or more options (Enter space seperated options): " +
            "Would you like any Drink [y/n] (default - y) : " +
            "Would you like any Dessert [y/n] (default - y) : " +
            "Pizza Base: Whole Wheat\n" +
            "Sauce: Pesto sauce\n" +
            "Topping: Mozzarella cheese\n" +
            "Topping: Cheddar cheese\n" +
            "Topping: Pepparoni\n" +
            "Amount to be paid: 165 RS\n";
        StringWriter ConsoleOutputWriter = new StringWriter();
        Console.SetOut(ConsoleOutputWriter);
        Console.SetIn(new StringReader(ConsoleInput));

        List<IOffer> offers = new List<IOffer>();
        offers.Add(new PercentageRateCutOffer(5, (items) =>
        {
            return items.Exists((item) => item.Type == "Drink") && items.Exists((item) => item.Type == "Dessert");
        }));

        offers.Add(new PercentageRateCutOffer(10, (items) =>
        {
            return items.Contains(Drink.WHOLE_WHEAT_PIZZA_BASE) && items.Contains(Drink.PESTO_SAUCE);
        }));

        offers.Add(new FixedRateCutOffer(20, (items) =>
        {
            return items.Contains(Drink.CHEDDAR_CHEESE_TOPPING);
        }));
        new PizzaStore(offers).TakeOrder();
        string ActualConsoleOutput = ConsoleOutputWriter.ToString();

        Assert.That(ActualConsoleOutput, Is.EqualTo(ExpectedConsoleOutput));
    }
}
