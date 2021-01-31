using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI bedroomText;
    public TextMeshProUGUI libraryText;
    public TextMeshProUGUI basementText;
    public TextMeshProUGUI endText;
    private string currentText = "";
    public float delay = 0.001f;

    public bool canWalk = true;

    public bool isEnded = false;

    private void Start()
    {
        canWalk = true;
    }

    public IEnumerator writeText(Room room)
    {
        string fullText = "";
        if(room.name == "Bedroom")
        {
            canWalk = false;
            fullText = "That is one piece of my inner light. It is weak but hey even Rome wasn't built in a day. I feel like days will be lighter little by little. I can actually believe that lost can be found.";
            for(int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                bedroomText.GetComponent<TextMeshProUGUI>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            canWalk = true;
            StartCoroutine(RemoveText(bedroomText.GetComponent<TextMeshProUGUI>()));
        }
        else if (room.name == "Library")
        {
            canWalk = false;
            fullText = "The dark does not break the light but without dark there is no light either. In another word it is balance.";
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                libraryText.GetComponent<TextMeshProUGUI>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            canWalk = true;
            StartCoroutine(RemoveText(libraryText.GetComponent<TextMeshProUGUI>()));
        }
        else if (room.name == "Basement")
        {
            canWalk = false;
            fullText = "“Happiness can be found even in the darkest of times if one only remembers to turn on the light.” Seems that it can also be found in the basement. Dumbledore was a wise man.";
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                basementText.GetComponent<TextMeshProUGUI>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            canWalk = true;
            StartCoroutine(RemoveText(basementText.GetComponent<TextMeshProUGUI>()));
        }
        else if (room.name == "Attic")
        {
            canWalk = false;
            fullText = "I just read a book. The book was called The Nectar of Pain, it is writen by Najwa Zebian. " +
                "The book has a poem that touched me: ”Today I decided to forgive you. Not because you acknowledged the pain that you caused me," +
                "but because my soul deserves peace.” And my soul really deserves peace. So that’s why I forgive you." +
                "I really kept my promise to find my lost light. And it will never be lost again.";
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                endText.GetComponent<TextMeshProUGUI>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            StartCoroutine(RemoveText(endText.GetComponent<TextMeshProUGUI>()));
            isEnded = true;
        }
    }

    IEnumerator RemoveText(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(1);
        text.text = "";
    }

}
