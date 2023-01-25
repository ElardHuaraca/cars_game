using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundido : MonoBehaviour
{

    public Image fundido;
    public string[] escenas;

    void Start()
    {
        fundido.CrossFadeAlpha(0, 1f, false);
    }

    public void CambiarEscena(int escena)
    {
        fundido.CrossFadeAlpha(1, 1f, false);
        StartCoroutine(CambiarEscena(escenas[escena]));
    }

    IEnumerator CambiarEscena(string escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
    }
}
