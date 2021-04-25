using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private bool isCaught = false;
    private GameObject sphere;

    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        sphere = transform.Find("Sphere").gameObject;
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(!isCaught && other.CompareTag("Player")){
            isCaught = true;
            sphere.SetActive(false);
            particleSystem.Play();
        }
    }
}
