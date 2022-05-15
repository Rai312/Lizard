using UnityEngine;

public class MeshChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Mesh _targetMesh;
    [SerializeField] private Material _targetMaterial;

    public void ChangeMesh()
    {
        _skinnedMeshRenderer.sharedMesh = _targetMesh;
        _skinnedMeshRenderer.material = _targetMaterial;
    }
}
