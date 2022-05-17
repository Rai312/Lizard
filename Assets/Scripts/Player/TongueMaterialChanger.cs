using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class TongueMaterialChanger : MonoBehaviour
{
    [SerializeField] private Material _iceTongueMaterial;
    [SerializeField] private Material _fireTongueMaterial;
    [SerializeField] private Material _poisonTongueMaterial;

    private SkinnedMeshRenderer _skinnedMeshMaterial;

    private void Start()
    {
        _skinnedMeshMaterial = GetComponent<SkinnedMeshRenderer>();
    }

    public void AssingIceMaterial()
    {
        _skinnedMeshMaterial.material = _iceTongueMaterial;
    }

    public void AssingFireMaterial()
    {
        _skinnedMeshMaterial.material = _fireTongueMaterial;
    }

    public void AssingPoisonMaterial()
    {
        _skinnedMeshMaterial.material = _poisonTongueMaterial;
    }
}
