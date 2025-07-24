using TMPro;
using UnityEngine;

public class ProgressBoxUI : MonoBehaviour
{
    public TMP_Text StageIndex;
    public TMP_Text ActIndex;
    public void UpdateUI()
    {
        StageIndex.text = (GameManager.Instance.stageIndex + 1).ToString();
        ActIndex.text = (GameManager.Instance.actIndex + 1).ToString(); 
    }
}
