using UnityEngine;

public class AuraAlvo : MonoBehaviour
{
    private Renderer[] renderers;

    public bool possuido;
    public float velocidadeEfeito = 3;

    private float fresnel = 0;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
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
            fresnel -= Time.deltaTime * velocidadeEfeito;
        }
        fresnel = Mathf.Clamp(fresnel, 0, 3);

        foreach(var r in renderers)
        {
            r.material.SetFloat("_Fresnel", fresnel);
        }
    }
}
