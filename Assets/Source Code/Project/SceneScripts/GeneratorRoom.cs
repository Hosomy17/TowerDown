using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorRoom : MonoBehaviour
{
    public List<GameObject> rooms;
    public List<GameObject> enemies;
    public int roomsTotal;
    public char exitSide;
    public GameObject objEvent;
    public GameObject rip;
    private int highRip;

    void Start()
    {
        highRip = PlayerPrefs.GetInt("Last Room", -1);
        for (int i = 0; i < 20; i++)
            GenerateRoom();

    }

    public void GenerateRoom()
    {
        

        char exitSide;
        GameObject room;
        GameObject obj;

        int id;
        id = Random.Range(0, rooms.Count);
        room = (GameObject)rooms[id];

        Vector3 pos;
        pos = Vector3.zero;
        pos.y = -roomsTotal * (32 * 7);

        if (highRip == roomsTotal)
        {
            GameObject r = (GameObject)Instantiate(rip);
            r.transform.parent = transform;
            r.transform.localPosition = pos;
        }

        GameObject ev = (GameObject)Instantiate(objEvent);
        ev.name = objEvent.name;
        ev.transform.parent = transform;
        ev.transform.localPosition = pos;

        obj = (GameObject) Instantiate(room);
        obj.name = "Room" + roomsTotal;
        obj.transform.parent = transform;
        obj.transform.localPosition = pos;

        exitSide = room.name.ToCharArray()[6];

        roomsTotal++;
        
        if (this.exitSide == 'R')
        {
            obj.transform.localEulerAngles = new Vector3(270, 180, 0);

            this.exitSide = (exitSide == 'L') ? 'R' : 'L';
        }
        else
        {
            obj.transform.localEulerAngles = new Vector3(270, 0, 0);

            this.exitSide =  exitSide;
        }

        GenerateEnemies(obj);
    }

    public void GenerateEnemies(GameObject room)
    {
        GameObject parent = GameObject.Find("Rooms/"+room.name+"/Enemies");
        Transform[] posEnemies = parent.GetComponentsInChildren<Transform>();

        GameObject enemy;
        GameObject obj;
        string type;
        int id;

        bool type2 = true;
        bool type3 = false;
        if (Random.Range(0, 2) == 0)
        {
            type2 = !type2;
            type3 = !type3;
        }

        foreach(Transform pos in posEnemies)
        {
            type = pos.gameObject.name;
            switch(type)
            {
                case "Type1" :
                    id = Random.Range(0, 2);
                    enemy = enemies[id];

                    obj = enemy.Spawn(pos.position);
                    obj.transform.parent = parent.transform;
                    obj.name = enemy.name;

                    break;
                case "Type2" :
                    if(type2)
                    {
                        id = 2;
                        enemy = enemies[id];

                        obj = enemy.Spawn(pos.position);
                        obj.transform.parent = parent.transform;
                        obj.name = enemy.name;
                    }
                    break;
                case "Type3" :
                    if(type3)
                    {
                        id = 3;
                        enemy = enemies[id];

                        obj = enemy.Spawn(pos.position);
                        obj.transform.parent = parent.transform;
                        obj.name = enemy.name;
                    }
                    break;
            }
            if(pos.name.Substring(0,4) == "Type")
                Destroy(pos.gameObject);
            
        }
       // Destroy(parent);
    }
}
