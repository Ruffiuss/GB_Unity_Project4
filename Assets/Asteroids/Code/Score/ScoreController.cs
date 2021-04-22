namespace Asteroids
{
    internal sealed class ScoreController
    {
        #region Fields

        private ScoreInterpreter _interpreter;

        #endregion


        #region Properties

        internal long CurrentScore { get; private set; }
        internal event System.Action<string> OnScoreChange;

        #endregion


        #region ClassLifeCycles

        internal ScoreController(ScoreInterpreter interpreter)
        {
            _interpreter = interpreter;
            CurrentScore = DefaultGameProperties.SCORE_VALUE;
        }

        #endregion


        #region Methods

        internal void ChangeScore(string value)
        {
            if (int.TryParse(value, out int parsedInt)) CurrentScore = parsedInt;
            if (float.TryParse(value, out float parsedFloat)) CurrentScore = (long)parsedFloat;
        }

        internal void DisplayScore()
        {
            OnScoreChange.Invoke(_interpreter.ToInterpreted(CurrentScore));
        }

        internal void AddSource(IScoreSource source)
        {
            source.OnScoreChange += Source_OnScoreChange;
        }

        internal void RemoveSource(IScoreSource source)
        {
            source.OnScoreChange -= Source_OnScoreChange;
        }

        internal void WathForSourceDestroy(UnityEngine.GameObject sourceGameObject)
        {
            RemoveSource(sourceGameObject.GetComponent<IScoreSource>());
        }

        private void Source_OnScoreChange(int value)
        {
            CurrentScore += value;
            DisplayScore();
        }

        #endregion
    }
}