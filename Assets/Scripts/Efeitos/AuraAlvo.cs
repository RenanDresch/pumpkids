using UnityEngine;

public class AuraAlvo : MonoBehaviour
{
    public Transform raiz;
    public AudioSource fonteSonora;

    private Renderer[] renderers;

    private bool possuido;
    private float velocidadeEfeito = 4.5f;

    private float fresnel = 0;

    public bool Possuido
    {
        get
        {
            return possuido;
        }
        set
        {
            if(value)
            {
                TocarSom();
            }
            possuido = value;
        }
    }

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

    private void TocarSom()
    {
        fonteSonora.pitch = Random.Range(1f, 2f);
        fonteSonora.PlayOneShot(fonteSonora.clip);
    }
}
