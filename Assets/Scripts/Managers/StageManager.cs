using UnityEngine;
using UnityEngine.SceneManagement;
 
public class StageManager : MonoBehaviour
{
    [SerializeField] StageData[] stageData;
    int stageIndex = 0;
    int actIndex = 0;

    StageData stage;
    ActData act;

    void Start()
    {
        // Todo: exception 
        stageIndex = GameManager.Instance.stageIndex;
        actIndex = GameManager.Instance.actIndex;  


        Debug.Log($"Stage{stageIndex + 1} Act{actIndex + 1} started.");

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

        // Todo: Serialize Info -> Setup UI
        #region SerializeInfo
        Debug.Log($"Image: [{act.image}].");
        Debug.Log($"Description: {act.description}.");
        for (int i = 0; i < act.options.Length; i++)
        {

            var option = act.options[i];
            string buffer = $"Option{i + 1}: {option.label}.";
            if (option.requiredCoin > 0) buffer += $"(-{option.requiredCoin} coins)";
            if (option.requiredHealth > 0) buffer += $"(-{option.requiredHealth} hp)";
            Debug.Log(buffer);
        }
        Debug.Log("숫자 키를 눌러 선택지 선택 또는 ESC 키를 눌러 액트 스킵.");
        #endregion
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("액트 스킵됨");
            GameManager.Instance.actIndex++;
            SceneManager.LoadScene("ActScene");
        }

        for (int i = 1; i < 9 && i <= act.options.Length; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)))
            {
                OptionData option = act.options[i - 1];
                Debug.Log($"선택지{i}({option.label})이/가 선택됨.");

                EnemyData enemy = option.enemy;
                ResultData result = option.result;

                // coins
                GameManager.Instance.coin -= option.requiredCoin;
                GameManager.Instance.playerData.health -= option.requiredHealth;
                
                GameManager.Instance.enemyData = enemy;
                GameManager.Instance.resultData = result;

                if (enemy) SceneManager.LoadScene("CombatScene");
                else SceneManager.LoadScene("ResultScene");
                
            }
        }
    }
}
