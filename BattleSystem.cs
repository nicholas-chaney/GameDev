using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] GameObject EnemyImage;
    [SerializeField] BattleUnit enemyunit;
    [SerializeField] Enemy BSEnemy;
    [SerializeField] Enemy Player;

    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleUnit playerunit;
    [SerializeField] BattleDialogue dialogueBox;

    [SerializeField] Button AttackButton;
    [SerializeField] Button RunButton;


    [SerializeField] Button MoveOne;
    [SerializeField] Button MoveTwo;
    [SerializeField] Button MoveThree;
    [SerializeField] Button MoveFour;

    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject infoBar;

    int currentAction;
    int currentMove;
    

    BattleState state;
    public void Battle(Enemy enemy)
    {

        BSEnemy = enemy;
    StartCoroutine(SetupBattle()); 

    }


    public IEnumerator SetupBattle()
    {
        enemyunit.Setup(false, BSEnemy);
        EnemyHud.SetData(enemyunit.Slime);
        playerunit.Setup(true, BSEnemy);
        playerHud.SetData(playerunit.player);

        dialogueBox.SetMoveNames(Player.moves);

        yield return dialogueBox.SetDialogue($"A wild {enemyunit.Slime.EnemyType} appeared.");
        yield return new WaitForSeconds(3f);

        PlayerAction();
    
    }

    void PlayerAction()
    {
        currentAction = 0;
        state = BattleState.PlayerAction;
        StartCoroutine(dialogueBox.SetDialogue("Choose an Action"));
        dialogueBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogueBox.EnableActionSelector(false);
        dialogueBox.EnableDialogueText(false);
        dialogueBox.EnableMoveSelector(true);

    }


    public void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        if(state == BattleState.PlayerMove)
        {
            handleMoveSelection();
        }
    }

    void HandleActionSelection()
    {
        AttackButton.onClick.AddListener(AttackStateOne);
        RunButton.onClick.AddListener(AttackStateTwo);
    }

    
    void AttackStateOne()
    {
        //This means the player selected Attack
        if (currentAction != 1)
        {
            currentAction = 1;
            Debug.Log("Attack");
            PlayerMove();
        }
    }

    void AttackStateTwo()
    {
        if (currentAction != 2)
        {
            currentAction = 2;
            Debug.Log("Run");
        }
    }

    void handleMoveSelection()
    {
        MoveOne.onClick.AddListener(MoveStateOne);
        MoveTwo.onClick.AddListener(MoveStateTwo);
        MoveThree.onClick.AddListener(MoveStateThree);
        MoveFour.onClick.AddListener(MoveStateFour);

    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = playerunit.player.moves[currentMove];
        yield return dialogueBox.SetDialogue($"You used {move.MoveName}");
        yield return new WaitForSeconds(2f);

        bool isFainted = BSEnemy.TakeDamage(move, playerunit.player);
        yield return EnemyHud.UpdateHP(BSEnemy);


        if(isFainted)
        {
            yield return dialogueBox.SetDialogue($"The {BSEnemy.name} has fainted!");
            yield return new WaitForSeconds(2f);

            
            
            yield return state = BattleState.Busy;
            cam2.SetActive(false);
            infoBar.SetActive(true);
            cam1.SetActive(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        var move = enemyunit.Slime.GetRandomMove();

    bool isFainted = Player.TakeDamage(move, enemyunit.Slime);
        yield return dialogueBox.SetDialogue($"The {BSEnemy.name} used {move.MoveName}");
        yield return new WaitForSeconds(2f);

        
        yield return playerHud.UpdateHP(playerunit.player);

        if (isFainted)
        {
            yield return dialogueBox.SetDialogue($"The {Player.name} has fainted!");
            

        }
        else
        {
            PlayerAction();
        }
    

}
    void MoveStateOne()
    {
        if(currentMove != 1)
        {
            currentMove = 0;
            Debug.Log("Move 1");
            dialogueBox.EnableMoveSelector(false);
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
    void MoveStateTwo()
    {
        if (currentMove != 2)
        {
            currentMove = 1;
            Debug.Log("Move 2");
            dialogueBox.EnableMoveSelector(false);
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());

        }
    }
    void MoveStateThree()
    {
        if (currentMove != 3)
        {
            currentMove = 2;
            Debug.Log("Move 3");
            dialogueBox.EnableMoveSelector(false);
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
    void MoveStateFour()
    {
        if (currentMove != 4)
        {
            currentMove = 3;
            Debug.Log("Move 4");
            dialogueBox.EnableMoveSelector(false);
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
