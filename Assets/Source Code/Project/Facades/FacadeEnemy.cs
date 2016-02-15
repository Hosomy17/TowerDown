using UnityEngine;
using System.Collections;

public class FacadeEnemy
{
    public static void Idle(ClassEnemy classEnemy)
    {
        BehaviourPhysics.Move(classEnemy.gameObject, Vector2.right, 0);
    }

    public static void Walk(ClassEnemy classEnemy, Vector2 directions)
    {
        BehaviourPhysics.Move(classEnemy.gameObject, directions, classEnemy.speed);
    }

    public static void Spin(ClassEnemy classEnemy)
    {
        BehaviourPhysics.Torque(classEnemy.gameObject, classEnemy.speed);
    }

    public static void Die(ClassEnemy classEnemy)
    {
        GameObject obj = GameObject.Instantiate(classEnemy.kill);
        obj.transform.position = classEnemy.transform.position;
    }
}