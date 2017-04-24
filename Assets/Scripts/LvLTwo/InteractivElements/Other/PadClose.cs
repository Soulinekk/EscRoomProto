using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadClose : MonoBehaviour {

    public Text ScreenText;
    bool allowPress;
    void Start()
    {
        allowPress = true;
        ScreenText.text = "";
    }

    void CheckCode()
    {
        ///check if there is 4 numbers
        if(ScreenText.text.Length==4)
        {
            allowPress = false;
            if(ScreenText.text == "1234")
            {
                //close all set doors open
                PadLock.correctCode = true;
                gameObject.SetActive(false);
            }
            else{
                StartCoroutine(DeleteCode(1.5f));
            }
        }
    }




    public void PressNumber(string num)             //fkcja dla buttonow
    {
        if (allowPress)
        {
            ScreenText.text += num;
            CheckCode();
        }
    }

    IEnumerator DeleteCode(float time)
    {
        Feedback.Instance.ShowText("**WRONG CODE**", time, true);
        yield return new WaitForSeconds(time);
        ScreenText.text = "";
        allowPress = true;
    }
}
