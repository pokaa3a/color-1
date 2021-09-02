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
        Map.Instance.InitializeTowers();
        PlayerManager.Instance.Create();
        EnemyManager.Instance.Create();
        CardManager.Instance.RefreshHandCards();
    }
}
