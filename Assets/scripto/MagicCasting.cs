using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;


public class magicbookofwonders : MonoBehaviour

{
    public magicstats magicdatafile; 
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void fart(string woa)
    {
        Debug.Log(woa);
    }
    void Start()
    {
        if (magicdatafile != null)
        {
            Debug.Log("okenough");
        }
        else if (magicdatafile == null)
        {
            Debug.Log("magicdatafile is not found");
        }
        

        fart("holy shiiiiiiiiiiiiiiiiiiiiiitttttttttttttt");

   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2)) {
            if (magicdatafile.spell1Access == true) // CASTING
            {
                magicdatafile.mana -= 10;
                Debug.Log("-10 mana / " + magicdatafile.mana);



            }
            
        }
        
        
            
                

        
    }
}
