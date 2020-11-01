using TMPro;
using UnityEngine;

public class ContadorSementes : MonoBehaviour
{
    public TMP_Text contador;
    public GameManager gm;

    private void Update()
    {
        contador.text = $"{gm.sementesColetadas:00}";
    }
}
