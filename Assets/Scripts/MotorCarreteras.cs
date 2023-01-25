using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public float velocidad;
    public bool startGame, endGame, exitScreen;
    public GameObject contenedorCalles, startCalle, endCalle, cameraGO, cocheGO, audioFXGO, bgFinalGO;
    public GameObject[] contenedorCallesList;
    private int numberCalle, i,contador;
    private float sizeCalle;
    private Vector2 screenSize;
    private Camera cameraCOM;
    public AudioEfex audioFXScript;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (startGame && !endGame)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            
            if (startCalle.transform.position.y + sizeCalle < screenSize.y && !exitScreen)
            {
                exitScreen = true;
                DestroyCalle();
            }
        }

    }

    void StartGame() 
    {
        contenedorCalles = GameObject.Find("ContenedorCalles");

        cameraGO = GameObject.Find("Main Camera");
        cameraCOM = cameraGO.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);

        audioFXGO = GameObject.Find("AudioEfex");
        audioFXScript = audioFXGO.GetComponent<AudioEfex>();

        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject; 

        EngineSpeed();
        SearchCalles();
        ScreenSize();
    }

    public void GameState()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXSonidoMusica();
        bgFinalGO.SetActive(true);
    }

    void SearchCalles()
    {
        contenedorCallesList = GameObject.FindGameObjectsWithTag("Calle");
        
        foreach (GameObject calle in contenedorCallesList)
        {
            calle.transform.parent = contenedorCalles.transform;
            calle.SetActive(false);
            calle.name = "Calle0FF_" + i;
            i++;
        }

        CreateCalle();
    }
    
    void CreateCalle()
    {
        contador++;
        numberCalle = Random.Range(0, contenedorCallesList.Length);
        GameObject calle = Instantiate(contenedorCallesList[numberCalle]);
        calle.SetActive(true);
        calle.name = "Calle_" + contador;
        calle.transform.parent = gameObject.transform;
        PositionCalle();
    }

    void PositionCalle()
    {
        startCalle = GameObject.Find("Calle_"+(contador-1));
        endCalle = GameObject.Find("Calle_" + contador);
        SizeCalle();
        endCalle.transform.position = new Vector3(startCalle.transform.position.x, startCalle.transform.position.y + sizeCalle, startCalle.transform.position.z);
        exitScreen = false;
    }

    void SizeCalle()
    {
        for (int i = 0; i < startCalle.transform.childCount; i++)
        {
            if (startCalle.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float sizePieza = startCalle.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                sizeCalle = sizeCalle + sizePieza;
            }
        }
    }

    void EngineSpeed()
    {
        velocidad = 14;
    }

    void ScreenSize()
    {
        screenSize = new Vector2(0, cameraCOM.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f);
    }

    void DestroyCalle()
    {
        Destroy(startCalle);
        sizeCalle = 0;
        startCalle = null;
        CreateCalle();
    }
}
