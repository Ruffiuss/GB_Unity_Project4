using System.Collections.Generic;
using UnityEngine;


namespace Homework6
{
    public sealed class TimeBody : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _recordTime = 5.0f;

        private List<PointInTime> _pointInTimes;
        private Rigidbody2D _rb2D;
        private bool _isRewinding;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _pointInTimes = new List<PointInTime>();
            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                StopRewind();
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

        private void StopRewind()
        {
            _isRewinding = false;
            _rb2D.isKinematic = false;
            _rb2D.velocity = _pointInTimes[0].Velocity;
            _rb2D.angularVelocity = _pointInTimes[0].AngularVelocity;
        }

        private void StartRewind()
        {
            _isRewinding = true;
            _rb2D.isKinematic = true;
        }

        private void Record()
        {
            if (_pointInTimes.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointInTimes.RemoveAt(_pointInTimes.Count - 1);
            }

            _pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation, _rb2D.velocity, _rb2D.angularVelocity));
        }

        #endregion
    }
}