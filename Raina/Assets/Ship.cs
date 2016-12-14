using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	void Update () {
        Vector3 position = transform.position;
        position.x += 1;
        if (position.x > 250)
        {
            position.x = -position.x;
        }

        transform.position = position;
	}

    void OnParticleTrigger()
    {
        Debug.Log("Collided");
    }
}
