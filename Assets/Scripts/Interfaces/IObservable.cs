using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void Notify(EventType eventType, EventData data);
    }
}