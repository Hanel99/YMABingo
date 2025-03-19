using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectPanel : MonoBehaviour
{

    public List<Image> hanelImageList = new List<Image>();

    void Start()
    {
        foreach (var image in hanelImageList)
        {
            // 각 이미지를 각각 다른 속도로 회전시키는 DOTween 코드 추가
            float duration = Random.Range(5f, 10f); // 1초에서 5초 사이의 랜덤한 시간
            image.transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

    }

    public void OnClickAdminMode()
    {
        UIManager.Instance.SetAdminMode();
    }

    public void OnClickRouletteMode()
    {
        UIManager.Instance.SetRouletteMode();
    }
}
