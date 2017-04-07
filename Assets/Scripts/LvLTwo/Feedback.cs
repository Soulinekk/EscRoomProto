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
        feedPanel.SetActive(true);
        feedText.text = s;
        StartCoroutine(ShowTextC(t));
        
    }
    public IEnumerator ShowTextC(float t)
    {
        
        yield return new WaitForSeconds(t);
        feedPanel.SetActive(false);
        feedText.text = "";
    }
}
