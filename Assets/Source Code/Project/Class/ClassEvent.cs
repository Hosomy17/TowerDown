using UnityEngine;
using System.Collections;

public class ClassEvent : ClassGeneric
{
    public string target;

    void OnTriggerEnter2D(Collider2D c)
    {
        string layer = LayerMask.LayerToName(c.gameObject.layer);

        if (layer == target)
        {
            GameObject.Find("GameManager").GetComponent<GameScript>().CallEvent(gameObject.name);
            Destroy(gameObject);
        }
    }
}
