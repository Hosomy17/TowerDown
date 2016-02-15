using UnityEngine;
using System.Collections;

public class ClassFire : ClassEnemy
{
    void OnTriggerEnter2D(Collider2D c)
    {
        string layer = LayerMask.LayerToName(c.gameObject.layer);

        if(layer == "Ground")
        {
            gameObject.Recycle();
        }
        
    }
}
