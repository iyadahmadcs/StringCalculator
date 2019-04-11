namespace StringCalculator.Services.EventSource.Commands
{
    public class AddCommand : Command
    {
        public ICalculator Target { get; set; }
        public int Value { get; set; }

        public AddCommand(ICalculator target, int value)
        {
            Target = target;
            Value = value;
        }
    }
}
