using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    Action action;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        ActionManager.Instance.SelectAction(action);
    }

    public void RegisterAction(Action action)
    {
        this.action = action;
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>(this.action.cardSpritePath);
    }
}
