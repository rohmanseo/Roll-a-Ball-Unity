using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    void Update()
    {
        Vector3 movement = new Vector3(15, 30, 45);
        transform.Rotate(movement * Time.deltaTime);
    }
}
