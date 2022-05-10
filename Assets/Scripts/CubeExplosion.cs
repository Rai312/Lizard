using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private int _cubesPerAxis = 1;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _force = 300f;
    [SerializeField] private float _radius = 2f;

    private void Start()
    {
        Invoke("Instantiate", _delay);
    }

    public void Instantiate()
    {
        //pointOfCreation.x
        //Debug.Log("Сработал");
        //for (int x = 0; x < _cubesPerAxis; x++)
        //    for (int y = 0; y < _cubesPerAxis; y++)
        //        for (int z = 0; z < _cubesPerAxis; z++)
        //            //CreateCube(new Vector3(x, y, z));
    }

    public void CreateCube(GameObject[] cubes)
    {


        //cube.transform.localScale = transform.localScale / _cubesPerAxis;
        for (int i = 0; i < cubes.Length; i++)
        {

            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //Renderer rendererCube = cube.GetComponent<Renderer>();
            //rendererCube.material = GetComponent<Renderer>().material;

            //cube.transform.position = pointOfCreation;
            cubes[i].gameObject.SetActive(true);
            cubes[i].GetComponent<Rigidbody>().isKinematic = false;
            cubes[i].GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
            //Rigidbody rigidbody = cube.AddComponent<Rigidbody>();
            //rigidbody.AddExplosionForce(_force, transform.position, _radius);
            //Rigidbody rigidbody = cubes[i].AddComponent()
        }

        //Vector3 firstCube = transform.position - transform.localScale / 2;
        //cube.transform.position = firstCube + Vector3.Scale(pointOfCreation, cube.transform.localScale);


    }
}
