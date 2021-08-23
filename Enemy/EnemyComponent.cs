using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start Enemy");
    }

    public void Act()
    {

    }

    private IEnumerator actionCoroutine()
    {
        yield return new WaitForSeconds(1);

        EnemyManager.Instance.OneActionCompleted();
    }
}
