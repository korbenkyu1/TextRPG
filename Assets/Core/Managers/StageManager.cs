using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    public HeaderUI HeaderUI;
    public GameObject Dialog;
    public Image DialogBox;
    public Image StageImage;
    public CanvasGroup OptionContainer;
    public Button OptionButtonPrefab;
    public Image EnemyImage;
    public GameObject CombatStartButton;

    int stageIndex = 0;
    int actIndex = 0;

    ActData act;
    StageData stage;
    int index = 0;

    void Start()
    {
        ActData[] actDatas = GameManager.Instance.actDatas;
        actIndex = GameManager.Instance.actIndex;  
        stageIndex = GameManager.Instance.stageIndex;


        // Load Stage & Act Data
        act = actDatas[actIndex];
        if (act.fixedStages[stageIndex]) stage = act.fixedStages[stageIndex];
        else
        {
            float totalWeight = 0f;
            for (int i = 0; i < act.randomStages.Length; i++) totalWeight += act.randomStages[i].weight;

            float randomValue = Random.Range(0, totalWeight);
            float currentWeightSum = 0f;
            for (int i = 0; i < act.randomStages.Length; i++)
            {
                currentWeightSum += act.randomStages[i].weight;
                if (randomValue <= currentWeightSum)
                {
                    stage = act.randomStages[stageIndex].stage;
                    break;
                }
            }
        }

        HeaderUI.UpdatePlayerIcon();
        HeaderUI.UpdateProgress();
        HeaderUI.UpdateHp();
        
        var text = Dialog.GetComponentInChildren<Text>();
        var button = Dialog.GetComponentInChildren<Button>();
        button.interactable = false;
        text.text = "";
        text.DOText(stage.descriptions[0], stage.descriptions[0].Length * 0.05f).SetEase(Ease.Linear).OnComplete(() => {
            button.interactable = true;
        });
        StageImage.sprite = stage.images[0];
    }

    public void Next()
    {
        index++;
        if (index < stage.descriptions.Length)
        {
            var text = Dialog.GetComponentInChildren<Text>();
            var button = Dialog.GetComponentInChildren<Button>();
            button.interactable = false;
            text.text = "";
            text.DOText(stage.descriptions[index], stage.descriptions[index].Length * 0.05f).SetEase(Ease.Linear).OnComplete(() => {
                button.interactable = true;
            });
            StageImage.sprite = stage.images[index];
            return;
        }

        // To combat
        if (stage.options.Length == 1 && stage.options[0].enemy)
        {
            return;
        }

        // To option select
        DialogBox.rectTransform.DOSizeDelta(new Vector2(894, 632), 0.25f);
        OptionContainer.DOFade(1f, .25f).SetDelay(.25f).OnComplete(() => { 
            OptionContainer.interactable = true;
            OptionContainer.blocksRaycasts = true;
        });

        for (int i = 0; i < stage.options.Length; i++)
        {
            var option = stage.options[i];
            var button = Instantiate(OptionButtonPrefab, OptionContainer.transform);
            int button_index = i;
            button.onClick.AddListener(() => OptionButton(button_index));
            button.GetComponentInChildren<TMP_Text>().text = option.label;
        }
    }
    public void OptionButton(int i)
    {
        OptionData option = stage.options[i];

        EnemyData enemy = option.enemy;
        ResultData result = option.result;

        // coins
        GameManager.Instance.coin -= option.requiredCoin;
        GameManager.Instance.playerData.health -= option.requiredHealth;

        GameManager.Instance.enemyData = enemy;
        GameManager.Instance.resultData = result;

        if (enemy)
        {
            StageImage.gameObject.SetActive(false);
            DialogBox.gameObject.SetActive(false);
            //OptionContainer.SetActive(false);

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
