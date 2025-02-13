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
            // 모든 권한 접근 가능 -> 추후에 방법 변경(특정 버튼들 클릭 불가 또는 여러 Panel로 가로 막기.
            notAllowed.SetActive(false);
        }
        else
        {
            // 클릭 못하고 보기만 가능하도록
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
