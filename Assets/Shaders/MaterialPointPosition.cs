using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPointPosition : MonoBehaviour
{
    public MeshRenderer mr;
    // Update is called once per frame
    void Update()
    {
        mr.material.SetVector("_Point", transform.position);
    }
}
