using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    public float metersPerSecond = 1;
    public float startingRain = 0;

    [ReadOnly] public float rain = 0;

    void Start() {
        rain = startingRain;
    }

	void Update () {
        Vector3 position = transform.localPosition;
        position.x = position.x + Time.deltaTime * metersPerSecond;
        if (position.x - 1000 > 0.001f)
        {
            position.x = -position.x;
        }

        transform.localPosition = position;
	}

    void OnParticleCollision(GameObject particles) {
        rain++;
    }
}
