using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class SkillGroup
{
    public PlayerSkillData commonSkill;
    public PlayerSkillData uncommonSkill;
    public PlayerSkillData rareSkill;
    public PlayerSkillData epicSkill;
    public PlayerSkillData legendarySkill;
    public PlayerSkillData mythicSkill;
}

public class ResultManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text StageText;
    public GameObject RewardsPanel;
    public GameObject RewardInfoPanel;

    [Header("Skills")] 
    [SerializeField] List<SkillGroup> attackSkills;
    [SerializeField] List<SkillGroup> defenseSkills;
    [SerializeField] List<SkillGroup> normalSkills;
    [SerializeField] List<SkillGroup> specialSkills;
    [SerializeField] List<SkillGroup> ultimateSkills;
    
    [Header("Items")]
    [SerializeField] List<ItemData> commonItems;
    [SerializeField] List<ItemData> uncommonItems;
    [SerializeField] List<ItemData> rareItems;
    [SerializeField] List<ItemData> epicItems;
    [SerializeField] List<ItemData> legendaryItems;
    [SerializeField] List<ItemData> mythicItems;

    [Header("Foods")]
    [SerializeField] List<FoodData> commonFoods;
    [SerializeField] List<FoodData> uncommonFoods;
    [SerializeField] List<FoodData> rareFoods;
    [SerializeField] List<FoodData> epicFoods;
    [SerializeField] List<FoodData> legendaryFoods;
    [SerializeField] List<FoodData> mythicFoods;

    ResultData result;
    PlayerSkillData[] skillRewards = new PlayerSkillData[3];
    ItemData[] itemRewards = new ItemData[3];
    FoodData[] foodRewards = new FoodData[3];

    PlayerSkillData selectedSkill;
    ItemData selectedItem;
    FoodData selectedFood;

    int index = 0;

    void Log(string msg)
    {
        StageText.text += msg + "\n";
    }

    void Start()
    {
        result = GameManager.Instance.resultData;
        StageText.text = result.messages[0];

        Log(result.messages[0]);


    }
    public void NextButton()
    {
        index++;
        if(index < result.messages.Length)
        {
            Log(result.messages[index]);
            return;
        }
        if(index == result.messages.Length)
        {
            bool flag = false;

            if (result.coin != 0)
            {
                Log("코인 " + result.coin.ToString("+#;-#;0"));
                GameManager.Instance.coin += result.coin;
                flag = true;
            }

            PlayerData player = GameManager.Instance.playerData;
            if (result.maxHealth != 0)
            {
                Log("최대 체력 " + result.maxHealth.ToString("+#;-#;0"));
                GameManager.Instance.playerData.maxHealth = Mathf.Min(player.maxHealth + result.maxHealth, 900);
                GameManager.Instance.playerData.health = Mathf.Min(player.health + result.maxHealth, GameManager.Instance.playerData.maxHealth);
                player = GameManager.Instance.playerData;
                flag = true;
            }
            if (result.health != 0)
            {
                Log("체력 " + result.health.ToString("+#;-#;0"));
                GameManager.Instance.playerData.health = Mathf.Min(player.health + result.health, player.maxHealth);
                player = GameManager.Instance.playerData;
                flag = true;
            }
            if (result.attack != 0)
            {
                Log("공격력 " + result.attack.ToString("+#;-#;0"));
                GameManager.Instance.playerData.attack = Mathf.Min(player.attack + result.attack, 70);
                flag = true;
            }
            if (result.defense != 0)
            {
                Log("방어력 " + result.attack.ToString("+#;-#;0"));
                GameManager.Instance.playerData.defense = Mathf.Min(player.defense + result.defense, 99);
                flag = true;
            }
            if (result.critChance != 0)
            {
                Log("치명타율 " + result.attack.ToString("+#;-#;0"));
                GameManager.Instance.playerData.critChance = Mathf.Min(player.critChance + result.critChance, 99);
                flag = true;
            }

            if (result.dodgeChance != 0)
            {
                Log("회피율 " + result.attack.ToString("+#;-#;0"));
                GameManager.Instance.playerData.dodgeChance = Mathf.Min(player.dodgeChance + result.dodgeChance, 70);
                flag = true;
            }

            if(flag) return;
        }

        switch (result.type)
        {
            case RewardType.Skill:
                var skills = GameManager.Instance.playerData.skills;
                var skillGroupLists = new List<List<SkillGroup>> { attackSkills, defenseSkills, normalSkills, specialSkills, ultimateSkills };
                int[] minimumRarity = { 1, 1, 2, 4, 5 };

                for (int i=0; i<5; i++)
                {
                    if (skills[i] == null) continue;
                    skillGroupLists[i].Remove(skillGroupLists[i].FirstOrDefault(s => s.mythicSkill.GetType() == skills[i].GetType()));
                }

                for(int i=0; i<3; i++)
                {
                    int type = Random.Range(0, 4);
                    List<SkillGroup> skillGroupList = skillGroupLists[type];

                    int index = Random.Range(0, skillGroupList.Count);
                    SkillGroup skillGroup = skillGroupList[index];
                    skillGroupList.RemoveAt(index);

                    int rarity = Mathf.Min(skills[type] ? (int)skills[type].rarity + 1 : minimumRarity[type], 5);
                    skillRewards[i] = (new PlayerSkillData[] { skillGroup.commonSkill, skillGroup.uncommonSkill, skillGroup.rareSkill, skillGroup.epicSkill, skillGroup.legendarySkill, skillGroup.mythicSkill })[rarity];
                }
                break;
            case RewardType.Item:
                var itemLists = new List<List<ItemData>> { commonItems, uncommonItems, rareItems, epicItems, legendaryItems, mythicItems };
                float[] itemWeights = GameManager.Instance.actDatas[GameManager.Instance.actIndex].foodWeights;
                float totalItemWeight = 0f;
                for (int i = 0; i < 6; i++) totalItemWeight += itemWeights[i];
                for (int i = 0; i < 3; i++)
                {
                    float randomValue = Random.Range(0, totalItemWeight);
                    float currentWeightSum = 0f;
                    for (int j = 0; j < 6; j++)
                    {
                        totalItemWeight += itemWeights[i];
                        if (randomValue <= currentWeightSum)
                        {
                            var itemList = itemLists[j];
                            int k = Random.Range(0, itemList.Count);
                            itemRewards[i] = itemList[k];
                            itemList.RemoveAt(k);
                            break;
                        }
                    }
                }
                break;
            case RewardType.Food:
                var foodLists = new List<List<FoodData>> { commonFoods, uncommonFoods, rareFoods, epicFoods, legendaryFoods, mythicFoods };
                float[] foodWeights = GameManager.Instance.actDatas[GameManager.Instance.actIndex].foodWeights;
                float totalFoodWeight = 0f;
                for (int i = 0; i < 6; i++) totalFoodWeight += foodWeights[i];
                for (int i = 0; i < 3; i++)
                {
                    float randomValue = Random.Range(0, totalFoodWeight);
                    float currentWeightSum = 0f;
                    for (int j = 0; j < 6; j++)
                    {
                        currentWeightSum += foodWeights[i];
                        if (randomValue <= currentWeightSum)
                        {
                            var foodList = foodLists[j];
                            int k = Random.Range(0, foodList.Count);
                            foodRewards[i] = foodList[k];
                            foodList.RemoveAt(k);
                            break;
                        }
                    }
                }
                break;
            case RewardType.None:
                GameManager.Instance.LoadNext();
                return;
        }

        RewardsPanel.SetActive(true);
    }
    public void RewardInfo(int i)
    {
        switch (result.type)
        {
            case RewardType.Skill:
                RewardInfoPanel.GetComponentInChildren<Image>().sprite = skillRewards[i].image;
                RewardInfoPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = skillRewards[i].flavorText;
                break;
            case RewardType.Item:
                RewardInfoPanel.GetComponentInChildren<Image>().sprite = itemRewards[i].image;
                RewardInfoPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = itemRewards[i].flavorText;
                break;
            case RewardType.Food:
                RewardInfoPanel.GetComponentInChildren<Image>().sprite = foodRewards[i].image;
                RewardInfoPanel.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = foodRewards[i].flavorText;
                break;
        }

        RewardInfoPanel.SetActive(true);
    }
    public void GetReward()
    {
        switch (result.type)
        {
            case RewardType.Skill:
                int index = (int) selectedSkill.type;
                GameManager.Instance.playerData.skills[index] = selectedSkill;
                break;

            case RewardType.Item:
                var abilities = GameManager.Instance.playerData.abilities;

                if (selectedItem.requiredAbilityA) abilities.Remove(abilities.FirstOrDefault(a => a.GetType() == selectedItem.requiredAbilityA.GetType()));
                if (selectedItem.requiredAbilityB) abilities.Remove(abilities.FirstOrDefault(b => b.GetType() == selectedItem.requiredAbilityB.GetType()));

                foreach(var abilityModifier in selectedItem.abilityModifiers)
                {
                    var ability = abilities.FirstOrDefault(a => a.GetType() == abilityModifier.abilityData.GetType());
                    if (ability) ability.level = Mathf.Min(ability.level + abilityModifier.modifier, 7);
                    else
                    {
                        abilityModifier.abilityData.level = abilityModifier.modifier;
                        abilities.Add(abilityModifier.abilityData);
                    }
                }
                abilities.RemoveAll(a => a.level <= 0);
                break;

            case RewardType.Food:
                PlayerData player = GameManager.Instance.playerData;
                if (result.maxHealth != 0)
                {
                    Log("최대 체력 " + result.maxHealth.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.maxHealth = Mathf.Min(player.maxHealth + selectedFood.maxHealth, 900);
                    GameManager.Instance.playerData.health = Mathf.Min(player.health + selectedFood.maxHealth, GameManager.Instance.playerData.maxHealth);
                    player = GameManager.Instance.playerData;
                }
                if (result.health != 0)
                {
                    Log("체력 " + result.health.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.health = Mathf.Min(player.health + selectedFood.health, player.maxHealth);
                    player = GameManager.Instance.playerData;
                }
                if (result.attack != 0)
                {
                    Log("공격력 " + result.attack.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.attack = Mathf.Min(player.attack + selectedFood.attack, 70);
                }
                if (result.defense != 0)
                {
                    Log("방어력 " + result.attack.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.defense = Mathf.Min(player.defense + selectedFood.defense, 99);
                }
                if (result.critChance != 0)
                {
                    Log("치명타율 " + result.attack.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.critChance = Mathf.Min(player.critChance + selectedFood.critChance, 99);
                }
                if (result.dodgeChance != 0)
                {
                    Log("회피율 " + result.attack.ToString("+#;-#;0"));
                    GameManager.Instance.playerData.dodgeChance = Mathf.Min(player.dodgeChance + selectedFood.dodgeChance, 70);
                }
                break;
        }

        GameManager.Instance.LoadNext();
    }
}
