using UnityEngine;
using System.Collections;

public class ClassEnemy : ClassGeneric
{
    public float speed;
    public bool isDamage;
    public GameObject kill;

    void Awake()
    {
        kill = Resources.Load("Kill") as GameObject;
    }

    public void Kill()
    {
        gameObject.Recycle();

        FacadeEnemy.Die(this);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
