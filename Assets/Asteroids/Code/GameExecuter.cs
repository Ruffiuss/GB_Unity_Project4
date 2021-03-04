namespace Asteroids
{
	internal sealed class GameExecuter : MonoBehavior
	{
		#region Fields

		private readonly Controllers _controllers;
		private float _delataTime;

		#endregion


		#region ClassLifeCycles

		internal GameExecuter(Controllers controllers)
		{
			_controllers = controllers;
		}

		#endregion


		#region UnityMethods

		private void Update()
		{
			_delataTime = Time.delataTime;
			_controllers.Execute(_delataTime);
		}

		#endregion
	}
}