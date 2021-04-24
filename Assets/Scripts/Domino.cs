using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    private bool isStanding = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        //Debug.Log("COLLISION!");
        Domino other;
        if(collision.collider.TryGetComponent<Domino>(out other)){
            //Debug.Log("hitting domino");
            if(other.isStanding){
                //Debug.Log("was standing, now it isn't");
                other.Fall();
                this.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    public void Fall(){
        if(isStanding){
            this.isStanding = false;
            this.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.6f, 1f);
            this.transform.parent.GetComponent<DominosGenerator>().SetCurrentFalling(this);
        }
        
    }
}
