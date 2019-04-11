using StringCalculator.Services.EventSource.Commands;
using StringCalculator.Services.EventSource.Events;
using StringCalculator.Services.EventSource.Queries;
using System;
using System.Collections.Generic;

namespace StringCalculator.Services.EventSource
{
    public interface IEventBroker
    {
        void Command(Command command);
        T Query<T>(Query query);
        IList<Event> AllEvents { get; set; }

        event EventHandler<Command> Commands;

        event EventHandler<Query> Queries;

    }
    public class EventBroker : IEventBroker
    {
        public IList<Event> AllEvents { get; set; } = new List<Event>();
        public event EventHandler<Command> Commands;
        public event EventHandler<Query> Queries;

        public void Command(Command command)
        {
            Commands?.Invoke(this, command);
        }

        public T Query<T>(Query query)
        {
            Queries?.Invoke(this, query);
            return (T)query.Result;
        }
    }
}
