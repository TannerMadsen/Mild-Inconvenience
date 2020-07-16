using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrime : MonoBehaviour
{
    public GameObject MenuMain;
    public GameObject MenuInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("Scene1");
    }
    public void InfoMenu(){
        MenuMain.SetActive(false);
        MenuInfo.SetActive(true);
    }
    public void CloseInfo(){
        MenuMain.SetActive(true);
        MenuInfo.SetActive(false);
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
