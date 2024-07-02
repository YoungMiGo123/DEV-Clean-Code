namespace BuilderPattern
{
    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
        public string OS { get; set; }

        public override string ToString()
        {
            return $"Computer Specifications:\n" +
                   $"CPU: {CPU}\n" +
                   $"GPU: {GPU}\n" +
                   $"RAM: {RAM}GB\n" +
                   $"Storage: {Storage}GB\n" +
                   $"OS: {OS}";
        }
    }
}
