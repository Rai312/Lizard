using UnityEngine;

public class Paintable : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _poisonTargetColor;
    [SerializeField] private Material _bodyMaterial;

    private void Awake()
    {
        _bodyMaterial.color = _startColor;
    }

    public void PaintMaterial()
    {
        _bodyMaterial.color = _poisonTargetColor;
    }
}
