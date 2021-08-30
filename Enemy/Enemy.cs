using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MapObject
{
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

    public Enemy() { }

    public Enemy(Vector2Int rc) : base(rc)
    {
        gameObject.name = "enemy";

        spriteWH = new Vector2(
            Map.Instance.tileWH.x * 0.7f,
            Map.Instance.tileWH.y * 0.7f);

        SetPosition(rc);

        spritePath = "Sprites/enemies/minion";
        SetSprite(this.spritePath);
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
