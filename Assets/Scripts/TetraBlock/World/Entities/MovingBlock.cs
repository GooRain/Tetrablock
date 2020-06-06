using System;
using System.Linq;
using Common;
using Common.GameEvents;
using Common.Service;
using TetraBlock.Global;
using UnityEngine;

namespace TetraBlock.World.Entities
{
    public class MovingBlock : MonoBehaviour, IDragging
    {
        [SerializeField] private GameEvent onPickupGameEvent;
        [SerializeField] private GameEvent onPlaceGameEvent;

        public MovingCell[] cells;

        public Action<MovingBlock> onPlace;

        private float defaultScale;
        private float animatedScale;
        private float duration;

        private Vector3 startPosition;

        private void Awake()
        {
            var gameConfig = ServiceLocator.Current.Get<Main>().GameConfig;
            defaultScale = gameConfig.DefaultScale;
            animatedScale = gameConfig.AnimatedScale;
            duration = gameConfig.AnimationDuration;
        }

        private void Start()
        {
            EndAnimate();
        }

        public void SetStartPosition(Vector3 newStartPosition)
        {
            startPosition = newStartPosition;
        }

        private void ReturnToStartPosition()
        {
            transform.position = startPosition;
        }

        public void OnPickUp()
        {
            Animate();
            onPickupGameEvent.Raise();
        }

        public void OnMoving()
        {
            foreach (var cell in cells)
            {
                cell.OnDrag();
            }
        }

        public void OnRelease()
        {
            EndAnimate();

            if (cells.Any(cell => !cell.CanBePlaced()))
            {
                ReleaseAllCells();

                ReturnToStartPosition();
            }
            else
            {
                OccupyAllCells();

                onPlace?.Invoke(this);
            }
        }

        private void ReleaseAllCells()
        {
            foreach (var cell in cells)
            {
                cell.OnRelease();
            }
        }

        private void OccupyAllCells()
        {
            foreach (var cell in cells)
            {
                cell.OccupyCurrentCell();
            }

            onPlaceGameEvent.Raise();

            Destroy(gameObject);
        }

        private void Animate()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].Animate(animatedScale, duration);
            }
        }

        private void EndAnimate()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].Animate(defaultScale, duration);
            }
        }
    }
}