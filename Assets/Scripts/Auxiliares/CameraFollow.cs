using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jack = default;
    public float velocidade;

    private Vector3 offset;

    private void Start()
    {
        offset = jack.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = default;
        transform.position = Vector3.SmoothDamp(transform.position, jack.position - offset, ref vel, velocidade * Time.fixedDeltaTime);
    }
}
