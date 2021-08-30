using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject
{
    public class MapObjectComponent : MonoBehaviour
    {
        public void CallStartCoroutine(IEnumerator iEnum)
        {
            StartCoroutine(iEnum);
        }
    }

    private Vector2Int _rc = Vector2Int.zero;
    public Vector2Int rc
    {
        get => _rc;
        set
        {
            _rc = value;
            SetPosition(_rc);
        }
    }

    protected GameObject gameObject;
    protected MapObjectComponent component;
    protected string spritePath;
    protected Vector2 spriteWH;

    public MapObject() { }

    public MapObject(Vector2Int rc)
    {
        gameObject = new GameObject();
        component = gameObject.AddComponent<MapObjectComponent>() as MapObjectComponent;
        this.rc = rc;
    }

    public void SetPosition(Vector2Int rc)
    {
        Vector2 xy = Map.Instance.RCtoXY(rc);
        gameObject.transform.position = new Vector3(xy.x, xy.y, -1f);
    }

    public void SetSprite(string spritePath)
    {
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>();
        if (sprRend == null)
        {
            sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        }
        sprRend.sprite = Resources.Load<Sprite>(spritePath);
        // Adjust scale
        gameObject.transform.localScale = new Vector2(
            spriteWH.x / sprRend.size.x,
            spriteWH.y / sprRend.size.y);
    }
}
