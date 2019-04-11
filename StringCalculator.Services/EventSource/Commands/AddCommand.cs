namespace StringCalculator.Services.EventSource.Commands
{
    public class AddCommand : Command
    {
        public ICalculator Target;
        public int Value;

        public AddCommand(ICalculator target, int value)
        {
            Target = target;
            Value = value;
        }
    }
}
