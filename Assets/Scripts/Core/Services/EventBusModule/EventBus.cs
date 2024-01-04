using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Services.ServiceLocatorSystem;

namespace Services.EventBusService
{
    public class EventBus : IService
    {
        private readonly Dictionary<string, List<EventBusAction>> _subscribers;
        private readonly Dictionary<string, List<EventBusTask>> _subscribersTasks;

        public EventBus()
        {
            _subscribers = new Dictionary<string, List<EventBusAction>>();
            _subscribersTasks = new Dictionary<string, List<EventBusTask>>();
        }

        public void Subscribe(string eventName, EventBusAction action)
        {
            if (!_subscribers.ContainsKey(eventName))
                _subscribers.Add(eventName, new List<EventBusAction>());

            _subscribers[eventName].Add(action);
        }

        public void Subscribe(string eventName, EventBusTask task)
        {
            if (!_subscribersTasks.ContainsKey(eventName))
                _subscribersTasks.Add(eventName, new List<EventBusTask>());

            _subscribersTasks[eventName].Add(task);
        }

        public void Unsubscribe<T>(string eventName, EventBusAction action) where T : EventBusArgs
        {
            if (!_subscribers.ContainsKey(eventName))
                return;

            _subscribers[eventName].Remove(action);
        }

        public void Raise(string eventName, EventBusArgs args)
        {
            if (!_subscribers.TryGetValue(eventName, out var subscribers))
                return;

            foreach (var subscriber in subscribers)
            {
                subscriber(args);
            }
        }

        public async Task RaiseAsync(string eventName, EventBusArgs args)
        {
            if (!_subscribersTasks.TryGetValue(eventName, out var subscribers))
                return;

            foreach (var subscriber in subscribers)
            {
                await subscriber(args);
            }
        }
    }
}