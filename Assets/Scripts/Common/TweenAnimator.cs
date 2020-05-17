using Common.Extensions;
using DG.Tweening;
using UnityEngine;

namespace Common
{
    public class TweenAnimator : MonoBehaviour
    {
        [SerializeField] private Transform animatingTransform = default;
        [SerializeField] private Ease ease = default;
        [SerializeField] private LoopType loopType = default;
        [SerializeField] private int loopsCount = -1;
        [SerializeField] private float duration = default;
        [SerializeField] private float scale = default;

        private void Start()
        {
            animatingTransform.DoIfNotNull(t => t.DOScale(scale, duration)
                .SetEase(ease)
                .SetLoops(loopsCount, loopType)
                .Play());
        }
    }
}