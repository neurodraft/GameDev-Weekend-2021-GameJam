using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private bool creationMode = false;
    // Start is called before the first frame update

    public GameObject dominoOverlayPrefab;

    private GameObject dominoOverlayInstance;
    private Vector3 dominoOverlayOffset;

    private Quaternion dominoRotation = Quaternion.identity;

    public DominosGenerator dominosGenerator;

    public float dominoScale = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creationMode){
            if(Input.GetKey(KeyCode.Z)){
                dominoOverlayInstance.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.Self);
            }
            if(Input.GetKey(KeyCode.X)){
                dominoOverlayInstance.transform.Rotate(0, -90f * Time.deltaTime, 0, Space.Self);
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.collider.name);
                    if(hit.collider.name == "WorldPlane"){
                        dominoOverlayInstance.transform.position = hit.point + dominoOverlayOffset;

                        if(Input.GetMouseButtonDown(0)){
                            dominosGenerator.createDomino(dominoOverlayInstance.transform);
                            dominoRotation = dominoOverlayInstance.transform.rotation;
                            Destroy(dominoOverlayInstance);
                            creationMode = false;
							Time.timeScale = 1.0f;
                        }
                    }
                }
        } else {
            if(Input.GetKeyDown(KeyCode.C)){
                dominoOverlayInstance = Instantiate(dominoOverlayPrefab, Vector3.zero, dominoRotation, this.transform);

                dominoScale += 1/4f;

                Vector3 dimensions = dominoOverlayInstance.transform.localScale * dominoScale;
                dominoOverlayInstance.transform.localScale = dimensions;

                dominoOverlayOffset = new Vector3(0, dominoOverlayInstance.transform.localScale.y/2f, 0);
                creationMode = true;
				
				if (Time.timeScale == 1.0f){
					Time.timeScale = 0.5f;
				}
            }
        }
    }
}
