using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DominosGenerator : MonoBehaviour
{
    public GameObject dominoPrefab;

    public GameObject currentFalling;

    public int numberOfDominos = 5;

    public float dominoDensity = 1f;

    private Vector3 dominoDimensions = new Vector3(2, 4, 0.5f);

    private float baseMass;
    void Start()
    {
        
        UI ui = GameObject.Find("UI").gameObject.GetComponent<UI>();

        ui.dominosGenerator = this;

        baseMass = dominoDimensions.x * dominoDimensions.y * dominoDimensions.z * dominoDensity;

        float previousZ = this.transform.position.z;
        for(int i = 0; i < numberOfDominos; i++){
            float scale = 1 + i/4.0f;
            Vector3 dimensions = dominoDimensions * scale;
            GameObject dominoInstance = Instantiate(dominoPrefab, new Vector3(this.transform.position.x, dimensions.y / 2, previousZ), Quaternion.identity, this.transform);
            previousZ = previousZ + dimensions.y / 1.5f;
            dominoInstance.transform.localScale = dominoInstance.transform.localScale * scale;
            dominoInstance.GetComponent<Rigidbody>().mass = baseMass * scale;
            
            if(i == 0){
                dominoInstance.GetComponent<Domino>().isPushable = true;
                dominoInstance.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.6f, 1f);
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
        dominoInstance.GetComponent<Rigidbody>().mass = baseMass * t.localScale.x;
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
