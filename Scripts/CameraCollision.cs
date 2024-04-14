using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasCollided;
    void Start()
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        hasCollided = true;
        Destroy(other.gameObject);
    }
}