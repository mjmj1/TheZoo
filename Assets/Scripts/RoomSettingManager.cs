using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSettingManager : MonoBehaviour
{
    public static RoomSettingManager Instance;

    // �� ���� �˾��� ���� ��ư
    public GameObject settingPopup;
    public GameObject settingBtn;
    // ������ ��Ʈ�� ������ ������Ʈ
    public TMP_InputField createIF;
    public Button createBtn;
    public TMP_Dropdown numberOfPlayerDd;
    
    // ������Ʈ �� �ؽ�Ʈ
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
            // ��� ���� ���� ���� 
            createIF.interactable = true;
            createBtn.interactable = true;
            numberOfPlayerDd.interactable = true;

            // ������ ���۰���
            startAndReadyTxt.text = Strings.START; // TODO: Start btn should be able to click when all team has joined and has clicked on ready button.

            // ���忡�� �ʿ����
            joinPopup.SetActive(false);
        }
        else
        {
            // ������ ���� ��������
            joinPopup.SetActive(true);
            settingPopup.SetActive(false);

            // Ŭ�� ���ϰ� ���⸸ �����ϵ���
            createIF.interactable = false;
            createBtn.interactable = false;
            numberOfPlayerDd.interactable = false;

            // ������ �غ񰡴�
            startAndReadyTxt.text = Strings.READY;
        }
    }

    public void OnJoinBtnClick()
    {
        // ���� �� UI ����
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
