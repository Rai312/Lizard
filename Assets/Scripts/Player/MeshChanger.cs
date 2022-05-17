using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MeshChanger : MonoBehaviour
{
    [SerializeField] private Mesh _targetMesh;
    [SerializeField] private Material _targetMaterial;

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    private void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    public void ChangeMesh()
    {
        _skinnedMeshRenderer.sharedMesh = _targetMesh;
        _skinnedMeshRenderer.material = _targetMaterial;
    }
}
