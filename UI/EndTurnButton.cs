using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Info.Instance.playersTurn)
        {
            SetEnemyTurnSprite();
            Info.Instance.playersTurn = false;
            EnemyManager.Instance.StartTurn();
        }
    }

    // TODO: Handle IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler

    private void SetPressedSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/end_turn_pressed");
    }

    private void SetUnpressedSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/end_turn_unpressed");
    }

    private void SetEnemyTurnSprite()
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/UI/buttons/enemys_turn");
    }
}
