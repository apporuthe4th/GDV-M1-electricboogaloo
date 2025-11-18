using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnTrigger : MonoBehaviour
{
    public string triggerTag = "Player";
    public float resetDelay = 0f;
    public bool reloadScene = true;
    public Transform spawnPoint;
    public sealcounter sealingit;

    void Start()
    {
        if (sealingit == null)
            sealingit = FindObjectOfType<sealcounter>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(triggerTag) || other.CompareTag(triggerTag))
        {
            if (sealingit != null)
            {
                sealingit.SaveHighscore();
            }

            if (reloadScene)
            {
                if (resetDelay <= 0f)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                else
                    StartCoroutine(ResetAfterDelay());
            }
            else if (spawnPoint != null)
            {
                Debug.Log("maybe somedayu i will make a spawnmpoint");
            }
        }
    }

    System.Collections.IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Reset()
    {
        var col = GetComponent<BoxCollider>();
        if (col != null)
        {
            Debug.Log("dink! ROT");
            col.isTrigger = true;
        }
    }
}