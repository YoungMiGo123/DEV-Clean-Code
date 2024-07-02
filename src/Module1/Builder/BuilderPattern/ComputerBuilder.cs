namespace BuilderPattern
{
    public class ComputerBuilder
    {
        private Computer _computer;

        public ComputerBuilder()
        {
            _computer = new Computer();
        }

        public ComputerBuilder SetCPU(string cpu)
        {
            _computer.CPU = cpu;
            return this;
        }

        public ComputerBuilder SetGPU(string gpu)
        {
            _computer.GPU = gpu;
            return this;
        }

        public ComputerBuilder SetRAM(int ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public ComputerBuilder SetStorage(int storage)
        {
            _computer.Storage = storage;
            return this;
        }

        public ComputerBuilder SetOS(string os)
        {
            _computer.OS = os;
            return this;
        }

        public Computer Build()
        {
            return _computer;
        }
    }
}
