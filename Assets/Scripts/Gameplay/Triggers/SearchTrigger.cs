using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTrigger : MonoBehaviour
{
    [SerializeField] private StoryManager Story;

    private bool InTrigger = false;
    public bool IsEnabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsEnabled)
        {
            InTrigger = true;
            other.GetComponent<Inventory>().SetMessageText("Press E to search", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsEnabled)
        {
            InTrigger = false;
            other.GetComponent<Inventory>().SetMessageText("", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InTrigger)
        {
            Story.SetText("Nothing...", true);
            Destroy(this);
        }
    }
}
