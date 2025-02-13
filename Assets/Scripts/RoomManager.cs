using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public TextMeshProUGUI username;
    public GameObject joinPopup;

    private void Start()
    {
        username.text = StartManager.instance.username + "님 환영합니다.";
    }
    public void OnCreateBtnClikc()
    {
        // Players who choose "Create" button will be the Room manager
        GameManager.Instance.roomManager = true;
        // move to Room Setting Scene
        SceneManager.LoadScene(Strings.ROOM_SETTING_SCENE);
        //SceneManager.LoadScene("NGO_Setup");
    }

    public void OnJoinBtnClick()
    {
        joinPopup.SetActive(true);
        // Players who choose "Join" button will be the members
        GameManager.Instance.roomManager = false;
    }

    public void OnCloseBtnClick()
    {
        joinPopup.SetActive(false);
    }

    public void OnBackBtnClick()
    {
        SceneManager.LoadScene(Strings.START_SCENE);
    }
}
