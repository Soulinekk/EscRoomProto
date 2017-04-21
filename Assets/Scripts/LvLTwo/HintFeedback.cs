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
                case "lamp":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed)
                        Feedback.Instance.ShowText("The lamp is missing a bulb", 2f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("Bulb dosnt match lamp and its heating up, I should check when its ready to use", 4f, false);
                    break;
                case "projector":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed)
                        Feedback.Instance.ShowText("I think the slides from aquarium should fit into projector", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("nothing else to do with projector", 2f, false);
                    break;
                case "Screen":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed || lastClickedElement.actualState == InteractivElement.States.Open)
                        Feedback.Instance.ShowText("I can see slides on screen if i put them into projector", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.PhaseOne || lastClickedElement.actualState == InteractivElement.States.PhaseTwo)
                        Feedback.Instance.ShowText("It's to bright to see anything on screen", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.PhaseThree || lastClickedElement.actualState == InteractivElement.States.PhaseFour)
                        Feedback.Instance.ShowText("mby other slides would be more helpfull", 2.5f, false);
                    else
                        Feedback.Instance.ShowText("I should look around", 2.5f, false);
                    break;

                case "heater":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed)
                        Feedback.Instance.ShowText("Heater gives enought heat to dry things", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("I should look around", 2f, false);
                    break;
                case "ElectricBox":
                    if (lastClickedElement.actualState == InteractivElement.States.UnBroken)
                        Feedback.Instance.ShowText("that electric box look damaged i hope i dont lose electricity", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("I should look around", 2f, false);
                    break;
                case "alarmBulb":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed)
                        Feedback.Instance.ShowText("That big red buld looked like some kind of alarm", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("I should look around", 2f, false);
                    break;
                case "vault":
                    if (lastClickedElement.actualState == InteractivElement.States.Closed)
                        Feedback.Instance.ShowText("I should get ready b4 i open that vault, i think alarm will go off", 3f, false);
                    else if (lastClickedElement.actualState == InteractivElement.States.DarkRoom)
                        Feedback.Instance.ShowText("I should do it b4 light went off", 3f, false);
                    else
                        Feedback.Instance.ShowText("I need to hurry", 2f, false);
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
