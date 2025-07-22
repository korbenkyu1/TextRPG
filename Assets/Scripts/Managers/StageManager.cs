using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public ProgressBarUI progressBarUI;

    public Image DialogBox;
    public TMP_Text ActText;
    public Image ActImage;
    public GameObject OptionContainer;
    public Button OptionButtonPrefab;
    public Image EnemyImage;
    public GameObject CombatStartButton;

    [SerializeField] StageData[] stageData;
    int stageIndex = 0;
    int actIndex = 0;

    StageData stage;
    ActData act;
    int index = 0;

    void Start()
    {
        // Todo: exception 
        stageIndex = GameManager.Instance.stageIndex;
        actIndex = GameManager.Instance.actIndex;  


        // Load Stage & Act Data
        stage = stageData[stageIndex];
        if (stage.fixedActs[actIndex]) act = stage.fixedActs[actIndex];
        else
        {
            float totalWeight = 0f;
            for (int i = 0; i < stage.randomActs.Length; i++) totalWeight += stage.randomActs[i].weight;

            float randomValue = Random.Range(0, totalWeight);
            float currentWeightSum = 0f;
            for (int i = 0; i < stage.randomActs.Length; i++)
            {
                currentWeightSum += stage.randomActs[i].weight;
                if (randomValue <= currentWeightSum)
                {
                    act = stage.randomActs[actIndex].act;
                    break;
                }
            }
        }
        progressBarUI.UpdateUI();
        ActImage.sprite = act.images[0];
        ActText.text = act.descriptions[0];
    }

    public void NextButton()
    {
        index++;
        if (index < act.descriptions.Length)
        {
            ActText.text = act.descriptions[index];
            ActImage.sprite = act.images[index];
            return;
        }

        // To selection
        DialogBox.rectTransform.sizeDelta = new Vector2(893, 632);
        OptionContainer.SetActive(true);
        // To combat
        if (act.options.Length == 1 && act.options[0].enemy)
        {
            
            return;
        }
        for (int i = 0; i < act.options.Length; i++)
        {
            var option = act.options[i];
            var button = Instantiate(OptionButtonPrefab, OptionContainer.transform);
            int button_index = i;
            button.onClick.AddListener(() => OptionButton(button_index));
            button.GetComponentInChildren<TMP_Text>().text = option.label;
        }
    }
    public void OptionButton(int i)
    {
        OptionData option = act.options[i];

        EnemyData enemy = option.enemy;
        ResultData result = option.result;

        // coins
        GameManager.Instance.coin -= option.requiredCoin;
        GameManager.Instance.playerData.health -= option.requiredHealth;

        GameManager.Instance.enemyData = enemy;
        GameManager.Instance.resultData = result;

        if (enemy)
        {
            ActImage.gameObject.SetActive(false);
            DialogBox.gameObject.SetActive(false);
            OptionContainer.SetActive(false);

            EnemyImage.sprite = enemy.image;
            EnemyImage.gameObject.SetActive(true);
            CombatStartButton.SetActive(true);
        }
        else SceneManager.LoadScene("ResultScene");
    }
    public void CombatStart()
    {
        SceneManager.LoadScene("CombatScene");
    }

}
