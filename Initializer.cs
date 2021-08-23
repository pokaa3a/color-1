using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Initializer : MonoBehaviour
{
    public static bool playersTurn = true;

    void Start()
    {
        Map.Instance.Create();
        PlayerManager.Instance.Create();
        EnemyManager.Instance.Create();
    }
}
