using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public AudioSource Sound;
    public GameObject[] buttons;

    public float delay;
    public Sprite lense;
    public int score;
    public GameObject background;
    public int random;



    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(chooseSpot());
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(score >= 12)
        {
            background.GetComponent<Animator>().SetBool("finished", true);
        }
        delay = 3 - (12 / 12 - score * 3);

    }




    public void shootSound()
    {
        Sound.Play();
        
        score++;
        
    }

    public IEnumerator chooseSpot()
    {
        while (true)
        {


            random = Random.Range(0, buttons.Length);

            for (int j = 0; j < buttons.Length; j++)
            {
                if (j == random)
                {
                    buttons[j].GetComponent<Button>().interactable = true;
                    buttons[j].GetComponent<Animator>().SetBool("selected", true);
                }
                else
                {
                    buttons[j].GetComponent<Button>().interactable = false;
                    buttons[j].GetComponent<Animator>().SetBool("selected", false);
                }
            }
            yield return new WaitForSeconds(1f);





        }
    }
}