using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour,IPooledObject
{
    public Rigidbody rb;
    public void OnObjSpawn()
    {
        /*
        float xFor = Random.Range(-sideForce, sideForce);
        float yFor = Random.Range(upForce / 2f, upForce);
        float zFor = Random.Range(-sideForce, sideForce);
        */
       
        Vector3 force = Random.onUnitSphere * 20;
        GetComponent<Rigidbody>().velocity=force;
    
      //  StartCoroutine(Spawn());
    }
    /*
    IEnumerator Spawn()
    {
        Vector3 force = Random.onUnitSphere * 20;
        GetComponent<Rigidbody>().velocity = force;
        Instantiate(rb);
        yield return new WaitForSeconds(60f);
        StartCoroutine(Spawn());
    }
    */
}
