namespace StringCalculator.Services.EventSource.Events
{
    public class SkipNumberEvent : Event
    {
        public Calculator Target { get; set; }
        public int Sum { get; set; }
        public int NewValue { get; set; }

        public SkipNumberEvent(Calculator target, int sum, int newValue)
        {
            Target = target;
            Sum = sum;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"The value {NewValue} skiped, Sum = {Sum}.";
        }
    }
}
