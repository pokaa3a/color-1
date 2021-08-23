using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info
{
    // [Public]
    public bool playersTurn = true;

    // [Private]

    // Singleton
    private static Info _instance;
    public static Info Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Info();
            }
            return _instance;
        }
    }

    private Info()
    {

    }
}
