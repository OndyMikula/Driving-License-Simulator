using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intersectionController : MonoBehaviour
{
    public gameController gameC;

    public GameObject Canvas_Krizovatka1;
    public GameObject Canvas_KrizovatkaCorrect;
    public GameObject Canvas_KrizovatkaFailed;

    // Sem v Inspektoru napíšeš správné ID tlačítek, např. 2, 0, 1, 3
    public List<int> correctOrder = new List<int>();
    private List<int> playerOrder = new List<int>();

    public Button[] carButtons; // Pole 4 tlačítek pro auta

    public void StartMiniGame()
    {
        Canvas_Krizovatka1.SetActive(false);
        Canvas_KrizovatkaCorrect.SetActive(false);
        Canvas_KrizovatkaFailed.SetActive(false);

        playerOrder.Clear();
        foreach (Button b in carButtons) b.interactable = true;

        // Zastavíme hru
        gameC.paused = true;
        Time.timeScale = 0f;
    }

    // Tuhle metodu zavolá každé tlačítko (předáš mu ID 0-3)
    public void OnCarButtonClick(int carID)
    {
        playerOrder.Add(carID);

        // Deaktivujeme tlačítko, aby na něj nešlo kliknout dvakrát
        carButtons[carID].interactable = false;

        // Pokud jsme klikli na všechna 4 auta, vyhodnotíme to
        if (playerOrder.Count == correctOrder.Count)
        {
            EvaluateResult();
        }
    }

    void EvaluateResult()
    {
        bool isCorrect = true;
        for (int i = 0; i < correctOrder.Count; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                isCorrect = false;
                break;
            }
        }

        Canvas_Krizovatka1.SetActive(false);

        if (isCorrect)
        {
            Canvas_KrizovatkaCorrect.SetActive(true);
        }
        else
        {
            Canvas_KrizovatkaFailed.SetActive(true);
            gameC.score -= 5; // Strhneme body za chybu
        }
    }

    // Tlačítko OPAKOVAT
    public void Retry()
    {
        StartMiniGame();
    }
}