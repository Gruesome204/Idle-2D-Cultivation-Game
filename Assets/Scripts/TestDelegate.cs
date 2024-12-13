using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
 
 delegate void MyDelegate();
 MyDelegate attack;
 private void Start() 
 {
      attack = PrimaryAttack;

      //or
    /*Add two functions that are called to one delegate
    attack += PrimaryAttack;
    attack += SecondaryAttack;
    */
 }

 private void Update() 
 {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        if(attack != null)
        {
            attack();
        }
        //or
        //attack?.Invoke();
    }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {   
            if(attack != null)
            {
            attack = PrimaryAttack;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(attack != null)
            {
            attack = SecondaryAttack;
            }
        }
}

 void PrimaryAttack()
 {
    Debug.Log("Use Primary Attack");

 }
 void SecondaryAttack()
 {    
    Debug.Log("Use Secondary Attack");

 }


}
