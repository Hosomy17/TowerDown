using UnityEngine;
using System.Collections;

public class easter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Exit", 13f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Exit()
    {
        GameManagerGeneric.Instance.CloseGame();
    }
}
