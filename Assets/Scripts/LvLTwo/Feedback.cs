using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Feedback : Singleton<Feedback>
{
    public Text feedText;
    public GameObject feedPanel;
   // private bool linedup;
    void Awake()
    {
        //linedup = false;
        feedPanel.SetActive(false);
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

        if (feedPanel.active && !ff)
        {
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
        feedPanel.SetActive(false);   
       
    }
}
