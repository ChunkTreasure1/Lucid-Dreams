using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    [SerializeField] private List<Transform> Positions = new List<Transform>();
    [SerializeField] private int AmountOfBatteries;
    [SerializeField] private GameObject Battery;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AmountOfBatteries; i++)
        {
            int n = Random.Range(0, Positions.Count);
            GameObject Clone = Instantiate(Battery, Positions[n].position, Positions[n].rotation);
            Positions.Remove(Positions[n]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
