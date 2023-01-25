using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{

    public GameObject motorCarreteraGO,contadorNumerosGO,controladorCocheGO,cocheGO;
    public MotorCarreteras motorCarreteraScript;
    public Sprite[] sprites;
    public SpriteRenderer contadorNumerosSR;

    void Start()
    {
        StartComponents();
        StartCoroutine(StartCountDown());
    }

    void StartComponents()
    {
        motorCarreteraGO = GameObject.Find("MotorCarreteras");
        motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosSR = contadorNumerosGO.GetComponent<SpriteRenderer>();

        cocheGO = GameObject.Find("Coche");
        controladorCocheGO = GameObject.Find("ControladorCoche");
    }
    
    IEnumerator StartCountDown()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosSR.sprite = sprites[0];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosSR.sprite = sprites[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosSR.sprite = sprites[2];
        motorCarreteraScript.startGame = true;
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);
    }

    void Update()
    {
        
    }
}
