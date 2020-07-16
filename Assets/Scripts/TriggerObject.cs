using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject[] target;
    public string TargetFunction;
    // Start is called before the first frame update
    void OnTriggerEnter(){
        foreach (GameObject taggy in target){
            taggy.SendMessage(TargetFunction);
        }
        
        //Debug.Log("Boink");
    }
}
