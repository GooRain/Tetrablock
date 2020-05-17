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

        private float animatedScale;
        private float duration;

        private float defaultScale;

        private void Awake()
        {
            var gameConfig = ServiceLocator.Current.Get<Main>().GameConfig;
            animatedScale = gameConfig.AnimatedScale;
            duration = gameConfig.AnimationDuration;

            defaultScale = transform.localScale.x;
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
            }
            else
            {
                OccupyAllCells();
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