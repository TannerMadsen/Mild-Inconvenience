using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float Hp;
    // Start is called before the first frame update
    public void TakeDamage(float amount){
        Hp -= amount;
        if(Hp <= 0){
            Destroy(this.gameObject);
        }
    }
}
