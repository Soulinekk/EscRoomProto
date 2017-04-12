using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Feedback : Singleton<Feedback>
{
    public Text feedText;
    public GameObject feedPanel;

    void Awake()
    {
        
        feedPanel.SetActive(false);
    }
    public void ShowText(string s,float t)
    {
        //if (feedText.text == "")
       // {
            feedPanel.SetActive(true);
            feedText.text = s;
            StartCoroutine(ShowTextC(t));
       // }
        
    }
    private IEnumerator ShowTextC(float time)
    {
        
        yield return new WaitForSeconds(time);
        feedPanel.SetActive(false);
        feedText.text = "";
    }
}
