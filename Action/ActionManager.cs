using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
    // Singleton
    private static ActionManager _instance;
    public static ActionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ActionManager();
            }
            return _instance;
        }
    }

    private ActionManager()
    {

    }
}
