using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageUI : UIPage
{
    public static HomePageUI Instance { get; private set; }


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

}