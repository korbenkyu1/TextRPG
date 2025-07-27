using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeaderUI : MonoBehaviour
{
    [SerializeField] Image PlayerIcon;
    [SerializeField] TMP_Text ProgressText;
    [SerializeField] Slider ProgressSlider;
    [SerializeField] HpBarUI HpBar;

    public void UpdatePlayerIcon()
    {
        PlayerIcon.sprite = GameManager.Instance.playerData.icon;
    }
    public void UpdateProgress() 
    {
        int actIndex = GameManager.Instance.actIndex;
        int stageIndex = GameManager.Instance.stageIndex;
        ProgressText.text = $"Act <#FE5154>{actIndex+1}</color> stage <#FE5154>{stageIndex + 1}</color>";
        ProgressSlider.value = stageIndex;
    }
    public void UpdateHp()
    {
        HpBar.UpdateHp(GameManager.Instance.playerData.maxHealth, GameManager.Instance.playerData.health);
    }
}
