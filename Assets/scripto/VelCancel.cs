using UnityEngine;

public class VelCancel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool Yvel;
    public Rigidbody rb;
    void Start()
    {


}

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.linearVelocity;
        vel.z = 0;
        rb.linearVelocity = vel;
    }
}
