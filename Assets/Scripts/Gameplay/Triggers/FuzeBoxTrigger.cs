using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzeBoxTrigger : MonoBehaviour
{
    [SerializeField] private StoryManager Story;
    [SerializeField] private GameObject Door;

    public bool IsEnabled = false;
    private bool InTrigger = false;
    private GameObject Player;
    private bool FirstTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsEnabled)
        {
            InTrigger = true;
            Player = other.gameObject;

            other.GetComponent<Inventory>().SetMessageText("Press E to interact", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsEnabled)
        {
            InTrigger = false;
            Player = null;

            other.GetComponent<Inventory>().SetMessageText("", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InTrigger && FirstTime)
        {
            Player.GetComponent<Inventory>().SetMessageText("", false);

            if (HasScrewdriver(Player))
            {
                Door.SetActive(false);

                Player.GetComponent<Inventory>().SetMessageText("Press E to insert fuse", true);
                FirstTime = false;
            }
            else
            {
                Story.SetText("I can't open it without a screwdriver", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && InTrigger && !FirstTime)
        {
            if (HasFuse(Player))
            {
                //ENEMY ATTACK - INSERT HERE

                //AFTER ENEMY ATTACH
            }
        }
    }

    private bool HasScrewdriver(GameObject player)
    {
        for (int i = 0; i < player.GetComponent<Inventory>().GetItems().Count; i++)
        {
            if (player.GetComponent<Inventory>().GetItems()[i].CompareTag("Screwdriver"))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasFuse(GameObject player)
    {
        for (int i = 0; i < player.GetComponent<Inventory>().GetItems().Count; i++)
        {
            if (player.GetComponent<Inventory>().GetItems()[i].CompareTag("Fuse"))
            {
                return true;
            }
        }

        return false;
    }
}
