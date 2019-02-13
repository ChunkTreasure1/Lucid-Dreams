using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_03 : MonoBehaviour
{
    [SerializeField] private StoryManager Story;
    [SerializeField] private Light[] Lights;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Story.SetText("Damn the fuse went, I'll need to replace it", true);

            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].enabled = false;
            }

            Destroy(this.gameObject);
        }
    }
}
