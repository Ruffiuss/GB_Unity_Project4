using UnityEngine;


namespace Homework6
{
    public sealed class TimeBody : MonoBehaviour
    {
        #region Properties

        internal Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();

        #endregion
    }
}