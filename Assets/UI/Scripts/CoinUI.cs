using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TMP_Text text;
    public void UpdateUI()
    {
        text.text = GameManager.Instance.coin.ToString();
    }
}
