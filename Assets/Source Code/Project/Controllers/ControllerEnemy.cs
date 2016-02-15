using UnityEngine;
using System.Collections;

public class ControllerEnemy : ControllerGeneric
{
    public ClassEnemy classEnemy;

    public override void TrackObject(GameObject gameObject)
    {

    }

    public override void SendInput(System.Collections.Generic.Dictionary<string, object> input)
    {
        string name = (string)input["Name"];

        switch (name)
        {
            case "Directional":
                Vector2 directions = (Vector2)input["Axis"];
                Walk(directions.x);
            break;
        }
    }

    public void Walk(float diretion)
    {
            if (diretion > 0)
            {
                FacadeEnemy.Walk(classEnemy, Vector2.right);
            }
            else if (diretion < 0)
            {
                FacadeEnemy.Walk(classEnemy, Vector2.left);
            }
            else
                FacadeEnemy.Idle(classEnemy);
    }
}
