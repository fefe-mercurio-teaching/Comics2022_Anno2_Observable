using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Observer
{
    public class UIManager : MonoBehaviour, IObserver
    {
        [SerializeField] private Text scoreText;

        public void Notify(EventType eventType, EventData data)
        {
            if (eventType == EventType.ScoreChanged)
            {
                ScoreChangedEventData scoreChangedEventData = (ScoreChangedEventData)data;
                scoreText.text = scoreChangedEventData.GetScore().ToString();
            }
        }
    }
}
