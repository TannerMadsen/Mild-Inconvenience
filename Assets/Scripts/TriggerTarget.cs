using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTarget : MonoBehaviour
{
    public Transform targetpos;
    public float MoveSpeed;
    public bool dooropening;
    public bool IsWinTrigger;
    public GameObject WinScreen;
    public PauseMenu pauseObj;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController PlayerScript;
    // Start is called before the first frame update
    public void DoorOpen(){
        //Debug.Log("fwoosh");
        dooropening = true;
    }
    public void OnTriggerEnter(){
        if(IsWinTrigger){
            Win();
        }
    }
    void Update(){
        if(dooropening){
            transform.position = Vector3.MoveTowards(transform.position, targetpos.position, MoveSpeed * Time.deltaTime);
        }
    }
    public void Win(){
        WinScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        PlayerScript.enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0;
        pauseObj.CanPause = false;
        
    }
}
