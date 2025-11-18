using UnityEngine;

public class rotate : MonoBehaviour
{
    new Vector3 ROTATEE = new Vector3(0, 500, 0);
    new GameObject RotationPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(ROTATEE * Time.deltaTime);
    }
}
