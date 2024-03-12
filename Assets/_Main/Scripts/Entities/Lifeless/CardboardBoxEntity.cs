using UnityEngine;

namespace TestTask.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class CardboardBoxEntity : LifelessEntity {
        [SerializeField]
        private int _impulseModifier;
        
        private Rigidbody _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Hit(Vector3 point, Vector3 impulse) {
            base.Hit(point, impulse);
            _rigidbody.AddForceAtPosition(impulse * _impulseModifier, point);
        }
    }
}
