using System;
using System.Linq;
using Common;
using Common.Service;
using DG.Tweening;
using TetraBlock.Global;
using UnityEngine;

namespace TetraBlock.World.Entities
{
    public class MovingBlock : MonoBehaviour, IDragging
    {
        public MovingCell[] cells;

        public Action<MovingBlock> onPlace;

        private float animatedScale;
        private float duration;

        private float defaultScale;

        private Vector3 startPosition;

        private void Awake()
        {
            var gameConfig = ServiceLocator.Current.Get<Main>().GameConfig;
            animatedScale = gameConfig.AnimatedScale;
            duration = gameConfig.AnimationDuration;

            defaultScale = transform.localScale.x;
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

            Destroy(gameObject);
        }

        private void Animate()
        {
            transform.DOScale(animatedScale, duration);
        }

        private void EndAnimate()
        {
            transform.DOScale(defaultScale, duration);
        }
    }
}