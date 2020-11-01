using UnityEngine;

public class ColisorSemente : MonoBehaviour 
{
    public Collider colisor;
    public bool coletada;

    private Vector3 tamanhoOriginal;

    private void Start()
    {
        tamanhoOriginal = transform.localScale;
    }

    public void Update()
    {
        colisor.enabled = !coletada;
        if (coletada)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 12 * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, tamanhoOriginal, 12 * Time.deltaTime);
        }
    }
}
