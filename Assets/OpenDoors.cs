using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    bool isOKeyPressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOKeyPressed = true;
            Debug.Log("O key was pressed");
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            isOKeyPressed = false;
            Debug.Log("O key was released");
        }

        if (!isOKeyPressed)
        {
            Debug.Log("Not pressing O");
        }
    }
}
