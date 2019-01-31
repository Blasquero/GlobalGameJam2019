using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectFinish : MonoBehaviour {

    public ParticleSystem pEmit1, pEmit2, pEmit3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(CargarDiary());
        pEmit1.Play();
        pEmit2.Play();
        pEmit3.Play();
    }

    private IEnumerator CargarDiary() {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Diary");
    }
}
