using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public bool activename;
    
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(activename == false) {
                pausemenu.SetActive(true);
            } else {
                pausemenu.SetActive(false);
            }
        }
    }
}
