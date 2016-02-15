using UnityEngine;
using System.Collections;

public class ClassParticles : ClassGeneric
{
    public void Start()
    {
        Invoke("Kill", 5);
    }
    public void Kill()
    {
        gameObject.Recycle();
    }
}
