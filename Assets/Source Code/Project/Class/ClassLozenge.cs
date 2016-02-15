using UnityEngine;
using System.Collections;

public class ClassLozenge : ClassEnemy
{
    void Start()
    {
        Invoke("StartSpin",Random.Range(0,11));
    }

    private void StartSpin()
    {
        FacadeEnemy.Spin(this);
    }
}
