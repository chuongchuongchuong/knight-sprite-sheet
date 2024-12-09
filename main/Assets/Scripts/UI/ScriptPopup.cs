using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScriptPopup : MonoBehaviour
{
    [SerializeField] private RectTransform popup;

    private void Reset()
    {
        popup = GetComponent<RectTransform>();
    }

    private void Start()
    {
        popup.DOAnchorPosY(3, .5f).SetEase(Ease.OutBounce); // chỗ này là text máu sẽ nổi lên
        popup.GetComponent<Text>().DOFade(0, 1.5f).OnComplete(()
            =>
        {
            Destroy(gameObject);
        });
    }
}