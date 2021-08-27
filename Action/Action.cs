using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    DrawColor
}

public abstract class Action
{
    public ActionType type;
    public string cardSpritePath { get; protected set; }

    public Action()
    {

    }

    public abstract void Act(Vector2 xy);
}
