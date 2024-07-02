namespace BuilderPattern
{
    public class BuilderRunner
    {
        public static void Run()
        {
            SetupComputerBuilder();
            SetupPizzaBuilder();
        }

        private static void SetupComputerBuilder()
        {
            var gamingComputer = new ComputerBuilder()
           .SetCPU("Intel Core i9")
           .SetGPU("NVIDIA RTX 3080")
           .SetRAM(32)
           .SetStorage(1000)
           .SetOS("Windows 11")
           .Build();

            var officeComputer = new ComputerBuilder()
                .SetCPU("Intel Core i5")
                .SetGPU("Integrated Graphics")
                .SetRAM(16)
                .SetStorage(512)
                .SetOS("Windows 10")
                .Build();

            Console.WriteLine(gamingComputer);
            Console.WriteLine();
            Console.WriteLine(officeComputer);
        }

        private static void SetupPizzaBuilder()
        {
            var margheritaPizza = new PizzaBuilder()
            .SetDough("Thin Crust")
            .SetSauce("Tomato")
            .SetCheese("Mozzarella")
            .AddTopping("Basil")
            .AddTopping("Bacon")
            .Build();

            var pepperoniPizza = new PizzaBuilder()
                .SetDough("Thick Crust")
                .SetSauce("Barbecue")
                .SetCheese("Cheddar")
                .AddTopping("Pepperoni")
                .AddTopping("Olives")
                .AddTopping("Extra Mozzarella Cheese")
                .AddTopping("Ham")
                .Build();

            Console.WriteLine(margheritaPizza);
            Console.WriteLine();
            Console.WriteLine(pepperoniPizza);
        }
    }
}
