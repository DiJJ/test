using System;
using UnityEngine;

namespace TestTask
{
    public abstract class LifelessEntity : MonoBehaviour, IHitable
    {
        public event Action<Vector3> OnHit = (hit) => { };

        public virtual void Hit(Vector3 point, Vector3 impulse) {
            OnHit.Invoke(impulse);
        }
    }
}
