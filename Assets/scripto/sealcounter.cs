using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class sealcounter : MonoBehaviour
{

    public string sealTag = "seal";


    public TMP_Text uiseal;


    public TMP_Text highcounter;

    int count = 0;
    int highcount = 0;

    void Start()
    {
//STOP FUICKING BREAKINNGNGKADNFKNAFKNANSKFD
        if (uiseal == null)
        {
            var go = GameObject.Find("uicounter");
            if (go != null) uiseal = go.GetComponent<TMP_Text>();
        }
        if (highcounter == null)
        {
            var go = GameObject.Find("highscorecounter");
            if (go != null) highcounter = go.GetComponent<TMP_Text>();
        }

        // Load persisted highscore
        highcount = PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(sealTag))
        {
            count++;
            UpdateUI();

            Destroy(other.gameObject);

            Debug.Log("Seal collected. Total: " + count);
        }
    }

    void UpdateUI()
    {
        if (uiseal != null)
            uiseal.text = "Seals: " + count.ToString();

        if (highcounter != null)
            highcounter.text = "Highscore: " + highcount.ToString();
    }

  
    public void SaveHighscore()
    {
        if (count > highcount)
        {
            highcount = count;
            PlayerPrefs.SetInt("Highscore", highcount);
            PlayerPrefs.Save();
            Debug.Log("New Highscore: " + highcount);
            UpdateUI();
        }
    }

    // Optional helper to reset the running count (call after SaveHighscore if you want)
    public void ResetCount()
    {
        count = 0;
        UpdateUI();
    }

    // Editor convenience: make sure a BoxCollider on this GameObject is a trigger
    void Reset()
    {
        var col = GetComponent<BoxCollider>();
        if (col != null) col.isTrigger = true;
    }
}