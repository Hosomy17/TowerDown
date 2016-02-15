using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameScript : ScriptGeneric
{
    public Gamepad gamepad;
    public GameObject hero;
    public ClassWreckingBall wreackingBall;
    public GeneratorRoom generatorRoom;
    public Text Rooms;
    public int countEvent;
    public GameManagerGeneric gm;

    void Awake()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 25;
        gm = GameManagerGeneric.Instance;
    }

	void Start ()
    {
        ControllerHero ctrHero = new ControllerHero();
        ctrHero.classHero = hero.GetComponent<ClassHero>();
        gamepad.controller = ctrHero;
	}
	
	void Update ()
    {
	
	}

    public void GameOver()
    {
        Dictionary<string, object> info = new Dictionary<string, object>();
        info.Add("Total Rooms", (countEvent * 10).ToString() );

        gm.SaveInfo(info);
        gm.LoadScene("Game Over");
    }
    
    public void CallEvent(string ev)
    {
        switch(ev)
        {
            case "Event1" :
                wreackingBall.Move();
                AudioSource aud = gameObject.GetComponent<AudioSource>();
                aud.Play();
            break;
            case "Event2" :
                for (int i = 0; i < 10; i++)
                    generatorRoom.GenerateRoom();
                wreackingBall.GoToRoom(++countEvent);
                Rooms.text = "Room: " + countEvent*10;
            break;
        }
    }
}
