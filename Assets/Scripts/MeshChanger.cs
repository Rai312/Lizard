using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Mesh _targetMesh;
    [SerializeField] private Material _targetMaterial;

    private Mesh _startMesh;
    private Material _startMaterial;

    public bool IsChanged = false;


    private void Start()
    {
        _startMesh = _skinnedMeshRenderer.sharedMesh;
        _startMaterial = _skinnedMeshRenderer.material;
    }

    private void Update()
    {
        if (IsChanged)
        {
            _skinnedMeshRenderer.sharedMesh = _targetMesh;
            _skinnedMeshRenderer.material = _targetMaterial;
        }
        else
        {
            _skinnedMeshRenderer.sharedMesh = _startMesh;
            _skinnedMeshRenderer.material = _startMaterial;
        }
    }
}
