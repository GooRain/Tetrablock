using System;
using System.Collections;
using Common.Extensions;
using Common.Service;
using TetraBlock.Data;
using TetraBlock.Global;
using TetraBlock.World.Entities;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace TetraBlock.World.Board
{
    public class Cell : MonoBehaviour, IPoint
    {
        [SerializeField] private SpriteRenderer spriteRenderer = default;

        private bool _isOccupied;

        private bool _isHighlighted;

        private Transform _transform;

        private MapConfig _mapConfig;

        public Action onOccupy;

        public Transform Transform => _transform;

        public Vector2 Position { get; private set; }

        public bool IsOccupied => _isOccupied;

        private ParticlePool particlePool;

        public void Initialize(MapConfig mapConfig, Vector3 position)
        {
            _mapConfig = mapConfig;

            _transform = transform;

            Position = position;

            particlePool = ServiceLocator.Current.Get<Main>().ParticlePool;

            spriteRenderer.color = _mapConfig.CellDefaultColor;
        }

        public void Unhighlight()
        {
            spriteRenderer.color = _mapConfig.CellDefaultColor;

            _isHighlighted = false;
        }

        public void Highlight()
        {
            spriteRenderer.color = _mapConfig.CellHighlightedColor;

            _isHighlighted = true;
        }

        public bool CanBeOccupied()
        {
            return !_isOccupied && !_isHighlighted;
        }

        public void Occupy()
        {
            spriteRenderer.color = _mapConfig.CellOccupiedColor;
            _isOccupied = true;
            _isHighlighted = false;

            onOccupy?.Invoke();
        }

        public void Clear()
        {
            spriteRenderer.color = _mapConfig.CellDefaultColor;
            _isOccupied = false;
            _isHighlighted = false;

            var particle = particlePool.Pull();
            particle.PlayOn(Position);

            if (!particle.Loop)
            {
                StartCoroutine(ReturnParticle(particle, particle.Duration));
            }
        }

        private IEnumerator ReturnParticle(PoolableParticle particle, float delay)
        {
            yield return new WaitForSeconds(delay);
            particlePool.Push(particle);
        }
    }
}