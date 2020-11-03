using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool jogando = true;
    public DragShot dragShot;
    public EfeitosJack efeitos;
    public Transform checkPoint;

    public AudioSource musica;
    public AudioClip clipeVitoria;
    public AudioClip derrotaClipe;

    public CanvasGroup derrotaCG;
    public CanvasGroup vitoriaCG;

    public int vidas = 5;
    public int sementesColetadas = 0;

    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = dragShot.jack.transform.position;
    }

    private void Update()
    {
        if (jogando)
        {
            if (dragShot.atirou)
            {
                if (dragShot.tempoDoTiro >= dragShot.tempoMaximoDoTiro)
                {
                    Errou();
                }
                else if (dragShot.jack.IsSleeping()
                    && dragShot.alvo == null)
                {
                    Errou();
                }
                else if (dragShot.jack.IsSleeping())
                {
                    checkPoint = dragShot.alvo;
                    dragShot.atirou = false;
                }
            }
            else if (!dragShot.podeAtirar)
            {
                dragShot.colisor.enabled = false;
                VoltarAoCheckPoint();
            }
        }
    }

    private void VoltarAoCheckPoint()
    {
        Vector3 posicaoAlvo;

        if (checkPoint)
        {
            posicaoAlvo = checkPoint.position;
        }
        else
        {
            posicaoAlvo = posicaoInicial;
        }

        efeitos.MoverPara(posicaoAlvo);

        if (Vector3.Distance(dragShot.jack.position, posicaoAlvo) < 0.1f)
        {
            dragShot.transform.position = posicaoAlvo;
            dragShot.podeAtirar = true;
            dragShot.colisor.enabled = true;
            if (checkPoint)
            {
                var auraAlvo = checkPoint.GetComponent<AuraAlvo>();
                if (auraAlvo)
                {
                    auraAlvo.Possuido = true;
                }
                dragShot.alvo = checkPoint;
                efeitos.Possuir();
            }
        }
    }

    private void Errou()
    {
        vidas--;

        if (vidas == 0)
        {
            musica.Stop();
            musica.clip = derrotaClipe;
            musica.loop = false;
            musica.Play();

            jogando = false;
            derrotaCG.alpha = 1;
            derrotaCG.blocksRaycasts = true;
            dragShot.gameObject.SetActive(false);
            return;
        }
        else
        {
            foreach (var semente in dragShot.sementesTemporarias)
            {
                semente.coletada = false;
                sementesColetadas--;
            }

            dragShot.sementesTemporarias.Clear();

            dragShot.tempoDoTiro = 0;
            dragShot.atirou = false;

            dragShot.jack.velocity = Vector3.zero;
            dragShot.jack.Sleep();
        }
    }

    public void Venceu()
    {
        jogando = false;
        musica.Stop();
        musica.clip = clipeVitoria;
        musica.loop = false;
        musica.Play();
        vitoriaCG.alpha = 1;
        vitoriaCG.blocksRaycasts = true;
        dragShot.gameObject.SetActive(false);
    }
}
