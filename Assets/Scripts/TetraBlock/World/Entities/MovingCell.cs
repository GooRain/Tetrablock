using System;
using Common.Service;
using TetraBlock.Global;
using TetraBlock.Global.Scene;
using TetraBlock.World.Board;
using UnityEngine;

namespace TetraBlock.World.Entities
{
    public class MovingCell : MonoBehaviour
    {
        private Cell _currentCell;

        private GameContext _gameContext;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            enabled = ServiceLocator.Current.Get<Main>().TryGetCurrentContext(out _gameContext);
        }

        public void OnDrag()
        {
            if (!enabled)
            {
                return;
            }

            if (_gameContext.Map.TryGetClosest(_transform.position, out var cell))
            {
                UnhighlightCurrentCell();


                if (!cell.IsOccupied)
                {
                    _currentCell = cell;
                    _currentCell.Highlight();
                }
            }
            else
            {
                UnhighlightCurrentCell();
            }
        }

        public void OnRelease()
        {
            if (enabled && _currentCell)
            {
                _currentCell.Occupy();
                Destroy(gameObject);
            }
        }

        private void UnhighlightCurrentCell()
        {
            if (_currentCell)
            {
                _currentCell.Unhighlight();
                _currentCell = null;
            }
        }
    }
}