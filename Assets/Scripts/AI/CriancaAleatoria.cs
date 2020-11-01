using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriancaAleatoria : MonoBehaviour
{
    public GameObject[] cabelos;
    public GameObject[] mascaras;
    public Material[] materiaisCabelo;
    public Material[] materiaisCorpo;
    public Renderer[] renderCabelos;
    public Renderer[] renderCorpos;

    public void Start()
    {
        var cabelo = Random.Range(0, cabelos.Length);
        var mascara = Random.Range(0, mascaras.Length);
        var materialCabelo = Random.Range(0, materiaisCabelo.Length);
        var materialCorpo = Random.Range(0, materiaisCorpo.Length);

        for (int i = 0; i < cabelos.Length; i++)
        {
            if(i == cabelo)
            {
                cabelos[i].SetActive(true);
            }
            else
            {
                cabelos[i].SetActive(false);
            }
        }

        for (int i = 0; i < mascaras.Length; i++)
        {
            if (i == mascara)
            {
                mascaras[i].SetActive(true);
            }
            else
            {
                mascaras[i].SetActive(false);
            }
        }

        foreach(var renderCabelo in renderCabelos)
        {
            renderCabelo.material = materiaisCabelo[materialCabelo];
        }

        foreach (var rendererCorpo in renderCorpos)
        {
            rendererCorpo.material = materiaisCorpo[materialCorpo];
        }
    }
}
