using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_music : MonoBehaviour
{
    public AudioClip bcgMusic;
    // Use this for initialization
    void Start () {
        AudioSource.PlayClipAtPoint (bcgMusic, transform.position);
    }
   
    // Update is called once per frame
    void Update () {
       
    }
}
