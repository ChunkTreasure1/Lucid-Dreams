using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineMenu : MonoBehaviour
{
    [SerializeField] private Image ItemOne;
    [SerializeField] private Image ItemTwo;

    [SerializeField] private Sprite Battery;
    [SerializeField] private Sprite Clock;
    [SerializeField] private Sprite Flashlight;

    [SerializeField] private Inventory PlayerInv;

    private bool HasFirstItem = false;
    private bool HasSecondItem = false;

    private GameObject ItemOneObj;
    private GameObject ItemTwoObj;

    enum CurrentlySelected
    {
        cS_Flashlight,
        cS_Clock,
        cS_None
    }

    CurrentlySelected CurrentlySelectedCombineItem;

    // Start is called before the first frame update
    void Start()
    {
        ItemOne.enabled = false;
        ItemTwo.enabled = false;
    }

    public void SetFlashlight()
    {
        ItemOne.sprite = Flashlight;
        ItemTwo.sprite = Battery;

        ItemOne.enabled = true;
        ItemTwo.enabled = true;
    }

    public void SetClock()
    {
        ItemOne.sprite = Clock;
        ItemTwo.sprite = Battery;

        ItemOne.enabled = true;
        ItemTwo.enabled = true;

        HasFirstItem = false;
        HasSecondItem = false;

        ItemOneObj = null;
        ItemTwoObj = null;
    }

    public void CombineItems()
    {
        if (CurrentlySelectedCombineItem == CurrentlySelected.cS_Clock)
        {
            for (int i = 0; i < PlayerInv.GetItems().Count; i++)
            {
                if (PlayerInv.GetItems()[i].CompareTag("Clock"))
                {
                    HasFirstItem = true;
                    break;
                }
            }

            for (int i = 0; i < PlayerInv.GetItems().Count; i++)
            {
                if (PlayerInv.GetItems()[i].CompareTag("Battery"))
                {
                    HasSecondItem = true;
                    break;
                }
            }

            if (HasSecondItem && HasFirstItem)
            {

            }
        }
        else if (CurrentlySelectedCombineItem == CurrentlySelected.cS_Flashlight)
        {
            for (int i = 0; i < PlayerInv.GetItems().Count; i++)
            {
                if (PlayerInv.GetItems()[i].CompareTag("Flashlight"))
                {
                    HasFirstItem = true;
                }
            }

            for (int i = 0; i < PlayerInv.GetItems().Count; i++)
            {
                if (PlayerInv.GetItems()[i].CompareTag("Battery"))
                {
                    HasSecondItem = true;
                }
            }

            if (HasFirstItem && HasSecondItem)
            {

            }
        }
    }
}