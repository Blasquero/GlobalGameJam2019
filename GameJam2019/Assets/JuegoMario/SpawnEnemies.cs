using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemy;
    public float ratio;

    private void Start()
    {
        StartCoroutine(SpawnEnumerator());    
    }

    private IEnumerator SpawnEnumerator()
    {
        while(true)
        {
            Instantiate(enemy, transform, false);

            yield return new WaitForSeconds(ratio);
        }
        
    }
}
