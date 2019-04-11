using StringCalculator.Services.EventSource.Commands;
using StringCalculator.Services.EventSource.Events;
using StringCalculator.Services.EventSource.Queries;

namespace StringCalculator.Services.EventSource
{
    public interface ICalculator
    {

    }
    public class Calculator : ICalculator
    {
        private int Sum = 0;
        private readonly IEventBroker Broker;

        public Calculator(IEventBroker broker)
        {
            this.Broker = broker;
            broker.Commands += BrokerCommands;
            broker.Queries += BrokerQueries;
        }

        private void BrokerQueries(object sender, Query query)
        {
            var sumQuery = query as SumQuery;
            if (sumQuery != null && sumQuery.Target == this)
            {
                sumQuery.Result = Sum;
            }
        }

        private void BrokerCommands(object sender, Command command)
        {
            var addCommand = command as AddCommand;
            if (addCommand != null && addCommand.Target == this)
            {
                if (addCommand.Value <= 1000)
                {
                    Sum += addCommand.Value;
                    Broker.AllEvents.Add(new AddNumberEvent(this, Sum, addCommand.Value));
                }
                else
                {
                    Broker.AllEvents.Add(new SkipNumberEvent(this, Sum, addCommand.Value));
                }
            }
        }
    }

}
