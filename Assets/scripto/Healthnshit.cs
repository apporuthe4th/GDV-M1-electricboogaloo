using JetBrains.Annotations;
using UnityEngine;

public class Healthnshit : MonoBehaviour
{
    public int health;
    public int prevHealth;

    void Start()
    {
        health = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
            Debug.Log("Health: " + health);
        }



        if (health != prevHealth) // check for change
        {
            if (health < 80)
            {
                Debug.Log("ohshiiiiiiiiiiiiiiiiiiittttt");
            }
            if (health < 60)
            {
                Debug.Log("ITBURNSSS");
            }
            if (health < 40)
            {
                Debug.Log("fart");
            }
            if (health < 20)
            {
                Debug.Log("bababoey");
            }
            if (health < 0 )
            {
                Debug.Log("NUMVBER22222222222");
            }
        }
    }
}