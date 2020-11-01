using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosJack : MonoBehaviour
{
    public Transform jack;
    public DragShot dragShot;
    public TrailRenderer trail;
    public float velocidadeEfeito;

    private Renderer[] renderers;
    private float escalaAlvo;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        MudarAura();
        if (dragShot.alvo)
        {
            Possuir();
        }
        else if(dragShot.atirou 
            || dragShot.podeAtirar)
        {
            VoltarAoNormal();
        }
    }

    public void Possuir()
    {
        transform.position = Vector3.Lerp(transform.position, dragShot.alvo.position, velocidadeEfeito * Time.deltaTime);
        jack.localScale = Vector3.Lerp(jack.localScale, Vector3.zero, velocidadeEfeito * Time.deltaTime);
    }

    private void VoltarAoNormal()
    {
        trail.enabled = true;
        jack.localScale = Vector3.Lerp(jack.localScale, Vector3.one * escalaAlvo, velocidadeEfeito * Time.deltaTime);
    }

    public void MoverPara(Vector3 posicao)
    {
        trail.enabled = false;
        trail.Clear();
        transform.position = Vector3.Lerp(transform.position, posicao, velocidadeEfeito * Time.deltaTime);
        jack.localScale = Vector3.Lerp(jack.localScale, Vector3.zero, velocidadeEfeito * Time.deltaTime);
    }

    public void MudarAura()
    {
        foreach(var r in renderers)
        {
            r.material.SetFloat("_Fresnel", 3 - dragShot.tempoDoTiro);
        }
        escalaAlvo = (dragShot.tempoMaximoDoTiro - dragShot.tempoDoTiro) / dragShot.tempoMaximoDoTiro;
        trail.startWidth = .2f * ((dragShot.tempoMaximoDoTiro - dragShot.tempoDoTiro) / 5);
    }
}