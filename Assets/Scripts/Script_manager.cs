﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_manager : MonoBehaviour
{
    public Boolean flyable = false;
    public int collection = 0;
    public int collection2 = 0;
    public Text score1;
    public Text score2;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = ": " + collection;
        score2.text = ": " + collection2;
        if (collection >= 3)
        {
            flyable = true;
            if (collection2 == 0) { 
            textBox.text = "You can now double jump, kid";
             }
        }
    }
}