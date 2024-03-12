using UnityEngine;

namespace TestTask.Entities
{
    public class CatEntity : LivingEntity {
        [SerializeField] 
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip[] _catAudioClips;

        [SerializeField]
        private ParticleSystem _particleSystem;

        public override void Hit(Vector3 point, Vector3 impulse) {
            base.Hit(point, impulse);
            
            if (HitPoints == 0)
                return;
            
            _audioSource.PlayOneShot(_catAudioClips[Random.Range(0, _catAudioClips.Length)]);
            _particleSystem.Play();
        }
    }
}
