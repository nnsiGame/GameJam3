using DG.Tweening;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Update()
    {
        // ���߂ɗ����t���[���� true �ɂȂ�
        if (Music.IsJustChangedBar())
        {
            DOTween
                .To(value => OnRotate(value), 0, 1, 0.5f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => transform.localEulerAngles = new Vector3(0, 0, 0))
            ;
        }
        // ���ɗ����t���[���� true �ɂȂ�
        else if (Music.IsJustChangedBeat())
        {
            DOTween
                .To(value => OnScale(value), 0, 1, 0.1f)
                .SetEase(Ease.InQuad)
                .SetLoops(2, LoopType.Yoyo)
                ;
            
        }
    }

    private void OnScale(float value)
    {
        var scale = Mathf.Lerp(1, 1.2f, value);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnRotate(float value)
    {
        var rot = transform.localEulerAngles;
        rot.z = Mathf.Lerp(0, 360, value);
      transform.localEulerAngles = rot;
    }
}