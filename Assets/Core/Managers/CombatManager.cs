using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CombatState
{
    CombatStart,
    TurnStart,
    PlayerTurnStart,
    PlayerTurn,
    BeforePlayerAttack,
    PlayerAttack,
    AfterPlayerAttack,
    PlayerTurnEnd,
    EnemyTurnStart,
    EnemyTurn,
    BeforeEnemyAttack,
    EnemyAttack,
    AfterEnemyAttack,
    EnemyTurnEnd,
    TurnEnd,
    CombatEnd,
}


public class Unit
{
    public StatsData stats;
    public Dictionary<string, StatusEffectData> statusEffects = new ();
    public List<int> damages = new ();
    public int remainingAction;
}

public class CombatManager : MonoBehaviour
{
    public TMP_Text EnemyDescription;
    public TMP_Text EnemyName;
    public HpBarUI EnemyHpBar;
    public Image EnemyImage;
    public HpBarUI PlayerHpBar;
    public Image PlayerImage;
    public CoinUI Coin;
    public TMP_Text CombatLog;
    public GameObject[] PlayerSkills;


    [SerializeField] StatusEffectData[] statusEffects;
    public int turn = 0;
    public Unit player;
    public Unit enemy;
    public CombatState state;
    
    PlayerData playerData;
    public EnemyData enemyData;

    PlayerSkillData playerSkill;
    EnemySkillData enemySkill;


    void Start()
    {
        playerData = GameManager.Instance.playerData;
        enemyData = GameManager.Instance.enemyData;
        player = new Unit();
        enemy = new Unit();
        player.stats = playerData;
        enemy.stats = enemyData;
        for(int i=0; i<statusEffects.Length; i++)
        {
            var statusEffect1 = Instantiate(statusEffects[i]);
            var statusEffect2 = Instantiate(statusEffects[i]);
            statusEffect1.isPlayer = true;
            player.statusEffects.Add(statusEffect1.statusEffectName, statusEffect1);
            statusEffect2.isPlayer = false;
            enemy.statusEffects.Add(statusEffect2.statusEffectName, statusEffect2);
        }

        EnemyDescription.text = enemyData.description;
        EnemyName.text = enemyData.unitName;
        EnemyImage.sprite = enemyData.image;
        PlayerImage.sprite = playerData.image;

        Coin.UpdateUI();
        CombatLog.text = "";
        for (int i = 0; i < 5; i++)
        {
            var skill = playerData.skills[i];
            var button = PlayerSkills[i].GetComponentInChildren<Button>();
            var text = PlayerSkills[i].GetComponentInChildren<TMP_Text>();
            button.interactable = false;

            if (!skill) continue;

            button.interactable = true;
            button.GetComponentInChildren<Image>().sprite = skill.icon;
            if (skill.maxUse > 0) text.text = $"{skill.skillName}\n({skill.remainingUse}/{skill.maxUse})";
            else text.text = $"{skill.skillName}";

        }
        OnCombatStart();
    }
    public void Log(string msg)
    {
        CombatLog.text += msg + "\n";
        Debug.Log(msg);
    }
    bool IsCombatOver()
    {
        return player.stats.health <= 0 || enemy.stats.health <= 0;
    }
    void OnCombatStart()
    {
        foreach (var ability in playerData.abilities) ability.OnCombatStart(this);
        foreach (var ability in enemyData.abilities) ability.OnCombatStart(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        StartCoroutine(OnTurnStart());
    }
    IEnumerator OnTurnStart(){
        state = CombatState.TurnStart;
        yield return new WaitForSeconds(.25f);
        turn++;
        player.remainingAction = 1;
        enemy.remainingAction = 1;
        int playerOldHealth = player.stats.health;
        int enemyOldHealth = enemy.stats.health;
        player.stats = playerData;
        enemy.stats = enemyData;
        player.damages.Clear();
        enemy.damages.Clear();

        foreach (var ability in playerData.abilities) ability.OnTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnTurnStart(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        player.stats.health = Mathf.Min(player.stats.maxHealth, playerOldHealth);
        enemy.stats.health = Mathf.Min(enemy.stats.maxHealth, enemyOldHealth);

        StartCoroutine(OnPlayerTurnStart());
    }
    IEnumerator OnPlayerTurnStart(){
        state = CombatState.PlayerTurnStart;
        yield return new WaitForSeconds(.25f);

        // 특성 / 상태이상 처리
        foreach (var ability in playerData.abilities) ability.OnPlayerTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnPlayerTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnPlayerTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnPlayerTurnStart(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        float totalWeight = 0f;
        for (int i = 0; i < enemyData.skills.Length; i++) totalWeight += enemyData.skills[i].weight;

        float randomValue = Random.Range(0, totalWeight);
        float currentWeightSum = 0f;
        for (int i = 0; i < enemyData.skills.Length; i++)
        {
            currentWeightSum += enemyData.skills[i].weight;
            if (randomValue <= currentWeightSum)
            {
                enemySkill = enemyData.skills[i].skill;
                break;
            }
        }
        Log(enemySkill.naration);

        
        if (player.remainingAction > 0) OnPlayerTurn();
        else StartCoroutine(OnPlayerTurnEnd()); 
    }
    void OnPlayerTurn(){
        state = CombatState.PlayerTurn;


        if (IsCombatOver()) OnCombatEnd();
    }
    IEnumerator BeforePlayerAttack(){
        state = CombatState.BeforePlayerAttack;
        yield return new WaitForSeconds(.25f);
        playerSkill.coolDownCounter = playerSkill.coolDown;
        playerSkill.OnActivate(this);
        for (int i = 0; i < enemy.damages.Count; i++)
        {
            if (player.stats.critChance >= Random.Range(1, 101))
                enemy.damages[i] = (int)(enemy.damages[i] * 1.5f);
        }
        foreach (var ability in playerData.abilities) ability.BeforePlayerAttack(this);
        foreach (var ability in enemyData.abilities) ability.BeforePlayerAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.BeforePlayerAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.BeforePlayerAttack(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();


        if (enemy.damages.Count > 0) StartCoroutine(OnPlayerAttack());
        else if(player.remainingAction > 0) OnPlayerTurn();
        else StartCoroutine(OnPlayerTurnEnd());
    }
    IEnumerator OnPlayerAttack()
    {
        state = CombatState.PlayerAttack;
        yield return new WaitForSeconds(.25f);

        string buffer = "적: ";
        for (int i = 0; i < enemy.damages.Count; i++)
        {
            buffer += " " + enemy.damages[i].ToString();
            enemy.stats.health -= enemy.damages[i];
        }
        buffer += "데미지";
        Log(buffer);
        StartCoroutine(AfterPlayerAttack());
    }
    IEnumerator AfterPlayerAttack(){
        state = CombatState.AfterPlayerAttack;
        yield return new WaitForSeconds(.25f);
        foreach (var ability in playerData.abilities) ability.AfterPlayerAttack(this);
        foreach (var ability in enemyData.abilities) ability.AfterPlayerAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.AfterPlayerAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.AfterPlayerAttack(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        if (player.remainingAction > 0) OnPlayerTurn(); 
        else StartCoroutine(OnPlayerTurnEnd());
    }
    IEnumerator OnPlayerTurnEnd(){
        state = CombatState.PlayerTurnEnd;
        yield return new WaitForSeconds(.25f);
        for (int i = 0; i < 5; i++) {
            if (playerData.skills[i] == null) continue;
            playerData.skills[i].coolDownCounter = Mathf.Max(0, playerData.skills[i].coolDownCounter - 1); 
            // Null Reference;
        }

        foreach (var ability in playerData.abilities) ability.OnPlayerTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnPlayerTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnPlayerTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnPlayerTurnEnd(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        StartCoroutine(OnEnemyTurnStart());
    }        
    IEnumerator OnEnemyTurnStart(){
        state = CombatState.EnemyTurnStart;
        yield return new WaitForSeconds(.25f);
        foreach (var ability in playerData.abilities) ability.OnEnemyTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnEnemyTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnEnemyTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnEnemyTurnStart(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();
        if(enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd());
    }
    IEnumerator OnEnemyTurn(){
        state = CombatState.EnemyTurn;
        yield return new WaitForSeconds(.25f);

        enemy.remainingAction--;
        if (enemySkill.dodgable && Random.Range(0, 100) <= player.stats.dodgeChance)
        {
            if(enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
            else StartCoroutine(OnEnemyTurnEnd()); 
        }
        else StartCoroutine(BeforeEnemyAttack()); 
    }
    IEnumerator BeforeEnemyAttack(){
        state = CombatState.BeforeEnemyAttack;
        yield return new WaitForSeconds(.25f);
        enemySkill.OnActivate(this);
        foreach (var ability in playerData.abilities) ability.BeforeEnemyAttack(this);
        foreach (var ability in enemyData.abilities) ability.BeforeEnemyAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.BeforeEnemyAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.BeforeEnemyAttack(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        if (enemy.damages.Count > 0) StartCoroutine(OnEnemyAttack());   
        else if(enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd()); 
    }
    IEnumerator OnEnemyAttack(){
        state = CombatState.EnemyAttack;
        yield return new WaitForSeconds(.25f);
        string buffer = "플레이어: ";
        for (int i = 0; i < player.damages.Count; i++)
        {
            buffer += " " + player.damages[i].ToString();
            player.stats.health -= player.damages[i];
        }
        buffer += " 데미지";
        Log(buffer);

        StartCoroutine(AfterEnemyAttack());
    }
    IEnumerator AfterEnemyAttack(){
        state = CombatState.AfterEnemyAttack;
        yield return new WaitForSeconds(.25f);
        foreach (var ability in playerData.abilities) ability.AfterEnemyAttack(this);
        foreach (var ability in enemyData.abilities) ability.AfterEnemyAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.AfterEnemyAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.AfterEnemyAttack(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();
        if (enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd()); 
    }
    IEnumerator OnEnemyTurnEnd(){
        state = CombatState.EnemyTurnEnd;
        yield return new WaitForSeconds(.25f);
        foreach (var ability in playerData.abilities) ability.OnEnemyTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnEnemyTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnEnemyTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnEnemyTurnEnd(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        StartCoroutine(OnTurnEnd());
    }
    IEnumerator OnTurnEnd(){
        state = CombatState.TurnEnd;
        yield return new WaitForSeconds(.25f);
        foreach (var ability in playerData.abilities) ability.OnTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnTurnEnd(this);
        EnemyHpBar.UpdateHp(enemy.stats.maxHealth, enemy.stats.health);
        PlayerHpBar.UpdateHp(player.stats.maxHealth, player.stats.health);
        if (IsCombatOver()) OnCombatEnd();

        StartCoroutine(OnTurnStart());
    }
    void OnCombatEnd() {
        state = CombatState.CombatEnd;
        if (player.stats.health > 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
        else
        {
            Debug.Log("GAME OVER");
            // lost
        }
    }
    public void PlayerSkill(int i)
    {
        if (state != CombatState.PlayerTurn) return;
        if (!playerData.skills[i]) return;
        if (playerData.skills[i].remainingUse == 0) return;

        playerSkill = playerData.skills[i];
        player.remainingAction -= playerSkill.turnUsed;


        player.remainingAction -= playerData.skills[i].turnUsed;

        var text = PlayerSkills[i].GetComponentInChildren<TMP_Text>();
        if (playerSkill.maxUse > 0)
        {
            playerSkill.remainingUse--;
            if (playerSkill.maxUse > 0) text.text = $"{playerSkill.skillName}\n({playerSkill.remainingUse}/{playerSkill.maxUse})";
        }

        if (playerSkill.dodgable && Random.Range(1, 101) <= enemy.stats.dodgeChance)
        {
            if (player.remainingAction > 0) OnPlayerTurn();
            else StartCoroutine(OnPlayerTurnEnd());
        }
        else StartCoroutine(BeforePlayerAttack());
    }
}