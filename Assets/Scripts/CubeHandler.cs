using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _rayCaster.ObjectUpdated += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _rayCaster.ObjectUpdated -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube oldCube)
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        if (oldCube.GenerateCanSplit())
        {
            List<Cube> newCubes = _cubeSpawner.Spawn(oldCube);

            foreach (Cube cube in newCubes)
            {
                explodableObjects.Add(cube.Rigidbody);
            }

            _exploder.Explode(oldCube.transform.position, explodableObjects);
        }

        _cubeSpawner.Destroy(oldCube);
    }
}
