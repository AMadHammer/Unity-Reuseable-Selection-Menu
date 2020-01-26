using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Say : MonoBehaviour
{
    public string message;

    private void Start()
    {
        Debug.Log("Started Say"); 
    }

    //Customize the code you want to happen when user select the option here
    public void Execute(){
        MessageToPrint(message);
    }

    public void MessageToPrint(string message)
    {
        Debug.Log(message);
    }
}
