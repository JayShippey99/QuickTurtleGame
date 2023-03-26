using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpinner : MonoBehaviour
{
    public float spinSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed);

    }
}
