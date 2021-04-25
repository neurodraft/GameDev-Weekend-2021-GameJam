using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject victorymenu;
    public bool activename;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (activename == false) {            
            audioSource.mute = !audioSource.mute;
            victorymenu.SetActive(true);
        }
    }
}
