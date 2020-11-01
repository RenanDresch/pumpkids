using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DragShot : MonoBehaviour
{
    public GameManager gm;

    public Rigidbody jack;

    public Transform alvo;

    public Collider colisor;

    public float velocidadeTiro = 2;

    public Vector2 posicaoInicial;
    public Vector2 posicaoFinal;
    public Vector2 direcao;

    public bool podeAtirar = true;
    public bool atirou = false;
    public bool mirando = false;

    public float tempoMaximoDoTiro;
    public float tempoDoTiro;

    public GameObject prefabExplosao;

    public List<ColisorSemente> sementesTemporarias;

    public AudioSource fonteDeSom;
    public AudioSource fonteDeSomCarregamento;
    public AudioClip disparo;

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
                fonteDeSomCarregamento.volume = 1;
                fonteDeSomCarregamento.pitch = .2f;
                posicaoInicial = Vector3.zero;
                posicaoFinal = posicaoInicial;
                mirando = true;
                Cursor.visible = false;
            }
            else if (mirando && Input.GetMouseButtonUp(0))
            {
                fonteDeSomCarregamento.volume = 0;
                mirando = false;
                tempoDoTiro = 0;
                posicaoFinal += new Vector2(Input.GetAxis("Mouse X") * 100, Input.GetAxis("Mouse Y") * 100);
                posicaoFinal = Vector3.ClampMagnitude(posicaoFinal, 1500);
                Disparar();
                podeAtirar = false;
                atirou = true;
                Cursor.visible = true;
                fonteDeSom.pitch = 1.5f;
                fonteDeSom.PlayOneShot(disparo);
            }
            if(mirando)
            {
                posicaoFinal += new Vector2(Input.GetAxis("Mouse X") * 100, Input.GetAxis("Mouse Y") * 100);
                direcao = posicaoInicial - posicaoFinal;
                posicaoFinal = Vector3.ClampMagnitude(posicaoFinal, 1500);
                fonteDeSomCarregamento.pitch = (posicaoFinal.magnitude / 1500) + 0.2f;
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

        var velocidade = new Vector3(direcao.x, 0, direcao.y) * velocidadeTiro;

        jack.AddForce(velocidade, ForceMode.Impulse);

        if (alvo)
        {

            var auraAlvo = alvo.GetComponent<AuraAlvo>();
            if (auraAlvo)
            {
                auraAlvo.Possuido = false;
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
                    auraAlvo.Possuido = true;
                }
                sementesTemporarias.Clear();
            }
            var colisorParede = other.GetComponent<ColisorParede>();
            if (colisorParede)
            {
                Instantiate(prefabExplosao, transform.position, Quaternion.identity);
                jack.velocity = Vector3.zero;
                jack.Sleep();
            }
            var colisorSemente = other.GetComponent<ColisorSemente>();
            if (colisorSemente)
            {
                gm.sementesColetadas++;
                sementesTemporarias.Add(colisorSemente);
                colisorSemente.coletada = true;
            }
        }
    }
}
