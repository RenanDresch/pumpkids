﻿using TMPro;
using UnityEngine;

public class ContadorTempo : MonoBehaviour
{
    private float tempoInicial;
    public TMP_Text contador;

    private void Start()
    {
        tempoInicial = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        var minutos = Mathf.FloorToInt((Time.timeSinceLevelLoad - tempoInicial)/60);
        var segundos = (Time.timeSinceLevelLoad - tempoInicial) - (minutos * 60);
        contador.text = $"{minutos:00}:{segundos:00}";
    }
}