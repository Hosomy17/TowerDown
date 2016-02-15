using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameOverScript : ScriptGeneric
{
    public GameManagerGeneric gm;
    public Text totalRooms;

    void Awake()
    {
        gm = GameManagerGeneric.Instance;
    }

    void Start()
    {
        List<string> keys = new List<string>();
        Dictionary<string, object> info;
        string total;

        keys.Add("Total Rooms");

        info = gm.GetInfo(keys);

        total = (string)info["Total Rooms"];
        totalRooms.text = "Total Rooms: "+total;
    }

    public void BackMenu()
    {
        gm.LoadScene("Menu");
    }
}
