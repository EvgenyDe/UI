using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    [SerializeField] private GameObject panelRoot;
    [SerializeField] private GameObject[] emptyStars;
    [SerializeField] private GameObject[] fullStars;
    
    [SerializeField] private GameObject[] levelNumber;

    private int lvlN = 0;

    private int amountStars;
    //private int levelNumber=1;
    public event Action<StarCount> LevelComplete;

// Start is called before the first frame update
    void Start()
    {
        foreach (var fullStar in fullStars)
        {
            fullStar.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           ActivateStars(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateStars(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateStars(3);
        }
    }


    public void onLevelClick(int N)
    {
        lvlN = N;
        panelRoot.SetActive(true);
        panelRoot.transform.localScale = Vector3.one;
    }
    public void onClickOK()
    {
        StartCoroutine(nameof(CoroutineScaler));
        //lvlN+=1;
        for (int i = 0; i < amountStars; i++)
        {
            levelNumber[lvlN-1].transform.GetChild(1).transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        }
        
        
    }

    IEnumerator CoroutineScaler()
    {
        while (panelRoot.transform.localScale!=Vector3.zero)
        {
            panelRoot.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            yield return null;
        }
        StopAllCoroutines();
    }

    private void ActivateStars(int amount)
    {
        for (var i = 0; i < emptyStars.Length; i++)

        {
            fullStars[i].SetActive(i < amount);
        }

        amountStars = amount;
    }
}


