using UnityEngine;
using System.Collections;

public static class FacadeHero
{
    public static void Attack(ClassHero classHero)
    {
        
        //BehaviourPhysics.Force(classHero.gameObject, Vector2.right * classHero.faceRight, classHero.forceAttack);
        BehaviourPhysics.Move(classHero.gameObject, Vector2.right * classHero.faceRight, classHero.forceAttack);

        BehaviourAnimation.Play(classHero.gameObject, "Attack");

        if (!classHero.isAttack)
        {
            AudioClip audio = classHero.sfx[2];
            BehaviourSound.Play(classHero.gameObject, audio);
        }
    }

    public static void Damage(ClassHero classHero)
    {
        classHero.life--;
        if(classHero.life <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameScript>().GameOver();
        }

        GameObject.Find("GameManager").GetComponent<ManagerCamera>().DamageEffect();

        BehaviourAnimation.Play(classHero.gameObject, "Damage");

        AudioClip audio = classHero.sfx[1];
        BehaviourSound.Play(classHero.gameObject, audio);
    }

    public static void Guard(ClassHero classHero)
    {
        AudioClip audio = classHero.sfx[3];
        BehaviourSound.Play(classHero.gameObject, audio);
    }

    public static void Idle(ClassHero classHero)
    {
        BehaviourPhysics.Move(classHero.gameObject, Vector2.right, 0);

        BehaviourAnimation.Play(classHero.gameObject, "Idle");
    }

    public static void Jump(ClassHero classHero)
    {
        BehaviourPhysics.Force(classHero.gameObject, Vector2.up, classHero.forceJump);

        AudioClip audio = classHero.sfx[0];
        BehaviourSound.Play(classHero.gameObject, audio);
    }

    public static void Walk(ClassHero classHero, Vector2 directions)
    {
        BehaviourPhysics.Move(classHero.gameObject, directions, classHero.speed);

        BehaviourAnimation.Flip(classHero.gameObject, directions);
        BehaviourAnimation.Play(classHero.gameObject, "Walk");
        
    }
}
