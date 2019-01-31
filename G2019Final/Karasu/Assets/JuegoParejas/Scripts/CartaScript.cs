using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaScript : MonoBehaviour {

    public int parejaCarta;
    public Sprite reverso;
    public Sprite anverso;

    public bool volteada = false;


    public void SetReverso(Sprite reverso) {
        this.reverso = reverso;
        this.GetComponent<SpriteRenderer>().sprite = reverso;
    }
    public void SetAnverso(Sprite anverso) {
        this.anverso = anverso;
    }

    public void Swap() {
        if (!volteada){
            this.GetComponent<SpriteRenderer>().sprite = anverso;
        }
        else {
            this.GetComponent<SpriteRenderer>().sprite = reverso;
        }
        volteada = !volteada;
    }

    public int GetParejaCarta() {
        return this.parejaCarta;
    }

    public void SetParejaCarta(int pareja) {
        this.parejaCarta = pareja;
    }

}
