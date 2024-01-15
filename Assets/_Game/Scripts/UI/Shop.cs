using TMPro;
using UnityEngine;

public class Shop : UICanvas
{
    [SerializeField] TextMeshProUGUI coinText;

    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }

    public override void Open()
    {
        base.Open();
        SetCoin(SaveManager.Instance.coin);
    }

    public void ExitButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);

        UIManager.Instance.OpenUI<MainMenu>();
        Close(0f);
    }
}