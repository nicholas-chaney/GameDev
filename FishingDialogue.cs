using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FishingDialogue : MonoBehaviour
{
    public GameObject dialoguepanel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject player;
    
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
            if (textComponent.text == lines[index])
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

    public void StartDialogue(int fishcatch)
    {
        
            if(fishcatch == 0)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught nothing.";
            lines[3] = "Better luck next time.";
        }
            if (fishcatch == 1)
            {
                gameObject.SetActive(true);
                index = 0;
                lines[0] = "...";
                lines[1] = "...";
                lines[2] = "You caught a Rock.";
                lines[3] = "Better luck next time.";
                StartCoroutine(TypeLine());

            }
            if (fishcatch == 2)
            {
                gameObject.SetActive(true);
                index = 0;
                lines[0] = "...";
                lines[1] = "...";
                lines[2] = "You caught a Stick.";
                lines[3] = "Better luck next time.";
                StartCoroutine(TypeLine());

            }
        if (fishcatch == 3)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught a Goldfish.";
            lines[3] = "Better luck next time.";
            StartCoroutine(TypeLine());

        }
        if (fishcatch == 4)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught a Crab.";
            lines[3] = "Better luck next time.";
            StartCoroutine(TypeLine());

        }
        if (fishcatch == 5)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught a Shark.";
            lines[3] = "Better luck next time.";
            StartCoroutine(TypeLine());

        }
        if (fishcatch == 6)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught a Swordfish.";
            lines[3] = "Better luck next time.";
            StartCoroutine(TypeLine());

        }
        if (fishcatch == 7)
        {
            gameObject.SetActive(true);
            index = 0;
            lines[0] = "...";
            lines[1] = "...";
            lines[2] = "You caught a Clownfish.";
            lines[3] = "Better luck next time.";
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
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }
        else
        {


            gameObject.SetActive(false);
            textComponent.text = string.Empty;
            player.GetComponent<PlayerMovement>().Fishing(false);

        }
    }
}

