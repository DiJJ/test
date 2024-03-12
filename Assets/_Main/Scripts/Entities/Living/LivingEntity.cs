using System;
using UnityEngine;

namespace TestTask
{
    public abstract class LivingEntity : MonoBehaviour, IHitable {
        [SerializeField]
        private int _maxHitPoints;
        
        private int _hitPoints;

        protected int HitPoints {
            get => _hitPoints;
            set {
                _hitPoints = Mathf.Clamp(value, 0, _maxHitPoints);
                if (_hitPoints == 0) {
                    Die();
                    OnDie.Invoke();
                }
            }
        }
        
        public event Action<Vector3> OnHit = (hit) => { };
        public event Action OnDie = () => { };

        private void Awake() {
            HitPoints = _maxHitPoints;
        }
        
        protected virtual void Die() {
            gameObject.SetActive(false);
        }

        public virtual void Hit(Vector3 point, Vector3 impulse) {
            HitPoints -= (int) impulse.magnitude;
            OnHit.Invoke(impulse);
            Debug.Log($"{gameObject.name} was hit. Remaining hit points: {HitPoints}");
        }
    }
}
