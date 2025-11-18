using System.Runtime.CompilerServices;
using UnityEngine;

public class minirotatearound : MonoBehaviour
{
   public GameObject main;
   public  GameObject miniseals;
    private Vector3 rotationspeed = new Vector3(0, 800, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(main.transform.position, Vector3.up, 300 * Time.deltaTime);
    }
}
