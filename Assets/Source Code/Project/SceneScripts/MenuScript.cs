using UnityEngine;
using System.Collections;

public class MenuScript : ScriptGeneric
{
    public GameManagerGeneric gm;
    public GameObject canvas;
    private AudioSource fadeIn;

    void Awake()
    {
        fadeIn = GetComponents<AudioSource>().GetValue(1) as AudioSource;
        gm = GameManagerGeneric.Instance;
        Screen.SetResolution(384, 384, false);
    }

    void Start()
    {
        Invoke("FadeIn",12f);
    }

    public void FadeIn()
    {
        canvas.SetActive(true);
    }

    public void FadeOut()
    {
        canvas.SetActive(false);
        fadeIn.Play();
        Invoke("StartGame", 6f);
    }

    public void StartGame()
    {
        gm.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Egg");
        if (Input.GetKey(KeyCode.H))
            gm.LoadScene("Egg");
        else
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
