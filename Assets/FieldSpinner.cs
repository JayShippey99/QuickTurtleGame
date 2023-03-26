using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpinner : MonoBehaviour
{
    public float spinSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed);

    }
}
