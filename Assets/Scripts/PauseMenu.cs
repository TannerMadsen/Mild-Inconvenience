using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool CanPause;
    public GameObject PauseThing;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController PlayerScript;
    public bool Paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && CanPause){
            if(Paused){
                Unpause();
            }else{
                Pause();
            }
        }
    }
    public void Pause(){
        PauseThing.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        PlayerScript.enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0;
        Paused = true;
    }
    public void Unpause(){
        PauseThing.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerScript.enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        Paused = false;
    }
    public void QuitToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
