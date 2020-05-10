using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Collider2D))]
    public class PointClickMover : MonoBehaviour
    {
        private Transform _transform;
        private Collider2D _collider2D;

        private Camera _camera;

        private bool isDragging;

        private Vector3 offset;
        private Vector3 mouseWorldPosition;

        private void Awake()
        {
            _transform = transform;
            _camera = Camera.main;
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnMouseDown()
        {
            isDragging = true;

            mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            offset = _transform.position - mouseWorldPosition;
        }

        private void OnMouseDrag()
        {
            mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _transform.position = mouseWorldPosition + offset;
        }

        private void OnMouseUp()
        {
            isDragging = false;
        }
    }
}