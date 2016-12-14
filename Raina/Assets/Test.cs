using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided on particle system");
    }
}
