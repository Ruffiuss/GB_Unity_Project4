namespace Asteroids
{
    internal sealed class ScoreController
    {
        #region Fields

        private ScoreInterpreter _interpreter;

        #endregion


        #region Properties

        internal int CurrentScore { get; private set; }

        #endregion


        #region ClassLifeCycles

        internal ScoreController(ScoreInterpreter interpreter)
        {
            _interpreter = interpreter;
            CurrentScore = DefaultGameProperties.SCORE_VALUE;
        }

        #endregion


        #region Methods

        internal void AddSource(IScoreSource source)
        {
            source.OnScoreChange += Source_OnScoreChange;
        }

        internal void RemoveSource(IScoreSource source)
        {
            source.OnScoreChange -= Source_OnScoreChange;
        }

        private void Source_OnScoreChange(int value)
        {
            CurrentScore += value;
        }

        #endregion
    }
}