using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scale : MonoBehaviour
{
    private void Update()
    {
        
        // ���ɗ����t���[���� true �ɂȂ�
      if (Music.IsJustChangedBeat())
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

  
}

