using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoOverlay : MonoBehaviour
{
    public bool canBuild = true;
    private MeshCollider meshCollider;

    private Material material;
    private Color originalAlbedo;
    // Start is called before the first frame update
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        material = GetComponent<MeshRenderer>().material;
        originalAlbedo = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(canBuild && !other.CompareTag("BuildPlane")){
            Debug.Log("Can't Build");
            canBuild = false;
            material.color = new Color(1f, 0.5f, 0.5f, 0.5f);
        }
    }
    void OnTriggerExit(Collider other){
        if(!canBuild && !other.CompareTag("BuildPlane")){
            Debug.Log("Can Build");
            canBuild = true;
            material.color = originalAlbedo;
        }
    }


    
}
