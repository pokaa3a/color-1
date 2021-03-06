using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (TurnHandler.Instance.playersTurn)
        {
            // SetEnemyTurnSprite();
            // TurnHandler.Instance.playersTurn = false;
            // EnemyManager.Instance.StartTurn();
            TurnHandler.Instance.SwitchTurn();
        }
    }

    // TODO: Handle IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler

    public void SetPressedSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/end_turn_pressed");
    }

    public void SetUnpressedSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/end_turn_unpressed");
    }

    public void SetEnemyTurnSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/enemys_turn");
    }
}
