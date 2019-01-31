using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DyaryMenu : MonoBehaviour
{
    public GameObject[] pags;   
    public int index;
    public GameObject CurrentPage;

    public void cursorEsquerre()
    {
        index = index - 1;
        if (index < 0) { index = 4; }
    }

    public void cursorDret()
    {
        index = index + 1;
        if (index > 4) { index = 0; }
    }

    public void textAleatori()
    {

        Random text;

    }

    // Update is called once per frame
    void Update()
    {
        CurrentPage.GetComponent<Text>().text = (index + 1 + " / 5");
        for(int i=0; i < pags.Length; i++)
        {
            if (i == index)
            {
                pags[i].SetActive(true);
            }
            else
            {
                pags[i].SetActive(false);
            }
        }

        
    }

    public void platformer()
    {
        Application.LoadLevel("NivelMario");
    }
    public void submarine()
    {
        Application.LoadLevel("JuegoSubmarino");
    }
    public void letters()
    {
        Application.LoadLevel("Hentai scene");
    }
    public void cartas()
    {
        Application.LoadLevel("JuegoParejas");
    }
    public void escopeta()
    {
        Application.LoadLevel("click negro");
    }
}
