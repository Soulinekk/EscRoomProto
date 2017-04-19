using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Feedback : Singleton<Feedback>
{
    public Text feedText;
    public GameObject feedPanel;
    private bool inLine;
   // private bool linedup;
    void Awake()
    {
        inLine = false;
        //linedup = false;
        feedPanel.SetActive(false);
    }
    void LateUpdate()
    {
        if (!feedPanel.active && !inLine)
            Player.allowClick = true;
    }

  

    public void ShowText(string s,float t,bool forceFeed)
    {
        //if (feedText.text == "")
        // {
           // StopAllCoroutines();
            StartCoroutine(ShowTextC(s,t,forceFeed));
       // }
        
    }
    private IEnumerator ShowTextC(string s,float time,bool ff)
    {
        Player.allowClick = false;
        if (feedPanel.active && !ff)
        {
            inLine = true;
            //linedup = true;
            while (feedText.text != "")
            {
                yield return null;
            }
        }
        //linedup = false;
        feedPanel.SetActive(true);
        feedText.text = s;
        yield return new WaitForSeconds(time);
        feedText.text = "";
        if (!inLine)
        {
            feedPanel.SetActive(false);             //dunno how to check if second panel is active ... yet
            Player.allowClick = true;
        }
        
        
        inLine = false;
    }
}
