using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightPanelController : MonoBehaviour
{
    [SerializeField]public GameObject[] fieldButtons;
    public Text name_lvl;
    
    //public GameObject redSelect;
    
    private int globalN = 0;
    private int keyCode=0;
    private void Start()
    {
       
        
        int childN = transform.childCount;
        fieldButtons = new GameObject[childN];
        
        //Debug.Log(childN);
        
            for (int i = 0; i < childN; i++)
            {
                    
                    fieldButtons[i] = transform.GetChild(i).gameObject;
                    var T = i;
                   fieldButtons[i].GetComponent<Button>().onClick.AddListener(delegate { OnFieldClicked(T);});
                   
            }
            
            
        
     
    }

  

    
    public void OnFieldClicked(int N)
    {
        name_lvl.text = "Level "+ N;
       // Debug.Log(N);   
        float locScale = 0.3f;

        globalN = N;
        keyCode = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            fieldButtons[i].transform.localScale = Vector3.one;
            fieldButtons[i].transform.GetChild(3).gameObject.SetActive(false);
        }
        fieldButtons[N].transform.localScale += new Vector3(locScale, locScale, locScale);
        
        fieldButtons[N].transform.GetChild(3).gameObject.SetActive(true);

        for (int i = 0; i < keyCode; i++)
        {
            fieldButtons[N].transform.GetChild(i).gameObject.SetActive(true);
        }
        


    }

    // IEnumerator amountCoins(int buttonN)
    // {
    //     
    //     
    //     
    //     
    //     yield return null;
    // }

    private void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.Alpha1)) {keyCode = 1; starCount(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {keyCode = 2; starCount(); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {keyCode = 3; starCount(); }
    }

    void starCount()
    {
        Debug.Log(keyCode);
        for (int i = 0; i < keyCode; i++)
        {
            fieldButtons[globalN].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
