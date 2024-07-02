namespace BuilderPattern
{
    public class PizzaBuilder
    {
        private Pizza _pizza;

        public PizzaBuilder()
        {
            _pizza = new Pizza();
        }

        public PizzaBuilder SetDough(string dough)
        {
            _pizza.Dough = dough;
            return this;
        }

        public PizzaBuilder SetSauce(string sauce)
        {
            _pizza.Sauce = sauce;
            return this;
        }

        public PizzaBuilder SetCheese(string cheese)
        {
            _pizza.Cheese = cheese;
            return this;
        }

        public PizzaBuilder AddTopping(string topping)
        {
            _pizza.Toppings.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return _pizza;
        }
    }
}
