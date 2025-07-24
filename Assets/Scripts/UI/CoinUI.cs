using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TMP_Text Coin;
    public void UpdateUI()
    {
        Coin.text = GameManager.Instance.ToString();
    }
}
