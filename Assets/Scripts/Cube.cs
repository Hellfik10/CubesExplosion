using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 100f;
    
    private Renderer _renderer;

    public float SplitChance => _splitChance;
    public bool CanSplit { get; private set; } = true;
    public Rigidbody Rigidbody { get; private set; }

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void Init(float splitChance)
    {
        _splitChance = splitChance;
        CanSplit = GenerateCanSplit();
        _renderer.material.color = Random.ColorHSV();
    }

    private bool GenerateCanSplit()
    {
        float minChance = 0f;
        float maxChance = 100f;

        bool canSplit = Random.Range(minChance, maxChance) <= _splitChance;

        return canSplit;
    }
}
