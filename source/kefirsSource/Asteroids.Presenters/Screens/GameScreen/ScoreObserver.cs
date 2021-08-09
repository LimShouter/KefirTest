using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View.ViewManagers.Screens.GameScreenView;

namespace Asteroids.Presenters.Screens.GameScreen
{
    public class ScoreObserver : IObserver
    {
        private readonly ReactField<int> _maxScore;
        private readonly ReactField<int> _score;
        private readonly IScoreTextView _view;

        public ScoreObserver(ReactField<int> score, ReactField<int> maxScore, IScoreTextView view)
        {
            _score = score;
            _maxScore = maxScore;
            _view = view;
        }

        public void Activate()
        {
            _score.OnNotifyChanged += _view.SetScore;
            _maxScore.OnNotifyChanged += _view.SetMaxScore;
        }

        public void Deactivate()
        {
            _score.OnNotifyChanged -= _view.SetScore;
            _maxScore.OnNotifyChanged -= _view.SetMaxScore;
        }
    }
}