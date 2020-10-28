using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target = default;

    private Vector3 offset;

    private void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = default;
        transform.position = Vector3.SmoothDamp(transform.position, target.position - offset, ref vel, 15 * Time.deltaTime);
    }
}
