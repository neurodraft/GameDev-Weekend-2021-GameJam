using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    private bool creationMode = false;
    // Start is called before the first frame update

    public GameObject dominoOverlayPrefab;

    private GameObject dominoOverlayInstance;
    private Vector3 dominoOverlayOffset;

    private Quaternion dominoRotation = Quaternion.identity;

    public DominosGenerator dominosGenerator;

    public Vector3 dominoDimensions = new Vector3(2, 4, 0.5f);

    public float dominoScale = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Application.LoadLevel (Application.loadedLevel);
        }
 
        if(creationMode){
            if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Mouse1)){
                creationMode = false;
                dominoOverlayInstance.SetActive(false);
                return;
            }

            dominoOverlayInstance.transform.Rotate(0, Input.mouseScrollDelta.y * 450f * Time.deltaTime, 0, Space.Self);            
        
            
            if(Input.GetKey(KeyCode.Z)){
                dominoOverlayInstance.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.Self);
            }
            if(Input.GetKey(KeyCode.X)){
                dominoOverlayInstance.transform.Rotate(0, -90f * Time.deltaTime, 0, Space.Self);
            }
            


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 999f, 1 << 0))
                {
                    Debug.Log(hit.collider.tag);
                    //Debug.Log(hit.collider.name);
                    if(hit.collider.CompareTag("BuildPlane")){

                        dominoOverlayInstance.transform.position = hit.point + dominoOverlayOffset;

                        if(Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Detected click");
                            if(dominoOverlayInstance.GetComponent<DominoOverlay>().canBuild){
                                dominosGenerator.createDomino(dominoOverlayInstance.transform);
                                dominoRotation = dominoOverlayInstance.transform.rotation;
                                Destroy(dominoOverlayInstance);
                                creationMode = false;
                            }
                            
                        }
                    }
                }
        } else {
            if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Mouse1)){
                if(dominoOverlayInstance == null){
                    dominoOverlayInstance = Instantiate(dominoOverlayPrefab, Vector3.zero, dominoRotation, this.transform);

                    dominoScale += 1/4f;

                    Vector3 dimensions = dominoDimensions * dominoScale;
                    dominoOverlayInstance.transform.localScale *= dominoScale;

                    dominoOverlayOffset = new Vector3(0, dimensions.y/2f, 0);
                }else{
                    dominoOverlayInstance.SetActive(true);
                }
                
                creationMode = true;
            }
        }
    }
}
