using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scale : MonoBehaviour
{
    private void Update()
    {
        
        // ”‚É—ˆ‚½ƒtƒŒ[ƒ€‚Å true ‚É‚È‚é
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

