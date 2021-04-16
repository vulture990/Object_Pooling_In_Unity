using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(spawn());    
    }
    /*
    void FixedUpdate()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);    
    }
    */
    IEnumerator spawn()
    {
        // Instantiate(gameObject, transform.position, Quaternion.identity);
        ObjectPooler.instance.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawn());
    }
}
