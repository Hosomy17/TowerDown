using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerHero : ControllerGeneric
{
    public ClassHero classHero;

    public override void TrackObject(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }

    public override void SendInput(Dictionary<string, object> input)
    {
        string name = (string) input["Name"];

        switch(name)
        {
            case "Directional":
                Vector2 directions = (Vector2) input["Axis"];
                Walk(directions.x);
            break;
            case "Fire1":
            if (input["State"] == "Down")
                Attack();
            break;
            case "Fire2":
                if(input["State"] == "Down")
                    Jump();
            break;
        }
    }

    public void Attack()
    {
        if(!classHero.isAttack)
        {
            classHero.forceAttack = classHero.initialforceAttack;
            FacadeHero.Attack(classHero);
            classHero.isAttack = true;
        }
    }

    public void Jump()
    {
        
        if (classHero.CheckGrounded())
        {
            FacadeHero.Jump(classHero);
        }
    }

    public void Walk(float diretion)
    {
        if (!classHero.isAttack)
        {
            if (diretion > 0)
            {
                classHero.faceRight = 1;
                FacadeHero.Walk(classHero, Vector2.right);
            }
            else if (diretion < 0)
            {
                classHero.faceRight = -1;
                FacadeHero.Walk(classHero, Vector2.left);
            }
            else
                FacadeHero.Idle(classHero);
        }
    }

    
}
