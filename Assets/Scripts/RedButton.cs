using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private bool isActivated = false;
    private bool fullyPressed = false;
    private Transform button;
    private Vector3 originalPosition;

    private Vector3 pressedPosition = new Vector3(0, 0.5f, 0);

    private float timer = 0;

    private ParticleSystem particleSystem;

    public UI ui;
    // Start is called before  the first frame update
    void Start()
    {
        if (ui == null)
        {
            ui = GameObject.Find("UI").gameObject.GetComponent<UI>();
        }
        button = transform.Find("Button");
        originalPosition = button.localPosition;

        particleSystem = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if(isActivated && !fullyPressed){
            timer = Mathf.Clamp(timer + Time.deltaTime, 0, 1);
            button.localPosition = Vector3.Lerp(originalPosition,
                                pressedPosition,
                                timer);
            
            if(button.localPosition == pressedPosition){
                fullyPressed = true;
                particleSystem.Play();
                //ui.Win();
            }
        }
        if(fullyPressed){
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10, Time.deltaTime * 2f);            
        }
    }

    void OnTriggerEnter(Collider other){
        Domino domino;
        if(other.CompareTag("Player") ||
            other.TryGetComponent<Domino>(out domino))
        {
            isActivated = true;
        }
    }
}
