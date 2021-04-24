using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DominosGenerator : MonoBehaviour
{
    public GameObject dominoPrefab;

    public GameObject currentFalling;

    public int numberOfDominos = 5;
    void Start()
    {
        float previousZ = this.transform.position.z;
        for(int i = 0; i < numberOfDominos; i++){
            Vector3 dimensions = dominoPrefab.transform.localScale;
            dimensions = dimensions + dimensions * i/4;
            GameObject dominoInstance = Instantiate(dominoPrefab, new Vector3(0, dimensions.y / 2, previousZ), Quaternion.identity, this.transform);
            previousZ = previousZ + dimensions.y / 1.5f;
            dominoInstance.transform.localScale = dimensions;
            dominoInstance.GetComponent<Rigidbody>().mass = dimensions.x * dimensions.y * dimensions.z;
            
            if(i == 0){
                dominoInstance.tag = "Pushable";
                dominoInstance.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject createDomino(Transform t){
        GameObject dominoInstance = Instantiate(dominoPrefab, t.position, t.rotation, this.transform);
        dominoInstance.transform.localScale = t.localScale;
        dominoInstance.GetComponent<Rigidbody>().mass = t.localScale.x * t.localScale.y * t.localScale.z;
        return dominoInstance;
    }

    public void SetCurrentFalling(Domino domino){
        /*LookAtConstraint constraint = Camera.main.GetComponent<LookAtConstraint>();
        if(currentFalling == null){
            constraint.RemoveSource(1);
        }*/
        currentFalling = domino.gameObject;
        /*ConstraintSource source = new ConstraintSource();
        source.sourceTransform = currentFalling.transform;
        source.weight = 1;
        constraint.AddSource(source);*/
    }
}
