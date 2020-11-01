using System.Collections.Generic;
using UnityEngine;

public class Crianca : MonoBehaviour
{
    public Vector3[] pontos;

    public float velocidade;
    public float espera;

    private float tempo = 0;

    public Animator animador;

    private bool avancando = true;
    private int ponto = 0;

    private Vector3 posicaoInicial;

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            posicaoInicial = transform.position;
        }
        for (int i = 0; i < pontos.Length; i++)
        {
            Gizmos.color = i == ponto ? Color.blue : Color.white;
            Gizmos.DrawSphere(posicaoInicial + pontos[i] + (Vector3.up * 0.04f), 0.05f);
        }
    }

    private void Start()
    {
        posicaoInicial = transform.position;
        tempo = espera;
        avancando = true;
    }

    private void Update()
    {
        if(tempo <= 0)
        {
            tempo = espera;
            ponto += avancando? 1 : -1;
            if(ponto >= pontos.Length -1)
            {
                avancando = false;
            }
            else if(ponto == 0)
            {
                avancando = true;
            }
        }

        else
        {
            tempo -= Time.deltaTime;
        }

        transform.position = Vector3.MoveTowards(transform.position, posicaoInicial + pontos[ponto], velocidade * Time.deltaTime);
        if(Vector3.Distance(transform.position, posicaoInicial + pontos[ponto]) > 0.01f)
        {
            animador.SetBool("Andando", true);
            var rotacaoAlvo = Quaternion.LookRotation(posicaoInicial + pontos[ponto] - transform.position, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacaoAlvo, 5 * Time.deltaTime);
        }
        else
        {
            animador.SetBool("Andando", false);
        }
    }
}
