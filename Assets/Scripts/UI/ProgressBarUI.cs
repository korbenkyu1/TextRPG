using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    public void UpdateUI()
    {
        progressSlider.value = GameManager.Instance.actIndex;
    }
}
