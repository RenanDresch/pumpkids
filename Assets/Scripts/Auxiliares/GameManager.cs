using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DragShot dragShot;
    public EfeitosJack efeitos;
    public Transform checkPoint;

    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = dragShot.jack.transform.position;
    }

    private void Update()
    {
        if(dragShot.atirou)
        {
            if(dragShot.tempoDoTiro >= dragShot.tempoMaximoDoTiro)
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
            VoltarAoCheckPoint();
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

        if (Vector3.Distance(dragShot.jack.position, posicaoAlvo) < 0.01f)
        {
            dragShot.podeAtirar = true;
            if(checkPoint)
            {
                var auraAlvo = checkPoint.GetComponent<AuraAlvo>();
                if(auraAlvo)
                {
                    auraAlvo.possuido = true;
                }
                dragShot.alvo = checkPoint;
                efeitos.Possuir();
            }
        }
    }

    private void Errou()
    {
        foreach(var semente in dragShot.sementesTemporarias)
        {
            semente.coletada = false;
        }

        dragShot.sementesTemporarias.Clear();

        dragShot.tempoDoTiro = 0;
        dragShot.atirou = false;

        dragShot.jack.velocity = Vector3.zero;
        dragShot.jack.Sleep();  
    }
}
