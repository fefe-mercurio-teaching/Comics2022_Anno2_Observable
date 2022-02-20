using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class ScoreChangedEventData : EventData
    {
        private int _score;

        public ScoreChangedEventData(int score) => _score = score;
        public int GetScore() => _score;
    }
}
