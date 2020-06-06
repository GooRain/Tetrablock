using Common.Pool;
using UnityEngine;

namespace TetraBlock.World.Entities
{
    public class PoolableParticle : MonoBehaviour, IPoolable
    {
        [SerializeField] private ParticleSystem playingParticleSystem;

        private bool loop = false;
        private float duration = 0f;

        public bool Loop => loop;
        public float Duration => duration;

        private void Awake()
        {
            var mainModule = playingParticleSystem.main;
            loop = mainModule.loop;
            duration = mainModule.duration;
        }

        public void OnPush()
        {
            playingParticleSystem.Stop(true);
            gameObject.SetActive(false);
        }

        public void OnPull()
        {
            gameObject.SetActive(true);
        }

        public void OnCreate()
        {
            playingParticleSystem.Stop(true);
            gameObject.SetActive(false);
        }

        public void PlayOn(Vector3 position)
        {
            transform.position = position;
            playingParticleSystem.Play(true);
        }
    }
}