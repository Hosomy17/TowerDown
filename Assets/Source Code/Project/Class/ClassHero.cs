using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClassHero : ClassGeneric
{
    public int faceRight;
    public float life;
    public float speed;
    public float forceJump;
    public float initialforceAttack;
    public float forceAttack;
    public bool isJump;
    public bool isAttack;
    public bool isGhost;
    public List<AudioClip> sfx;
    public Image hp;

    void Awake()
    {
        isJump = false;
        isAttack = false;
        isGhost = false;
    }

    void Update()
    {
        if(isAttack)
        {
            
            forceAttack -= 10;
            FacadeHero.Attack(this);
            if(forceAttack <= 0)
            {
                forceAttack = 0;
                isAttack = false;
            }
        }
    }

    public bool CheckGrounded()
    {
        Transform point1 = GameObject.Find("CheckGrounded/Point1").transform;
        Transform point2 = GameObject.Find("CheckGrounded/Point2").transform;
        bool check = Physics2D.Linecast(point1.position, point2.position, 1 << LayerMask.NameToLayer("Ground"));
        return check;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        GameObject obj = c.gameObject;
        string layer = LayerMask.LayerToName(obj.layer);
        if (layer == "Enemy" && !isGhost)
        {
            try
            {
                obj.GetComponent<ClassEnemy>().Kill();
            }
            catch
            {
                Debug.Log(obj);
            }

            if(!isAttack)
            {
                FacadeHero.Damage(this);
            }
            else
            {
                FacadeHero.Guard(this);
            }
            //isGhost = true;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject obj = c.gameObject;
        string layer = LayerMask.LayerToName(obj.layer);
        if (layer == "Enemy" && !isGhost)
        {
            obj.GetComponent<ClassEnemy>().Kill();

            if (!isAttack)
            {
                FacadeHero.Damage(this);
            }
            else
            {
                FacadeHero.Guard(this);
            }
            //isGhost = true;
        }
    }
}
