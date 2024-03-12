using UnityEngine;
using UnityEngine.InputSystem;

namespace TestTask
{
    public class PlayerShooting : MonoBehaviour {
        
        [SerializeField]
        private Transform _camera;
        [SerializeField]
        private float _maxDistance;
        [SerializeField]
        private int _hitImpulse;
        [SerializeField]
        private LayerMask _layerMask;

        private void OnShoot(InputValue value) {
            Shoot(_camera.position, _camera.forward);
        }

        private void Shoot(Vector3 origin, Vector3 direction) {
            bool castResult = Physics.Raycast(origin, direction, out RaycastHit hit, _maxDistance, _layerMask);
            
            if (castResult == false)
                return;

            if (hit.collider.TryGetComponent(out IHitable hitable)) {
                hitable.Hit(hit.point, direction.normalized * _hitImpulse);
            }
        }
    }
}
