using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionDetector : MonoBehaviour
{
    private Renderer cubeRenderer;
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            cubeRenderer.material.color = Color.red;
        }
    }
}
