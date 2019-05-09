using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffector : MonoBehaviour
{
    public float viscosity;

    private void OnTriggerStay(Collider collision)
    {
        if(transform.position.y-0.6f > collision.transform.position.y)
        collision.GetComponent<Rigidbody>().velocity += (transform.up + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f))) * viscosity;
    }
}