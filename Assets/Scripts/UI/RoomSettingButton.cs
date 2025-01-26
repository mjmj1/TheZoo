using DG.Tweening;
using UnityEngine;

public class RoomSettingButton : MonoBehaviour
{
    private RectTransform _rectTransform;
    bool _isFolded = true;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    
    public void OnClick()
    {
        _isFolded = !_isFolded;

        if (!_isFolded)
        {
            _rectTransform.DOSizeDelta(new Vector2(_rectTransform.rect.width, 20f), 0.5f);
        }
        else
        {
            _rectTransform.DOSizeDelta(new Vector2(_rectTransform.rect.width, 400f), 0.5f).SetEase(Ease.InFlash);
        }
    }
}
