using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public Transform WorldCenter;
    public float gravityStrength = 9.81f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        var gravityDirection = (WorldCenter.position - transform.position).normalized;
        var gravity = gravityDirection * gravityStrength;

        _rb.AddForce(gravity, ForceMode.Acceleration);
    }
}