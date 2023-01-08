using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace EndLevelCanvas
{
    public class PanelFadeController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup textGroup;
        [SerializeField] private CanvasGroup buttonGroup;
        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(GetComponent<Image>().DOFade(1, 2f));
            _sequence.Append(textGroup.DOFade(1, 2f));
            _sequence.Append(buttonGroup.DOFade(1, 2f));
            _sequence.Play();
        }
    }
}
