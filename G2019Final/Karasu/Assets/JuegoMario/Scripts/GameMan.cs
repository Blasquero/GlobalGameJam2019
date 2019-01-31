using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Personaje");
    }

    private void Update()
    {
        if(player.transform.position.y < -12)
        {
            StartCoroutine(restartScene());
        }
    }

    public static IEnumerator restartScene()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
