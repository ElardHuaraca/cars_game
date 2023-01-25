using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject cronometroGO, audioFXGO;
    public Cronometro cronometroScript;
    public AudioEfex audioFXScript;

    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();
        audioFXGO = GameObject.FindObjectOfType<AudioEfex>().gameObject;
        audioFXScript = audioFXGO.GetComponent<AudioEfex>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coche>() != null)
        {
            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo -= 20;
            Destroy(this.gameObject);
        }
    }
}
