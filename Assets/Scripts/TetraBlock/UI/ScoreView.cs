using Common.SharedValues;
using TMPro;
using UnityEngine;

namespace TetraBlock.UI
{
    public class ScoreView : MonoBehaviour, IValueListener<int>
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private IntValue scoreValue;

        private void OnEnable()
        {
            scoreValue.Register(this);
        }

        private void OnDisable()
        {
            scoreValue.Unregister(this);
        }

        public void Raise(int value)
        {
            scoreText.text = value.ToString();
        }
    }
}