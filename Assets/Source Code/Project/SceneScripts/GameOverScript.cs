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
        int high = (int)info["Total Rooms"];
        total = high.ToString();
        totalRooms.text = "Total Rooms: "+total;

        int last = PlayerPrefs.GetInt("High Room", 0);

        if(last < high)
            PlayerPrefs.SetInt("High Room", high);
    }

    public void BackMenu()
    {
        gm.LoadScene("Menu");
    }

    public void BackGame()
    {
        gm.LoadScene("Game");
    }
}
