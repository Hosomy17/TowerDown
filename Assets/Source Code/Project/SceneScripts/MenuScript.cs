using UnityEngine;
using System.Collections;

public class MenuScript : ScriptGeneric
{
    public GameManagerGeneric gm;

    void Awake()
    {
        gm = GameManagerGeneric.Instance;

        Screen.SetResolution(300, 300, false);
    }

    public void StartGame()
    {
        gm.LoadScene("Game");
    }

    public void Quit()
    {
        gm.CloseGame();
    }

    public void SizeScreen()
    {
        Debug.Log("Alterado resolução");
        if(Screen.width <= 300)
            Screen.SetResolution(500, 500, false);
        else if(Screen.width <= 500)
            Screen.SetResolution(800, 800, false);
        else
            Screen.SetResolution(300, 300, false);
    }
}
