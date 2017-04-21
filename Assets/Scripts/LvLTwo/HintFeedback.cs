using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFeedback : MonoBehaviour {

    public static InteractivElement lastClickedElement;
    void Awake()
    {
        
    }

    public void ShowHint()
    {
        //Feedback.Instance.ShowText("Hi", 2f, true);
        if (lastClickedElement != null)
        {
            Debug.Log(lastClickedElement.gameObject.name);
            switch (lastClickedElement.gameObject.name)
            {
                case "Akwarium":
                    if(lastClickedElement.actualState == InteractivElement.States.UnBroken)
                        Feedback.Instance.ShowText("Mby something heavy could break the aquarium glass?", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("I need to hurry up,the room is filling up with water!", 3f, false);
                    break;
                case "DrawerUp":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed || lastClickedElement.actualState == InteractivElement.States.Open)
                        Feedback.Instance.ShowText("There's a lot of space in drawers to fill up", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("Nothing more i can do with these drawers", 3f, false);
                    break;
                case "DrawerDown":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed || lastClickedElement.actualState == InteractivElement.States.Open)
                        Feedback.Instance.ShowText("There's a lot of space in drawers to fill up", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("Nothing more i can do with these drawers", 3f, false);
                    break;

                default:

                    Feedback.Instance.ShowText("I should look around", 3f, false);
                    break;
            }
        }else
        {
            Feedback.Instance.ShowText("I should look around", 3f, false);
        }


    }




}
