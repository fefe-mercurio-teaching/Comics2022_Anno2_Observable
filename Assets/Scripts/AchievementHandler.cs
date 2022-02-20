using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class AchievementHandler : MonoBehaviour, IObserver
    {
        private List<Achievement> _achievements = new List<Achievement>();
        
        private void Unlock(Achievement achievement)
        {
            if (_achievements.Contains(achievement)) return;
            
            _achievements.Add(achievement);
            
            Debug.Log(achievement);
        }
        
        public void Notify(EventType eventType, EventData data)
        {
            if (eventType == EventType.ScoreChanged)
            {
                ScoreChangedEventData scoreChangedEventData = (ScoreChangedEventData)data;
                if (scoreChangedEventData.GetScore() >= 5)
                {
                    Unlock(Achievement.FivePoints);
                }
            }
        }
    }
}