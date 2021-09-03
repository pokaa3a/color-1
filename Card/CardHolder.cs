using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHolder
{
    public class CardComponent : MonoBehaviour, IPointerDownHandler,
        IPointerUpHandler, IPointerExitHandler
    {
        const float longPressThreshold = 0.5f;
        Card card;

        bool isPressed = false;    // press in previous frame
        bool isLongPressed = false;
        float pressDownStart;

        void Update()
        {
            if (isPressed && Time.time > pressDownStart + longPressThreshold)
            {
                if (!isLongPressed)
                {
                    CardManager.Instance.LongPressCard(this.card);
                }
                isLongPressed = true;
            }
            else
            {
                if (isLongPressed)
                {
                    CardManager.Instance.StopLongPressCard();
                }
                isLongPressed = false;
            }
        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {

            isPressed = true;
            pressDownStart = Time.time;
        }

        public void OnPointerUp(PointerEventData pointerEventData)
        {
            isPressed = false;
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            isPressed = false;
        }

        public void RegisterCard(Card card)
        {
            this.card = card;
        }
    }

    private Vector2 _uv;
    public Vector2 uv
    {
        get => _uv;
        set
        {
            _uv = value;
            gameObject.transform.localPosition = _uv;
        }
    }

    public Vector2 initPos { get; private set; }
    public int id { get; private set; }
    private GameObject gameObject;
    private CardComponent component;
    private Card card;

    public CardHolder(GameObject gameObject, int id)
    {
        this.gameObject = gameObject;
        initPos = this.gameObject.transform.localPosition;
        component = this.gameObject.AddComponent<CardComponent>() as CardComponent;
        component.RegisterCard(this.card);
        this.id = id;
    }

    public void InserCard(Card newCard)
    {
        this.card = newCard;
        component.RegisterCard(this.card);
        SetSprite(this.card.spritePath);
    }

    private void SetSprite(string spritePath)
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        if (img == null)
        {
            img = gameObject.AddComponent<Image>() as Image;
        }
        img.sprite = Resources.Load<Sprite>(spritePath);
    }
}
