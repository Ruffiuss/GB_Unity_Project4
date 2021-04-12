using System.Collections.Generic;
using UnityEngine;


namespace Homework6
{
    internal sealed class MementoManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _recordTime = 5.0f;
        private readonly TimeBody _mementoBody;

        private List<PointInTime> _pointInTimes;

        private bool _isRewinding;

        #endregion


        #region ClassLifeCycles

        public MementoManager(TimeBody timeBody)
        {
            _pointInTimes = new List<PointInTime>();
            _mementoBody = timeBody;
        }

        #endregion


        #region UnityMethods

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ManageInput(true);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                ManageInput(false);
            }
        }

        private void FixedUpdate()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        #endregion


        #region Methods

        private void Rewind()
        {
            if (_pointInTimes.Count > 1)
            {
                PointInTime pointInTime = _pointInTimes[0];
                transform.position = pointInTime.Position;
                transform.rotation = pointInTime.Rotation;
                _pointInTimes.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointInTimes[0];
                transform.position = pointInTime.Position;
                transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        private void Record()
        {
            if (_pointInTimes.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointInTimes.RemoveAt(_pointInTimes.Count - 1);
            }

            _pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation, _mementoBody._rb2D.velocity, _mementoBody._rb2D.angularVelocity));
        }

        private void ManageInput(bool isPressed)
        {
            if (isPressed)
            {
                StartRewind();
            }
            else
            {
                StopRewind();
            }
        }

        private void StartRewind()
        {
            _isRewinding = true;
            _mementoBody._rb2D.isKinematic = true;
        }

        private void StopRewind()
        {
            _isRewinding = false;
            _mementoBody._rb2D.isKinematic = false;
            _mementoBody._rb2D.velocity = _pointInTimes[0].Velocity;
            _mementoBody._rb2D.angularVelocity = _pointInTimes[0].AngularVelocity;
        }

        #endregion
    }
}