using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // Level manager
    // Use this for initialization
    static GameManager _instance = null;

	void Start () {
        if (_instance)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.LeftControl)){
            if (Application.loadedLevelName == "Level1")
                // Following code adds an addition scene to current/ weeving it
                Application.LoadLevelAdditive("Level2");
            else if (Application.loadedLevelName == "Level2")
                // Following code unloads the scene
                Application.LoadLevel("Level1");
        }

        if (Input.GetButtonDown("Jump"))
            Application.UnloadLevel("Level2");
	}
}
