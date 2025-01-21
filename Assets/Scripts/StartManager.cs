using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // initial page
    public GameObject nicknameObj;
    public TMP_InputField nicknameIpf;
    // after clicking start
    public GameObject startObj;

    // alert
    public GameObject alertPanel;

    // setting panel
    public GameObject settingPanel;

    public void OnStartBtnClick()
    {
        // it repeats nickname object showing or hiding
        if (nicknameObj.activeSelf)
        {
            // it initializes when nickname is empty
            if(string.IsNullOrEmpty(nicknameIpf.text) || string.IsNullOrWhiteSpace(nicknameIpf.text) || nicknameIpf.text == "" || nicknameIpf.text == string.Empty)
            {
                nicknameObj.SetActive(false);
                alertPanel.SetActive(true);
            }
            // otherwise, it moves to room scene
            else
            {
                nicknameObj.SetActive(false);
                startObj.SetActive(false);
                
                SceneManager.LoadScene(Strings.ROOM_SCENE);
            }
        }
        else
        {
            nicknameObj.SetActive(true);
        }
    }

    public void OnCheckBtnClikc()
    {
        ActiveTrueFalse(alertPanel);
    }

    public void OnSettingBtnClick()
    {
        ActiveTrueFalse(settingPanel);
    }

    public void OnSaveBtnClick()
    {
        ActiveTrueFalse(settingPanel);
    }

    public void OnCancelBtnClikc()
    {
        ActiveTrueFalse(settingPanel);
    }

    public void ActiveTrueFalse(GameObject obj)
    {
        if(obj.activeSelf)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }
}
