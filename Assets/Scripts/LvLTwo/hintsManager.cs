using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintsManager : MonoBehaviour {
    Camera mainCam;
    System.Random rnd = new System.Random();
    public List<HintItem> hintsItems;
    public bool active = true;
    HintItem lastShowed;
    void Awake()
    {
        mainCam = gameObject.GetComponent<Camera>();
        hintsItems = new List<HintItem>(GameObject.FindObjectsOfType<HintItem>());
        if (active)
        {
            foreach (HintItem item in hintsItems)
            {
                item.randomMode = true;
            }
            StartCoroutine(ShowHints());
        }
    }
    void Update()
    {
        //every x sec after last click show random hint for that area
        //look for click and start new coroutine
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();
                StartCoroutine(ShowHints());
            }
        }
    }

    private IEnumerator ShowHints()
    {
        yield return new WaitForSeconds(4.5f);
        GetRandomItem().AnimNow();
       

        yield return StartCoroutine(ShowHints());
    }

    HintItem GetRandomItem()                    //this will take lot of time :/
    {
        HintItem item = hintsItems[rnd.Next(hintsItems.Count - 1)];
        int i = 0;
        
        while(item.positionLookedFor[i] != mainCam.transform.position || !item.gameObject.active || lastShowed==item)
        {
            if (i == item.positionLookedFor.Count - 1)
            {
                item = hintsItems[rnd.Next(hintsItems.Count- 1)];
            }
            else
            {
                i++;
            }
        }
        lastShowed = item;
        return item;
        
    }

    public void SwitchToRandom()
    {
        StopAllCoroutines();
        active = true;
        foreach (HintItem item in hintsItems)
        {
            item.randomMode = true;
        }
        StartCoroutine(ShowHints());
    }
    public void SwitchToAll()
    {
        StopAllCoroutines();
        active = false;
        foreach (HintItem item in hintsItems)
        {
            item.randomMode = false;
        }
        
    }
    
}
