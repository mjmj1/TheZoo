using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSettingManager : MonoBehaviour
{
    public static RoomSettingManager Instance;

    // 방 설정 팝업과 설정 버튼
    public GameObject settingPopup;
    public GameObject settingBtn;
    // 방장이 컨트롤 가능한 오브젝트
    public TMP_InputField createIF;
    public Button createBtn;
    public TMP_Dropdown numberOfPlayerDd;
    
    // 업데이트 될 텍스트
    public TMP_Text startAndReadyTxt;

    // Join popup gameobject
    public GameObject joinPopup;

    // room name
    public TMP_InputField roomNameIF;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.roomManager)
        {
            // 모든 권한 접근 가능 
            createIF.interactable = true;
            createBtn.interactable = true;
            numberOfPlayerDd.interactable = true;

            // 방장은 시작가능
            startAndReadyTxt.text = Strings.START; // TODO: Start btn should be able to click when all team has joined and has clicked on ready button.

            // 방장에겐 필요없음
            joinPopup.SetActive(false);
        }
        else
        {
            // 팀원은 먼저 참여부터
            joinPopup.SetActive(true);
            settingPopup.SetActive(false);

            // 클릭 못하고 보기만 가능하도록
            createIF.interactable = false;
            createBtn.interactable = false;
            numberOfPlayerDd.interactable = false;

            // 팀원은 준비가능
            startAndReadyTxt.text = Strings.READY;
        }
    }

    public void OnJoinBtnClick()
    {
        // 참여 후 UI 변경
        settingPopup.SetActive(true);
        joinPopup.SetActive(false);
    }

    public void OnOpenBtnClick()
    {
        settingPopup.SetActive(true);
    }

    public void OnCloseBtnClick()
    {
        settingPopup.SetActive(false);
    }

    public void OnLeaveBtnClick()
    {
        SceneManager.LoadScene(Strings.ROOM_SCENE);
    }

    public void OnStartAndReadyBtnClick()
    {
        if(GameManager.Instance.roomManager)
        {

        }
        else
        {

        }
    }
}
