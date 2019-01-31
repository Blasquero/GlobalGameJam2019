using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit()
    {
        Application.Quit(); 

    }
    public void creditsButton()
    {
        gameObject.GetComponent<Animator>().SetBool("menu", false);
    }
    public void BackButton()
    {
        gameObject.GetComponent<Animator>().SetBool("menu", true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Diary");
    }
}
