using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public Gun gun;         

    public bool debug = false;   //make true to display debug msgs

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if(mouse == null) return;

        if(mouse.leftButton.wasPressedThisFrame) {
            if(debug) Debug.Log("Left Mouse Button was pressed this frame");
            
            if(gun != null) {
                gun.Fire();             //calling the gun method on gun variable
            } else {
                if(debug) Debug.Log("There is no gun to fire");
            }
        }
    }
}
