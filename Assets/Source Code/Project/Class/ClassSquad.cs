using UnityEngine;
using System.Collections;

public class ClassSquad : ClassEnemy
{
    public bool isMirror = false;
    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;
    private Gamepad gp;

    void Start()
    {
        gp = gameObject.AddComponent<Gamepad>();
        ControllerEnemy ctl = new ControllerEnemy();
        ctl.classEnemy = this;
        gp.controller = ctl;
        gp.enabled = false;
    }

    void Update()
    {
        if (!isMirror)
        {
            hitRight = Physics2D.Raycast(transform.position, Vector2.right, 400, 1 << LayerMask.NameToLayer("Hero"));
            hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 400, 1 << LayerMask.NameToLayer("Hero"));

            if (hitLeft || hitRight)
            {
                isMirror = true;
                gp.enabled = true;
            }
        }
    }

    void OnDisable()
    {
        gp.enabled = false;
        isMirror = false;
    }
}
