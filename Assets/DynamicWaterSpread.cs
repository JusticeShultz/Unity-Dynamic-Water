using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWaterSpread : MonoBehaviour
{
    static float YAxis = 6.5f;

    public float SimSlowdown = 0.1f;
    public float FloodCheckInterval = 1.5f;
    public float Density = 0.25f;
    public float MinimumDrain = 0.15f;
    public float DrainIntensity = 0.01f;

	void Start ()
    {
        transform.position = new Vector3(transform.position.x, YAxis, transform.position.z);

        StartCoroutine(ContinueTask());
	}

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, YAxis, transform.position.z), 0.15f);
    }

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(SimSlowdown);

        if (YAxis > MinimumDrain)
        {
            RaycastHit hitObj;

            Ray left = new Ray();
            left.direction = Vector3.left;
            left.origin = transform.position;

            if (!Physics.Raycast(left, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + left.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray right = new Ray();
            right.direction = Vector3.right;
            right.origin = transform.position;

            if (!Physics.Raycast(right, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + right.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray up = new Ray();
            up.direction = Vector3.forward;
            up.origin = transform.position;

            if (!Physics.Raycast(up, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + up.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray down = new Ray();
            down.direction = -Vector3.forward;
            down.origin = transform.position;

            if (!Physics.Raycast(down, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + down.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray topleft = new Ray();
            topleft.direction = new Vector3(-0.5f, 0, 0.5f);
            topleft.origin = transform.position;

            if (!Physics.Raycast(topleft, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + topleft.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray topright = new Ray();
            topright.direction = new Vector3(0.5f, 0, 0.5f);
            topright.origin = transform.position;

            if (!Physics.Raycast(topright, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + topright.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray bottomleft = new Ray();
            bottomleft.direction = new Vector3(-0.5f, 0, -0.5f);
            bottomleft.origin = transform.position;

            if (!Physics.Raycast(bottomleft, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + bottomleft.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }

            Ray bottomright = new Ray();
            bottomright.direction = new Vector3(0.5f, 0, -0.5f);
            bottomright.origin = transform.position;

            if (!Physics.Raycast(bottomright, out hitObj, Density))
            {
                Instantiate(gameObject, transform.position + bottomright.direction * Density, transform.rotation);
                YAxis -= DrainIntensity;
            }
        }
    }

    private IEnumerator ContinueTask()
    {
        StartCoroutine(StartTask());
        yield return new WaitForSeconds(FloodCheckInterval);
        StartCoroutine(ContinueTask());
    }

    private void OnTriggerEnter(Collider collision)
    {
        YAxis += (collision.transform.localScale.x + collision.transform.localScale.y) * 0.001f;
    }

    private void OnTriggerExit(Collider collision)
    {
        YAxis -= Mathf.Clamp(YAxis, 0, (collision.transform.localScale.x + collision.transform.localScale.y) * 0.001f);
    }
}