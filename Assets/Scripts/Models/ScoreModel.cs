using System;

namespace Models
{
    public class ScoreModel
    {
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    ScoreChanged?.Invoke(_score);
                    if (_score > RecordScore)
                    {
                        RecordScore = _score;
                    }
                }
            }
        }

        private int _recordScore;
        public int RecordScore
        {
            get => _recordScore;
            set
            {
                if (_recordScore != value)
                {
                    _recordScore = value;
                    RecordScoreChanged?.Invoke(_recordScore);
                }
            }
        }

        public event Action<int> ScoreChanged;
        public event Action<int> RecordScoreChanged;
    }
}
