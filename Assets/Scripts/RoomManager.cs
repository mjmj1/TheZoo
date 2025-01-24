using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public TextMeshProUGUI username;

    private void Start()
    {
        username.text = StartManager.instance.username + "님 환영합니다.";
    }
    public void OnCreateBtnClikc()
    {
        SceneManager.LoadScene(Strings.ROOM_SETTING_SCENE);
        //SceneManager.LoadScene("NGO_Setup");
    }

    public void OnJoinBtnClick()
    {
        Debug.Log("Join button is clicked!");
    }

    
    public void OnBackBtnClikc()
    {
        SceneManager.LoadScene(Strings.START_SCENE);
    }
}
