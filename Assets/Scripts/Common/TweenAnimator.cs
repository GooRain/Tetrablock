using Common.Extensions;
using DG.Tweening;
using UnityEngine;

namespace Common
{
    public class TweenAnimator : MonoBehaviour
    {
        [SerializeField] private Transform animatingTransform;
        [SerializeField] private Ease ease;
        [SerializeField] private LoopType loopType;
        [SerializeField] private int loopsCount = -1;
        [SerializeField] private float duration;
        [SerializeField] private float scale;

        private void Start()
        {
            animatingTransform.DoIfNotNull(t => t.DOScale(scale, duration)
                .SetEase(ease)
                .SetLoops(loopsCount, loopType)
                .Play());
        }
    }
}
