﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMActivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
         Application.Quit();
    }
}
