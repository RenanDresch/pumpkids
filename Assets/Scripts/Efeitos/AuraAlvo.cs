using UnityEngine;

public class AuraAlvo : MonoBehaviour
{
    public Transform raiz;
    private Renderer[] renderers;

    public bool possuido;
    private float velocidadeEfeito = 4.5f;

    private float fresnel = 0;

    private void Start()
    {
        renderers = raiz.GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        Animar();
    }

    public void Animar()
    {
        if (possuido)
        {
            fresnel += Time.deltaTime * velocidadeEfeito;
        }
        else
        {
            fresnel -= Time.deltaTime * velocidadeEfeito * 3;
        }
        fresnel = Mathf.Clamp(fresnel, 0, 3);

        foreach(var r in renderers)
        {
            r.material.SetFloat("_Fresnel", fresnel);
        }
    }
}
