using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 100f;

    public event Action<Cube> ObjectUpdated;

    public void UpdateRaycastFromMouse()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.red);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                ObjectUpdated?.Invoke(cube);
            }
        }
    }
}
