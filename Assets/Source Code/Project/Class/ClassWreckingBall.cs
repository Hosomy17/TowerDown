using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClassWreckingBall : ClassEnemy
{
    public Shaker shaker;
    public int distance;
    public int side;
    public float velocity;
    public List<AudioClip> sfx;

    public void Move()
    {
        gameObject.transform.localPosition = new Vector3(300 * side, -224 * distance, -9);
        
        shaker.Shake(3, 1.5f);
        Effect(transform.position, side);
        DestroyRoom(distance);
        BehaviourSound.Play(gameObject, sfx[0]);

        speed = -speed;
        side = -side;

        FacadeEnemy.Walk(this, Vector2.right);
        Invoke("Move", velocity);

        distance++;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        string layer = LayerMask.LayerToName(c.gameObject.layer);
        GameObject obj = c.gameObject;

        switch (layer)
        {
            case "Hero":
                GameObject.Find("GameManager").GetComponent<GameScript>().GameOver();
                break;
            case "Enemy" :
                obj.GetComponent<ClassEnemy>().Kill();
                break;

        }
    }

    private void Effect(Vector3 pos, float direction)
    {
        GameObject obj = Resources.Load("Destroy Room") as GameObject;
        obj = Instantiate(obj);

        Vector3 newRot = obj.transform.eulerAngles;
        if (direction == 1)
            newRot.x = 180;
        else
            newRot.x = 0;

        obj.transform.position = pos;
        obj.transform.eulerAngles = newRot;
    }

    public void GoToRoom(int id)
    {
        for(int i = distance; i < id-1; i++)
        {
            DestroyRoom(i);
        }
        velocity -= 0.1f;
        BehaviourSound.Play(gameObject, sfx[0]);
        distance = id -1;
    }

    private void DestroyRoom(int id)
    {
        GameObject room = GameObject.Find("Room"+id);
        GameObject enemies = GameObject.Find("Room" + id + "/Enemies");
        ClassEnemy[] classEnemy = enemies.GetComponentsInChildren<ClassEnemy>();

        foreach (ClassEnemy enemy in classEnemy)
            enemy.Kill();

        
        Destroy(room);
    }
}
