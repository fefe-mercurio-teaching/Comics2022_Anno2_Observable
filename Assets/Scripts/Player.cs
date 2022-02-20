using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class Player : MonoBehaviour, IObservable
    {
        private List<IObserver> _observers = new List<IObserver>();
        
        [SerializeField] private float walkSpeed;
        [SerializeField] private int score;

        [SerializeField] private UIManager uiManager;
        [SerializeField] private AchievementHandler achievementHandler;

        private void Start()
        {
            RegisterObserver(uiManager);
            RegisterObserver(achievementHandler);
        }

        public int Score
        {
            get => score;
            set
            {
                score = value;
                Notify(EventType.ScoreChanged, new ScoreChangedEventData(score));
            }
        }

        private void Update()
        {
            float speedFactor = walkSpeed * Time.deltaTime;
            
            float horizontal = Input.GetAxis("Horizontal") * speedFactor;
            float vertical = Input.GetAxis("Vertical") * speedFactor;
            
            transform.Translate(horizontal, 0f, vertical);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Coin")) return;

            Score++;
            Destroy(other.gameObject);
        }

        public void RegisterObserver(IObserver observer) => _observers.Add(observer);
        public void UnregisterObserver(IObserver observer) => _observers.Remove(observer);
        public void Notify(EventType eventType, EventData data) => _observers.ForEach(o => o.Notify(eventType, data));
    }
}