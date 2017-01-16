using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    /**
     *  Forward acceleration
     */
    public float metersPerSecond = 1;
    public float anglePerSecond = 90;
    public float startingRain = 0;
    public float maxVelocity = 1000;

    [ReadOnly] public float rain = 0;

    private Rigidbody rigidBody;
    private float startingMass;
    private Vector3 oldVelocity;

    void Start() {
        rain = startingRain;
        rigidBody = GetComponent<Rigidbody>();
        startingMass = rigidBody.mass;
    }

    void FixedUpdate() {
        float forward = Input.GetAxis("Vertical");
        forward = (forward > 0 ? forward : 0);

        if (forward > 0) {
            rigidBody.AddForce(metersPerSecond * transform.up, ForceMode.VelocityChange);
        }

        float spin = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, spin * anglePerSecond * Time.deltaTime);

        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y);
        Vector3 trueRotation = transform.localRotation.eulerAngles;
        trueRotation.x = 0;
        trueRotation.y = 0;
        transform.localRotation = Quaternion.Euler(trueRotation);
        oldVelocity = rigidBody.velocity;
    }

    void OnParticleCollision(GameObject particles) {
        rain++;
        rigidBody.mass = startingMass + rain;
    }

    void OnCollisionEnter(Collision collision) {
        transform.rotation = Quaternion.Euler(Vector3.Reflect(oldVelocity, collision.contacts[0].normal));
    }
}
