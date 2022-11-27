using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScreen : MonoBehaviour
{
    [SerializeField] private OptionMenu optionMenu;
    public void OnLevelOneClick()
    {
        optionMenu.LoadScene("Level_one");
    }

    public void OnLevelTwoClick()
    {
        optionMenu.LoadScene("Level_two");
    }

    public void OnLevelThreeClick()
    {
        optionMenu.LoadScene("Level_three");
    }
    
    public void OnlevelOnlineClick(){
        optionMenu.LoadScene("OnlineLevel");
    }
}
