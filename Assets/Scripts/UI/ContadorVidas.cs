using TMPro;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    public TMP_Text contador;
    public GameManager gm;

    private void Update()
    {
        contador.text = $"{gm.vidas}";
    }
}
