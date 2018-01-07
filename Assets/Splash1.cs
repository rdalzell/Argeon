using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash1 : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", 4f);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
