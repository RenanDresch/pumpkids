using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarJogo : MonoBehaviour
{
    public CanvasGroup fader;
    public AudioSource musica;

    public void Iniciar()
    {
        StartCoroutine(FaderCoroutine());
    }

    public void Sair()
    {
        Application.Quit();
    }

    IEnumerator FaderCoroutine()
    {
        Debug.Log("Fader");
        fader.blocksRaycasts = true;
        while(fader.alpha < 1)
        {
            fader.alpha += 2 * Time.deltaTime;
            musica.volume = 1 - fader.alpha;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
