using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    public GameObject motorCarretera;
    public MotorCarreteras motorCarreterasScript;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciFinal;
    
    void Start()
    {
        motorCarretera = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarretera.GetComponent<MotorCarreteras>();

        txtTiempo.text = "01:00";
        txtDistancia.text = "0";
        tiempo = 20;
    }
    
    void Update()
    {
        if (motorCarreterasScript.startGame && !motorCarreterasScript.endGame)
        {
            CalculateTimeDistance();
        }

        if (tiempo <=0 && !motorCarreterasScript.endGame)
        {
            motorCarreterasScript.endGame = true;
            motorCarreterasScript.GameState();
            txtDistanciFinal.text = ((int)distancia).ToString() + " mts";
        }
    }

    void CalculateTimeDistance()
    {
        distancia += Time.deltaTime * motorCarreterasScript.velocidad;

        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
