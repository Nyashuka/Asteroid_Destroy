using System;
using System.Collections.Generic;
using Assets.Scripts.Services.ServiceLocatorSystem;

namespace Services.EventBusService
{
    public class EventBus : IService
    {
        private readonly Dictionary<string, List<EventBusAction>> _subscribers;

        public EventBus()
        {
            _subscribers = new Dictionary<string, List<EventBusAction>>();
        }

        public void Subscribe<T>(string eventName, EventBusAction action) where T : EventBusArgs
        {
            if(!_subscribers.ContainsKey(eventName))
                _subscribers.Add(eventName, new List<EventBusAction>());
            
            _subscribers[eventName].Add(action);
        }

        public void Unsubscribe<T>(string eventName, EventBusAction action) where T : EventBusArgs
        {
            if (!_subscribers.ContainsKey(eventName))
                return;

            _subscribers[eventName].Remove(action);
        }

        public void Raise(string eventName, EventBusArgs args)
        {
            if(!_subscribers.TryGetValue(eventName, out var subscribers))
                return;

            foreach (var subscriber in subscribers)
            {
                subscriber(args);
            }
        }
    }
}