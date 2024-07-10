using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button[] buttonList;
    private string playerSide;
    private int moveCount;
    public Text gameOverText;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
        gameOverText.text = "";
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            var temp = i;
            buttonList[i].GetComponentInChildren<Button>().onClick.AddListener(() => SetSpace(buttonList[temp]));
        }
    }

    public void SetSpace(Button btn)
    {
        btn.GetComponentInChildren<Text>().text = playerSide;
        btn.interactable = false;
        EndTurn();
    }

    void EndTurn()
    {
        moveCount++;
        if (CheckWin())
        {
            GameOver(playerSide + " Wins!");
        }
        else if (moveCount >= 9)
        {
            GameOver("Draw!");
        }
        else
        {
            ChangeSides();
        }
    }

    bool CheckWin()
    {
        // Kiểm tra các dòng, cột và đường chéo để xem có người chiến thắng không
        // Ví dụ kiểm tra ba nút đầu tiên trên cùng:
        if (buttonList[0].GetComponentInChildren<Text>().text == playerSide &&
            buttonList[1].GetComponentInChildren<Text>().text == playerSide &&
            buttonList[2].GetComponentInChildren<Text>().text == playerSide)
        {
            return true;
        }
        // Thêm các kiểm tra khác ở đây
        return false;
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver(string result)
    {
        SetGameOverText(result);
        SetBoardInteractable(false);
    }

    void SetGameOverText(string value)
    {
        gameOverText.text = value;
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].interactable = toggle;
        }
    }
}
