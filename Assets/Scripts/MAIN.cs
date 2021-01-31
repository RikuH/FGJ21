using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MAIN : MonoBehaviour
{
    public Button StartBtn;
    public Button CreditsBtn;
    public Button BackBtn;
    public Button QuitBtn;

    public GameObject CreditsPanel;
    public GameObject MainPanel;

    public GameObject tekstiJuttu;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartGame);
        CreditsBtn.onClick.AddListener(CreditsPanelActive);
        BackBtn.onClick.AddListener(BackToMain);
        QuitBtn.onClick.AddListener(QuitGame);
        Screen.SetResolution(1920, 1080, true);
    }


    void StartGame()
    {
        tekstiJuttu.SetActive(true);
        MainPanel.SetActive(false);
        StartCoroutine(writeText());
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void CreditsPanelActive()
    {
        CreditsPanel.SetActive(true);
        MainPanel.SetActive(false);

    }

    void BackToMain()
    {
        Debug.Log("ASDASD");
        CreditsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    IEnumerator DialogyDealay()
    {
        yield return new WaitForSeconds(3);

        Debug.Log("Aloita");
        SceneManager.LoadScene("SampleScene");
    }


    float TextDelay = 0.1f;

    int lineIndex = 0;

    string textOne = "Have you ever lost your inner light?";
    string textTwo = "I lost my inner light when you broke me.";
    string textThree = "There is a quote about finding yourself:";
    string textFour = "”The best way to find yourself is to lose yourself”";
    string textFive = "I will promise...";
    string textSix = "that piece by piece, I will collect my inner light back together.";

    string currentText = "";

    public Text Liibalaaba;
    public IEnumerator writeText()
    {
        string fullText = "";
        for (int a = 0; a <= 5; a++)
        {
            if (lineIndex == 0)
                fullText = textOne;
            else if (lineIndex == 1)
                fullText = textTwo;
            else if (lineIndex == 2)
                fullText = textThree;
            else if (lineIndex == 3)
                fullText = textFour;
            else if (lineIndex == 4)
                fullText = textFive;
            else if (lineIndex == 5)
                fullText = textSix;

            Debug.Log(a);
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                Liibalaaba.text = currentText;
                yield return new WaitForSeconds(TextDelay);
            }

            yield return new WaitForSeconds(1);
            if (lineIndex < 6)
                lineIndex++;
        }

        StartCoroutine(DialogyDealay());
    }

}
