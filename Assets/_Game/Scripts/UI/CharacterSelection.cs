using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{
    [SerializeField] Shop shop;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Car Attributes")]
    [SerializeField] private int[] characterPrices;
    private int currentCharacter;


    private void Start()
    {
        currentCharacter = SaveManager.Instance.currentCharacter;
        SelectCharacter(currentCharacter);
    }

    private void SelectCharacter(int _index)
    {
        AudioManager.Instance.PlaySFX("swooshin");
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        if (SaveManager.Instance.charectersUnlocked[currentCharacter])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        //If not show the buy button and set the price
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = characterPrices[currentCharacter].ToString();
        }
    }

    private void Update()
    {
        //Check if we have enough money
        if (buy.gameObject.activeInHierarchy)
            buy.interactable = (SaveManager.Instance.coin >= characterPrices[currentCharacter]);
    }

    public void ChangeCharacter(int _change)
    {
        currentCharacter += _change;

        if (currentCharacter > transform.childCount - 1)
            currentCharacter = 0;
        else if (currentCharacter < 0)
            currentCharacter = transform.childCount - 1;

        SaveManager.Instance.currentCharacter = currentCharacter;
        SaveManager.Instance.Save();
        SelectCharacter(currentCharacter);
    }
    public void BuyCharacter()
    {
        SaveManager.Instance.coin -= characterPrices[currentCharacter];
        SaveManager.Instance.charectersUnlocked[currentCharacter] = true;
        SaveManager.Instance.Save();
        shop.SetCoin(SaveManager.Instance.coin);

        AudioManager.Instance.PlaySFX("purchase");
        UpdateUI();
    }
}
