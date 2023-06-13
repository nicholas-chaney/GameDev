using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public GameObject dialoguepanel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool visited;
    private bool axetalk;
    private bool fishintro;
    private bool GotNewRod;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
       // StartDialogue(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(int personNum)
    {
        if (visited == false)
        {
            gameObject.SetActive(true);
            index = 0;
            if (personNum == 1)
            {
                lines[0] = " Stranger: Hey there, do you think that you could help me out?";
                lines[1] = " Stranger: I was chopping down trees around my house and I seem to have misplaced my axe. Could you bring it back to me?";
                StartCoroutine(TypeLine());

                visited = true;
            }
        }
            if (axetalk == false)
            {
                if (personNum == 2)
                {

                    gameObject.SetActive(true);
                    index = 0;
                    lines[0] = " Stranger: I appreciate you finding my axe. I really don't need it anymore so you can keep it.";
                    lines[1] = " Stranger: You should try chopping down some trees!";
                    StartCoroutine(TypeLine());
                    axetalk = true;
                }
            }
        if (personNum == 3)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = " You open the chest";
            lines[1] = " You found a Fishing Pole";
            StartCoroutine(TypeLine());
        }
        if (personNum == 4)
        {
            if (fishintro == false)
            {
                gameObject.SetActive(true);
                index = 0;
                lines[0] = " Fisherman: If you want to catch fish over here you are going to need a stronger fishing rod.";
                lines[1] = " Fisherman: Bring me 5 goldfish and I will give you an advanced fishing rod.";
                StartCoroutine(TypeLine());
                fishintro = true;
            }
        }
        if (personNum == 5)
        {
            if(GotNewRod == false)
            gameObject.SetActive(true);
            index = 0;
            lines[0] = " Fisherman: Thank you for the fish here is your new fishing rod.";
            lines[1] = " Fisherman: You should try catching some fish from the end of this dock.";
            StartCoroutine(TypeLine());
            GotNewRod = true;
        }
        if (personNum == 6)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = " You open the chest";
            lines[1] = " You found 10 gold in the chest. Spend it wisely!";
            StartCoroutine(TypeLine());
            
        }



    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if( index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            

            gameObject.SetActive(false);
            textComponent.text = string.Empty;
        }
    }
}
