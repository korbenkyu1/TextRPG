using System.Collections;
using System.Collections.Generic;
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
    public Image EnemyImage;
    public Image PlayerImage;
    public CoinUI Coin;

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
        foreach (var statusEffect in statusEffects)
        {
            statusEffect.isPlayer = true;
            player.statusEffects.Add(statusEffect.statusEffectName, statusEffect);
            statusEffect.isPlayer = false;
            enemy.statusEffects.Add(statusEffect.statusEffectName, statusEffect);
        }

        EnemyImage.sprite = enemyData.image;
        PlayerImage.sprite = playerData.image;
        Coin.UpdateUI();

        OnCombatStart();
    }
    public void Log(string msg)
    {
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
        StartCoroutine(OnTurnStart());
    }
    IEnumerator OnTurnStart(){
        state = CombatState.TurnStart;
        yield return new WaitForSeconds(1f);
        turn++;
        player.remainingAction = 1;
        enemy.remainingAction = 1;
        int playerOldHealth = player.stats.health;
        int enemyOldHealth = enemy.stats.health;
        player.stats = playerData;
        enemy.stats = enemyData;
        player.damages.Clear();
        enemy.damages.Clear();
        Debug.Log($"턴{turn}");

        foreach (var ability in playerData.abilities) ability.OnTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnTurnStart(this);
        if (IsCombatOver()) OnCombatEnd();

        player.stats.health = Mathf.Min(player.stats.maxHealth, playerOldHealth);
        enemy.stats.health = Mathf.Min(enemy.stats.maxHealth, enemyOldHealth);

        StartCoroutine(OnPlayerTurnStart());
    }
    IEnumerator OnPlayerTurnStart(){
        state = CombatState.PlayerTurnStart;
        yield return new WaitForSeconds(1f);
        Debug.Log("플레이어 턴");

        // 특성 / 상태이상 처리
        foreach (var ability in playerData.abilities) ability.OnPlayerTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnPlayerTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnPlayerTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnPlayerTurnStart(this);
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
        Debug.Log(enemySkill.naration);

        
        if (player.remainingAction > 0) OnPlayerTurn();
        else StartCoroutine(OnPlayerTurnEnd()); 
    }
    void OnPlayerTurn(){
        state = CombatState.PlayerTurn;


        if (IsCombatOver()) OnCombatEnd();
    }
    IEnumerator BeforePlayerAttack(){
        state = CombatState.BeforePlayerAttack;
        yield return new WaitForSeconds(1f);
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
        if (IsCombatOver()) OnCombatEnd();


        if (enemy.damages.Count > 0) StartCoroutine(OnPlayerAttack());
        else if(player.remainingAction > 0) OnPlayerTurn();
        else StartCoroutine(OnPlayerTurnEnd());
    }
    IEnumerator OnPlayerAttack()
    {
        state = CombatState.PlayerAttack;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < enemy.damages.Count; i++)
        {
            Debug.Log($"적: {enemy.damages[i]} 데미지");
            enemy.stats.health -= enemy.damages[i];
        }
        StartCoroutine(AfterPlayerAttack());
    }
    IEnumerator AfterPlayerAttack(){
        state = CombatState.AfterPlayerAttack;
        yield return new WaitForSeconds(1f);
        foreach (var ability in playerData.abilities) ability.AfterPlayerAttack(this);
        foreach (var ability in enemyData.abilities) ability.AfterPlayerAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.AfterPlayerAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.AfterPlayerAttack(this);
        if (IsCombatOver()) OnCombatEnd();

        if (player.remainingAction > 0) OnPlayerTurn(); 
        else StartCoroutine(OnPlayerTurnEnd());
    }
    IEnumerator OnPlayerTurnEnd(){
        state = CombatState.PlayerTurnEnd;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 5; i++) playerData.skills[i].coolDownCounter = Mathf.Max(0, playerData.skills[i].coolDownCounter - 1);

        foreach (var ability in playerData.abilities) ability.OnPlayerTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnPlayerTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnPlayerTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnPlayerTurnEnd(this);
        if (IsCombatOver()) OnCombatEnd();

        StartCoroutine(OnEnemyTurnStart());
    }        
    IEnumerator OnEnemyTurnStart(){
        state = CombatState.EnemyTurnStart;
        yield return new WaitForSeconds(1f);
        foreach (var ability in playerData.abilities) ability.OnEnemyTurnStart(this);
        foreach (var ability in enemyData.abilities) ability.OnEnemyTurnStart(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnEnemyTurnStart(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnEnemyTurnStart(this);
        if (IsCombatOver()) OnCombatEnd();
        if(enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd());
    }
    IEnumerator OnEnemyTurn(){
        state = CombatState.EnemyTurn;
        yield return new WaitForSeconds(1f);

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
        yield return new WaitForSeconds(1f);
        enemySkill.OnActivate(this);
        foreach (var ability in playerData.abilities) ability.BeforeEnemyAttack(this);
        foreach (var ability in enemyData.abilities) ability.BeforeEnemyAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.BeforeEnemyAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.BeforeEnemyAttack(this);
        if (IsCombatOver()) OnCombatEnd();

        if (enemy.damages.Count > 0) StartCoroutine(OnEnemyAttack());   
        else if(enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd()); 
    }
    IEnumerator OnEnemyAttack(){
        state = CombatState.EnemyAttack;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < player.damages.Count; i++)
        {
            player.stats.health -= player.damages[i];
        }

        StartCoroutine(AfterEnemyAttack());
    }
    IEnumerator AfterEnemyAttack(){
        state = CombatState.AfterEnemyAttack;
        yield return new WaitForSeconds(1f);
        foreach (var ability in playerData.abilities) ability.AfterEnemyAttack(this);
        foreach (var ability in enemyData.abilities) ability.AfterEnemyAttack(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.AfterEnemyAttack(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.AfterEnemyAttack(this);
        if (IsCombatOver()) OnCombatEnd();
        if (enemy.remainingAction > 0) StartCoroutine(OnEnemyTurn()); 
        else StartCoroutine(OnEnemyTurnEnd()); 
    }
    IEnumerator OnEnemyTurnEnd(){
        state = CombatState.EnemyTurnEnd;
        yield return new WaitForSeconds(1f);
        foreach (var ability in playerData.abilities) ability.OnEnemyTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnEnemyTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnEnemyTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnEnemyTurnEnd(this);
        if (IsCombatOver()) OnCombatEnd();

        StartCoroutine(OnTurnEnd());
    }
    IEnumerator OnTurnEnd(){
        state = CombatState.TurnEnd;
        yield return new WaitForSeconds(1f);
        foreach (var ability in playerData.abilities) ability.OnTurnEnd(this);
        foreach (var ability in enemyData.abilities) ability.OnTurnEnd(this);
        foreach (var statusEffect in player.statusEffects.Values) statusEffect.OnTurnEnd(this);
        foreach (var statusEffect in enemy.statusEffects.Values) statusEffect.OnTurnEnd(this);
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
    void Update()
    {
        switch(state)
        {
            case CombatState.PlayerTurn:
                for (int i = 1; i < 5; i++)
                {
                    if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)) && playerData.skills[i].coolDownCounter == 0)
                    {
                        playerSkill = playerData.skills[i-1];
                        player.remainingAction -= playerSkill.turnUsed;
                        if (playerSkill.dodgable && Random.Range(1, 101) <= enemy.stats.dodgeChance)
                        {
                            if (player.remainingAction > 0) OnPlayerTurn();
                            else StartCoroutine(OnPlayerTurnEnd()); 
                        }
                        else StartCoroutine(BeforePlayerAttack()); 
                        return;
                    }
                }
                break;
        }
    }
}