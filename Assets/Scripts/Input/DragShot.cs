﻿using System.Collections.Generic;
using UnityEngine;

public class DragShot : MonoBehaviour
{
    public Rigidbody jack;

    public Transform alvo;

    public Vector2 posicaoInicial;
    public Vector2 posicaoFinal;

    public bool podeAtirar = true;
    public bool atirou = false;

    public float tempoMaximoDoTiro;
    public float tempoDoTiro;

    public List<ColisorSemente> sementesTemporarias;

    private void Start()
    {
        jack.sleepThreshold = 10;
    }

    private void Update()
    {
        if (podeAtirar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                posicaoInicial = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                tempoDoTiro = 0;
                posicaoFinal = Input.mousePosition;
                Disparar();
                podeAtirar = false;
                atirou = true;
            }
        }
        else
        {
            tempoDoTiro += Time.deltaTime;
        }
    }

    private void Disparar()
    {
        var direcao = (posicaoInicial - posicaoFinal) * 0.05f;

        var velocidade = new Vector3(direcao.x, 0, direcao.y) * 4;

        jack.AddForce(velocidade, ForceMode.Impulse);

        if (alvo)
        {

            var auraAlvo = alvo.GetComponent<AuraAlvo>();
            if (auraAlvo)
            {
                auraAlvo.possuido = false;
            }

            alvo = null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!podeAtirar && atirou)
        {
            var colisorAlvo = other.GetComponent<ColisorAlvo>();
            if (colisorAlvo)
            {
                jack.velocity = Vector3.zero;
                jack.Sleep();
                alvo = colisorAlvo.transform;

                var auraAlvo = colisorAlvo.GetComponent<AuraAlvo>();
                if (auraAlvo)
                {
                    auraAlvo.possuido = true;
                }
                sementesTemporarias.Clear();
            }
            var colisorParede = other.GetComponent<ColisorParede>();
            if (colisorParede)
            {
                jack.velocity = Vector3.zero;
                jack.Sleep();
            }
            var colisorSemente = other.GetComponent<ColisorSemente>();
            if (colisorSemente)
            {
                sementesTemporarias.Add(colisorSemente);
                colisorSemente.coletada = true;
            }
        }
    }
}
