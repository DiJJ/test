using System;
using UnityEngine;

namespace TestTask {
    public interface IHitable {
        public void Hit(Vector3 point, Vector3 impulse);
        public event Action<Vector3> OnHit;
    }
}
