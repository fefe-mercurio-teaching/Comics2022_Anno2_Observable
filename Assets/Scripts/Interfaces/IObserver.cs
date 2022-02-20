using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public interface IObserver
    {
        void Notify(EventType eventType, EventData data);
    }
}
