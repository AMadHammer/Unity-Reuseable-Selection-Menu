using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{
    public string GoToMenuName;
    public string GoToSceneFileName;
    public string AddScriptToRunName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setFocused()
    {
        gameObject.GetComponent<Text>().fontSize = 26;
        gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }
    public void unsetFocused()
    {
        gameObject.GetComponent<Text>().fontSize = 18;
        gameObject.GetComponent<Text>().fontStyle = FontStyle.Normal;
    }


    //private fuction to return GameObject based on name. Gah why isn't this easier
    private GameObject FindObject(string name)
    {
        var sceneGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        if (sceneGameObjects.Length > 0)
        {
            foreach (var o in sceneGameObjects)
            {
                if (o.name == name)
                {
                    return o;
                }
            }
        }
        return null;
    }

    public void ExecuteCommand()
    {
        if (GoToMenuName != "" && GoToMenuName != null)
        {
            GameObject nextMenu = FindObject(GoToMenuName);

            nextMenu.SetActive(true);
            gameObject.transform.parent.parent.gameObject.SetActive(false);

        }

        else if (AddScriptToRunName != "" && AddScriptToRunName != null)
        {
            gameObject.AddComponent(Type.GetType(AddScriptToRunName));
        }
        else if (GoToSceneFileName != "" && GoToSceneFileName != null)
        {
            SceneManager.LoadScene(GoToSceneFileName);
        }

    }
}
