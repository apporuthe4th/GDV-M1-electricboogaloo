using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class basicmovement : MonoBehaviour

{
    public sealcounter seal;
    GameObject player;
    //GameObject FreeLook_Camera;
    //public Vector3 velocity = Vector3.forward;

    //public Transform holycamera;
    public float MoveSpeed = 500f;
    private Rigidbody rb;
    // slow rolls
    public Vector3 XSLOWposSPEED = new Vector3(0.2f, 0, 0);
    public Vector3 XSLOWnegSPEED = new Vector3(-0.2f, 0, 0);
    // fast rolls
    public Vector3 XposSPEED = new Vector3(1, 0, 0);
    public Vector3 XnegSPEED = new Vector3(-1, 0, 0);
    public Vector3 YposSPEED = new Vector3(0, 1f, 0);
    public Vector3 YnegSPEED = new Vector3(0, -2f, 0);
    public bool cooldown = false;
    public bool SHORT_cooldown = false;
    public bool isGrounded;
    AudioSource dasheffect;
    AudioSource counterEffect;
    AudioSource upwardseffect;

    private System.Collections.IEnumerator ResetCooldown()
    {

        yield return new WaitForSeconds(1.0f);
        cooldown = false;
        Debug.Log("cooldown rest");
    }

    private System.Collections.IEnumerator ResetSUPERSHORTCooldown()
    {

        yield return new WaitForSeconds(0.4f);
        SHORT_cooldown = false;
        Debug.Log("cooldown short rest reset");

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
        //FreeLook_Camera = GameObject.Find("FreeLook_Camera");
        counterEffect = GameObject.Find("Whiplash_Clink.ogg").GetComponent<AudioSource>();
        dasheffect = GameObject.Find("parry-ultrakill").GetComponent<AudioSource>();
        upwardseffect = GameObject.Find("downsound").GetComponent<AudioSource>();


        // Update is called once per frame
    }


    void Update()
    {
        double speed = rb.linearVelocity.x;


        //rb.rotation = holycamera.rotation;
        //FreeLook_Camera.transform.rotation = cammyrotation;
        // total reset

        if (Input.GetKey(KeyCode.H))
        {
            seal.ResetCount();



        }
        // slow rolls
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddForce(XSLOWposSPEED * MoveSpeed * Time.deltaTime, ForceMode.VelocityChange); // X axis positive


        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(XSLOWnegSPEED * MoveSpeed * Time.deltaTime, ForceMode.VelocityChange); // X axis negative
        }

        // counter velocity with opposite key
        if (speed >= 5)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.linearVelocity = Vector3.zero;
                counterEffect.Play();
            }
        }
         if (speed <= -5)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.linearVelocity = Vector3.zero;
                    counterEffect.Play();
                }
            }

            // fast rolls
            if (Input.GetKeyUp(KeyCode.D) && SHORT_cooldown == false)
            {
                rb.AddForce(XposSPEED * MoveSpeed, ForceMode.Impulse); // X axis positive
                dasheffect.Play();
                SHORT_cooldown = true;
                StartCoroutine(ResetSUPERSHORTCooldown());
            }

            if (Input.GetKeyUp(KeyCode.A) && SHORT_cooldown == false)
            {

                rb.AddForce(XnegSPEED * MoveSpeed, ForceMode.Impulse); // X axis negative
                dasheffect.Play();
                SHORT_cooldown = true;
                StartCoroutine(ResetSUPERSHORTCooldown());
            }

            if (Input.GetKeyUp(KeyCode.W) && cooldown == false)
            {
                rb.AddForce(YposSPEED * MoveSpeed, ForceMode.Impulse); // Y axis positive
                upwardseffect.Play();
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

