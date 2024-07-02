namespace BuilderPattern
{
    public class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Pizza with {Dough} dough, {Sauce} sauce, {Cheese} cheese, and toppings: {string.Join(", ", Toppings)}";
        }
    }
}
