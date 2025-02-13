using UnityEngine;
using UnityEngine.UI;

public class RoomSettingManager : MonoBehaviour
{
    public GameObject settingPopup;
    public GameObject settingBtn;

    public GameObject notAllowed;

    private void Awake()
    {
        if(GameManager.Instance.roomManager)
        {
            // ��� ���� ���� ���� -> ���Ŀ� ��� ����(Ư�� ��ư�� Ŭ�� �Ұ� �Ǵ� ���� Panel�� ���� ����.
            notAllowed.SetActive(false);
        }
        else
        {
            // Ŭ�� ���ϰ� ���⸸ �����ϵ���
            notAllowed.SetActive(true);
        }
    }
    
    public void OnOpenBtnClick()
    {
        settingPopup.SetActive(true);
    }

    public void OnCloseBtnClick()
    {
        settingPopup.SetActive(false);
    }
}
