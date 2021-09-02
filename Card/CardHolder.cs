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
        CardHolder cardHolder;

        bool isPressed = false;    // press in previous frame
        bool isLongPressed = false;
        float pressDownStart;

        void Update()
        {
            if (isPressed && Time.time > pressDownStart + longPressThreshold)
            {
                if (!isLongPressed)
                {
                    CardManager.Instance.LongPressCard(cardHolder);
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

        public void RegisterCard(CardHolder cardHolder)
        {
            this.cardHolder = cardHolder;
        }
    }

    private string _spritePath;
    public string spritePath
    {
        get => _spritePath;
        set
        {
            _spritePath = value;
            SetSprite(_spritePath);
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

    private void SetSprite(string spritePath)
    {
        Image img = gameObject.GetComponent<Image>() as Image;
        if (img == null)
        {
            img = gameObject.AddComponent<Image>() as Image;
        }
        img.sprite = Resources.Load<Sprite>(spritePath);
    }

    public CardHolder(GameObject gameObject, int id)
    {
        this.gameObject = gameObject;
        initPos = this.gameObject.transform.localPosition;
        component = this.gameObject.AddComponent<CardComponent>() as CardComponent;
        component.RegisterCard(this);
        this.id = id;
    }
}
