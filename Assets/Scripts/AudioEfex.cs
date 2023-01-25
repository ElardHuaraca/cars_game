using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEfex : MonoBehaviour
{

    public AudioClip[] sonidosACList;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void FXSonidoChoque()
    {
        audioSource.clip = sonidosACList[0];
        audioSource.Play();
    }
    
    public void FXSonidoMusica()
    {
        audioSource.clip = sonidosACList[1];
        audioSource.Play();
    }
}
