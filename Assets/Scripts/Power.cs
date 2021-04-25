using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private bool isCaught = false;
    private GameObject sphere;
    private GameObject domino;

    private ParticleSystem particleSystem;

    public UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UI").gameObject.GetComponent<UI>() ;
        sphere = transform.Find("Sphere").gameObject;
        domino = sphere.transform.Find("Domino").gameObject;
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        sphere.transform.localPosition = new Vector3(0, Mathf.Sin(Time.time) * 0.5f, 0);
        domino.transform.localRotation = Quaternion.Euler(new Vector3(45f, Mathf.Sin(Time.time) * 360, 0));

    }

    void OnTriggerEnter(Collider other){
        if(!isCaught && other.CompareTag("Player")){
            isCaught = true;
            sphere.SetActive(false);
            particleSystem.Play();
            if(ui != null){
                ui.IncrementDominoAmount();
            }
        }
    }
}
