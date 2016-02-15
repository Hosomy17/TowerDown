using UnityEngine;
using System.Collections;

public class ClassTriangle : ClassEnemy
{
    
    public GameObject fire;
    public float speedFire;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private bool hit;

    void Start()
    {
        hit = false;
    }

    void Update()
    {
        if (!hit)
        {
            hitRight = Physics2D.Raycast(transform.position, Vector2.right, 400, 1 << LayerMask.NameToLayer("Hero"));
            hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 400, 1 << LayerMask.NameToLayer("Hero"));

            if (hitRight)
            {
                hit = true;
                Fire();
            }
            else if(hitLeft)
            {
                hit = true;
                Fire();
            }
        }
    }

    public void Fire()
    {
        GameObject obj = fire.Spawn();

        obj.name = fire.name;
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.right * speedFire;
        obj.transform.parent = gameObject.transform.parent;

        obj = fire.Spawn();

        obj.name = fire.name;
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.left * speedFire;
        obj.transform.parent = gameObject.transform.parent;

        Invoke("Fire", 3);
    }

    void OnDisable()
    {
        hit = false;
        CancelInvoke();
    }
}
