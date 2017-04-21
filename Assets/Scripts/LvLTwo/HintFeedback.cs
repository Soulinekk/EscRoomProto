using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFeedback : MonoBehaviour {

    public static InteractivElement lastClickedElement;
    void Awake()
    {
        
    }

    void ShowHint()
    {
        //Feedback.Instance.ShowText("Hi", 2f, true);
        if (lastClickedElement != null)
        {
            switch (lastClickedElement.gameObject.name)
            {
                case "Akwarium":
                    if(lastClickedElement.actualState == InteractivElement.States.UnBroken)
                        Feedback.Instance.ShowText("Mby something heavy could break the glass?", 2f, true);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 2f, true);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 2f, true);

                    else
                        Feedback.Instance.ShowText("I need to hurry up!", 2f, true);
                    break;

                default:

                    Feedback.Instance.ShowText("I should look araund", 2f, true);
                    break;
            }
        }


    }




}
