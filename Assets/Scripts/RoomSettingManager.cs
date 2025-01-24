using UnityEngine;
using UnityEngine.UI;

public class RoomSettingManager : MonoBehaviour
{
    public GameObject background;

    public void OnCreateBtnClikc()
    {
        background.SetActive(false);
    }
}
