using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosJack : MonoBehaviour
{
    public DragShot dragShot;
    public float velocidadeEfeito;

    private void Update()
    {
        if (dragShot.alvo)
        {
            Possuir();
        }
        else
        {
            VoltarAoNormal();
        }
    }

    public void Possuir()
    {
        transform.position = Vector3.Lerp(transform.position, dragShot.alvo.position, velocidadeEfeito * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, velocidadeEfeito * Time.deltaTime);
    }

    private void VoltarAoNormal()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, velocidadeEfeito * Time.deltaTime);
    }

    public void MoverPara(Vector3 posicao)
    {
        transform.position = Vector3.Lerp(transform.position, posicao, velocidadeEfeito * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, velocidadeEfeito * Time.deltaTime);
    }
}