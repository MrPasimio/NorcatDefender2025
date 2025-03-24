using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSelector : MonoBehaviour
{
    public List<Sprite> shipSprites;
    public GameObject loadingText;
    public Image shipDisplay;
    public Button previousButton;
    public Button nextButton;
    public Button launchButton;

    public int shipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ship Selector Initiated");
        GetShips();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetShips()
    {
        Storage.populateShips();
        loadingText.SetActive(true);
        previousButton.interactable = false;
        nextButton.interactable = false;
        launchButton.interactable = false;  
        StartCoroutine(WaitForShipsToLoad());
    }

    public IEnumerator WaitForShipsToLoad()
    {
        while(Storage.isLoading)
        {
            Debug.Log("Loading");
            yield return new WaitForSeconds(0.5f);
        }
        PopulateShipSelector();


    }

    public void PopulateShipSelector()
    {
        loadingText.SetActive(false);
        nextButton.interactable = true;
        previousButton.interactable = true;
        launchButton.interactable = true;

        shipSprites = Storage.shipSprites;
        Debug.Log($"{shipSprites.Count} ships loaded");

        UpdateShipDisplay();
    }

    public void UpdateShipDisplay()
    {
        if (shipSprites.Count > 0)
        {
            shipDisplay.sprite = shipSprites[shipIndex];
        }
        else
        {
            Debug.Log("Ship array empty");
        }
    }

    public void NextShip()
    {
        shipIndex++;
        if(shipIndex >= shipSprites.Count)
        {
            shipIndex = 0;
        }
        UpdateShipDisplay();
    }

    public void PreviousShip()
    {
        shipIndex--;
        if(shipIndex < 0)
        {
            shipIndex = shipSprites.Count - 1;
        }
        UpdateShipDisplay();
    }

    public void Launch()
    {
        Storage.currentShip = shipSprites[shipIndex];
        SceneManager.LoadScene("MainScene");

    }



}
