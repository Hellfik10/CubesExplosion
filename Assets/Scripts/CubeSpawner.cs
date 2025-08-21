using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;

    private float _splitChanceModifier = 0.5f;
    private float _scaleModifier = 0.5f;

    private float _minRange = -1;
    private float _maxRange = 1;

    public List<Cube> Spawn(Cube oldCube)
    {
        List<Cube> cubes = new List<Cube>();
        int count = Random.Range(_minCount, _maxCount + 1);

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_prefab, GetRandomPoint(oldCube), Quaternion.identity);
            cube.Init(oldCube.SplitChance * _splitChanceModifier);
            cube.transform.localScale = oldCube.transform.localScale * _scaleModifier;

            cubes.Add(cube);
        }

        return cubes;
    }

    public void Destroy(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private Vector3 GetRandomPoint(Cube cube)
    {
        float xPosition = Random.Range(_minRange, _maxRange + 1) + cube.transform.position.x;
        float yPosition = cube.transform.position.y;
        float zPosition = Random.Range(_minRange, _maxRange + 1) + cube.transform.position.z;

        return new Vector3(xPosition, yPosition, zPosition);
    }
}