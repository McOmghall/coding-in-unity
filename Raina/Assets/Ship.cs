using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    public float metersPerSecond = 1;

	void Update () {
        Vector3 position = transform.localPosition;
        position.x = position.x + Time.deltaTime * metersPerSecond;
        if (position.x - 3 > 0.001f)
        {
            position.x = -position.x;
        }

        transform.localPosition = position;
	}
}
