using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleDialogue : MonoBehaviour
{
    [SerializeField] Text DialogueText;
    [SerializeField] GameObject MoveSelector;
    [SerializeField] GameObject ActionSelector;

    [SerializeField] List<Button> actionButtons;
    [SerializeField] List<Button> moveButtons;

    

    public IEnumerator SetDialogue(string text)
    {
        yield return DialogueText.text = text;
        
    }

    public void EnableDialogueText(bool enabled)
    {
        DialogueText.enabled = enabled;
    }
    public void EnableActionSelector(bool enabled)
    {
        ActionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        MoveSelector.SetActive(enabled);
    }

    public void SetMoveNames(List<Moves> moves)
    {
        for (int i = 0; i < moveButtons.Count; ++i)
        {
            if (i < moves.Count)
            {
                moveButtons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(moves[i].MoveName);

            }
            else
            {
                moveButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "No Move";
                moveButtons[i].enabled = false;
            }
        }
    }
}
