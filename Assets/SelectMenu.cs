using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    public List<GameObject> menuItems;
    public GameObject EntryMenuOption;

    private bool buttonAlreadyPressedFlag = false;
    private int selectedOptionIndex;
    private int lastSelectedOptionIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedOptionIndex = 0; 
        lastSelectedOptionIndex = 0;
        menuItems[selectedOptionIndex].gameObject.GetComponent<MenuOption>().setFocused(); //focus the first option from the menu
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMenuNavigation_UpDown();
        KeyboardMenuExecute_Enter();


        if (selectedOptionIndex != lastSelectedOptionIndex)
        {
            menuItems[lastSelectedOptionIndex].gameObject.GetComponent<MenuOption>().unsetFocused();
            lastSelectedOptionIndex = selectedOptionIndex;
            menuItems[selectedOptionIndex].gameObject.GetComponent<MenuOption>().setFocused();
        }
    }

    private void KeyboardMenuNavigation_UpDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !buttonAlreadyPressedFlag)
        {
            if (selectedOptionIndex != 0)
            {
                selectedOptionIndex--;
            }
            Debug.Log("optionsIndex: " + selectedOptionIndex);
            buttonAlreadyPressedFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !buttonAlreadyPressedFlag)
        {
            if (selectedOptionIndex < menuItems.Count-1)
            {
                selectedOptionIndex++;
            }
            Debug.Log("optionsIndex: " + selectedOptionIndex);
            buttonAlreadyPressedFlag = true;
        }
        else
        {
            buttonAlreadyPressedFlag = false;
        }
    }

    private void KeyboardMenuExecute_Enter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            menuItems[selectedOptionIndex].gameObject.GetComponent<MenuOption>().ExecuteCommand();
        }
    }
}
