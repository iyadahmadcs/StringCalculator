namespace StringCalculator.Services.EventSource.Events
{
    public class AddNumberEvent : Event
    {
        public Calculator Target;
        public int Sum, NewValue;

        public AddNumberEvent(Calculator target, int sum, int newValue)
        {
            Target = target;
            Sum = sum;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"The value {NewValue} added to Sum, Sum = {Sum}.";
        }
    }
}
