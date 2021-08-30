using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MapObject
{
    public class EnemyComponent : MonoBehaviour
    {
        public void CallStartCoroutine(IEnumerator iEnum)
        {
            StartCoroutine(iEnum);
        }
    }

    private int _id = 0;
    public int id
    {
        get => _id;
        set
        {
            _id = value;
            gameObject.name = $"enemy_{_id}";
        }
    }
    private EnemyComponent component;

    public Enemy() { }

    public Enemy(Vector2Int rc) : base(rc)
    {
        gameObject.name = "enemy";

        spriteWH = new Vector2(
            Map.Instance.tileWidth * 0.7f,
            Map.Instance.tileHeight * 0.7f);

        SetPosition(rc);

        spritePath = "Sprites/enemies/minion";
        SetSprite(this.spritePath);

        component = gameObject.AddComponent<EnemyComponent>() as EnemyComponent;
    }

    public void Act()
    {
        component.CallStartCoroutine(PlanNextAction());
    }

    private IEnumerator PlanNextAction()
    {
        return ActionCoroutine();
    }

    private IEnumerator MoveThenAttemptToAttack(List<Vector2Int> rcMove, Vector2Int rcAttack)
    {
        yield return null;
        // Draw path

        // Erase path

        // Draw attack attempt
    }

    private IEnumerator ActionCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        this.rc += new Vector2Int(-1, 0);
        EnemyManager.Instance.OneActionCompleted();
    }
}
