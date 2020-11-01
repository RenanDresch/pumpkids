using UnityEngine;

public class SomColisao : MonoBehaviour
{
    public AudioSource fonteSonora;
    private bool isTrigger;

    private void Start()
    {
        isTrigger = GetComponent<Collider>().isTrigger;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isTrigger)
        {
            fonteSonora.pitch = Random.Range(1f, 2f);
            fonteSonora.PlayOneShot(fonteSonora.clip);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isTrigger)
        {
            fonteSonora.pitch = Random.Range(1f, 2f);
            fonteSonora.PlayOneShot(fonteSonora.clip);
        }
    }
}
