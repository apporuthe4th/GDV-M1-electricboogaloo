using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class basicmovement : MonoBehaviour

{
    GameObject player;
    //GameObject FreeLook_Camera;
    //public Vector3 velocity = Vector3.forward;

    //public Transform holycamera;
    public float MoveSpeed = 500f;
    private Rigidbody rb;
    public Vector3 XposSPEED = new Vector3(1, 0, 0);
    public Vector3 XnegSPEED = new Vector3(-1, 0, 0);
    public Vector3 YposSPEED = new Vector3(0, 0.2f, 0);
    public Vector3 YnegSPEED = new Vector3(0, -0.2f, 0);
    public bool cooldown = false;
    public bool isGrounded;


    // Change the return type from void to IEnumerator to allow use of 'yield return'
    private System.Collections.IEnumerator ResetCooldown()
    {

        yield return new WaitForSeconds(2.5f);
        cooldown = false;
        Debug.Log("cooldown rest");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
        //FreeLook_Camera = GameObject.Find("FreeLook_Camera");


        // Update is called once per frame
    }


    void Update()
    {

        //rb.rotation = holycamera.rotation;
        //FreeLook_Camera.transform.rotation = cammyrotation;

        if (Input.GetKeyUp(KeyCode.A))
        { 
                rb.AddForce(XposSPEED * MoveSpeed, ForceMode.Impulse ); // X axis positive
            }

            if (Input.GetKeyUp(KeyCode.D))
        {

                rb.AddForce(XnegSPEED * MoveSpeed, ForceMode.Impulse); // X axis negative
        }

        if (Input.GetKeyUp(KeyCode.W) && cooldown == false)
        {
            rb.AddForce(YposSPEED * MoveSpeed, ForceMode.Impulse); // Y axis positive
            cooldown = true;
            StartCoroutine(ResetCooldown());
        }
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.AddForce(YnegSPEED * MoveSpeed, ForceMode.Impulse); // Y axis negative
            Debug.Log("launaosfaljkfaflnl");
            }
    //        Vector3 rotatedVelocity = UnityEngine.Quaternion.Euler(cammyrotation.value.xyz) * velocity;
    //float horizontal = Input.GetAxis("Horizontal");
    //float vertical = Input.GetAxis("Vertical");


    //Vector3 movement = new Vector3(horizontal, 0f, vertical);


    //if (movement.magnitude > 0.1f)
    //{


    //}
}
    
}
