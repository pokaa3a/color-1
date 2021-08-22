using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneManager : MonoBehaviour
{
    void Start()
    {
        Map.Instance.Create();
    }

    void Update()
    {
        if (InputHandler.newTouch)
        {
            Vector2 posWorld = Camera.main.ScreenToWorldPoint(InputHandler.touchPos);
            Map.Instance.SetTileColor(posWorld, TileColor.Red);
        }
    }
}
