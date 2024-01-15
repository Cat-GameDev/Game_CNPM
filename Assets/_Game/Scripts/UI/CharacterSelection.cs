using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{
    [Header ("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text priceText;

    [Header("Car Attributes")]
    [SerializeField] private int[] characterPrices;
    private int currentCharacter;

    [Header("Sound")]
    [SerializeField] private AudioClip purchase;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        currentCharacter = SaveManager.Instance.currentCharacter;
        SelectCar(currentCharacter);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        // if (SaveManager.Instance.charectersUnlocked[currentCharacter])
        // {
        //     play.gameObject.SetActive(true);
        //     buy.gameObject.SetActive(false);
        // }
        // //If not show the buy button and set the price
        // else
        // {
        //     play.gameObject.SetActive(false);
        //     buy.gameObject.SetActive(true);
        //     priceText.text = characterPrices[currentCharacter] + "$";
        // }
    }

    // private void Update()
    // {
    //     //Check if we have enough money
    //     if (buy.gameObject.activeInHierarchy)
    //         buy.interactable = (SaveManager.Instance.coin >= characterPrices[currentCharacter]);
    // }

    public void ChangeCar(int _change)
    {
        currentCharacter += _change;

        if (currentCharacter > transform.childCount - 1)
            currentCharacter = 0;
        else if (currentCharacter < 0)
            currentCharacter = transform.childCount - 1;

        SaveManager.Instance.currentCharacter = currentCharacter;
        SaveManager.Instance.Save();
        SelectCar(currentCharacter);
    }
    public void BuyCar()
    {
        SaveManager.Instance.coin -= characterPrices[currentCharacter];
        SaveManager.Instance.charectersUnlocked[currentCharacter] = true;
        SaveManager.Instance.Save();
        source.PlayOneShot(purchase);
        UpdateUI();
    }
}
