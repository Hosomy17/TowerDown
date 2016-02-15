using UnityEngine;
using System.Collections;

public class ClassCircle : ClassEnemy
{
    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;

    public float distanceView;

    void Update ()
    {
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, distanceView, 1 << LayerMask.NameToLayer("Hero"));
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distanceView, 1 << LayerMask.NameToLayer("Hero"));

        if (hitRight)
        {
            FacadeEnemy.Walk(this, Vector2.right);
        }
        else if (hitLeft)
        {
            FacadeEnemy.Walk(this, Vector2.left);
        }
        else
        {
            FacadeEnemy.Idle(this);
        }
    }
}