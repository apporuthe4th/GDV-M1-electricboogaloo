using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerr2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource bazinga = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || Input.GetKey(KeyCode.G))
        {
            if (gameObject.tag == "Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Trigger entered by Player");
            // Add your logic here
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(GetComponent<Collider>());
    }
}
