using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float SoundLevel = 100f;
    public Animator _animate;
    [SerializeField] private SoundSender SoundSender;

    [Header("Audio")]
    [SerializeField] private AudioSource OpenDoor;
    [SerializeField] private AudioSource CreakingDoor;
    [SerializeField] private AudioSource HandleShake;

    public bool IsLocked;
    public bool CanOpen;
    public bool DoorKey;

    public bool IsSprayed = false;
    private Inventory PlayerInv;

    // Start is called before the first frame update
    void Start()
    {
        _animate = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {           
         if (other.tag == "Player")
         {
            CanOpen = true;
            PlayerInv = other.GetComponent<Inventory>();
            PlayerInv.SetMessageText("Press E to open", true);
         }     

    }

    private void OnTriggerExit(Collider other)
    {               
         if (other.tag == "Player")
         {
            CanOpen = false;
            _animate.SetBool("open", false);
            PlayerInv.SetMessageText("", false);
            PlayerInv = null;
         }       
    }

    // Update is called once per frame
    void Update()
    {   
        if(CanOpen)
        {
            if (IsLocked)
            {
                if (!DoorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        HandleShake.Play();
                        PlayerInv.SetMessageText("Door locked, key needed.", false);
                    }
                }
                if (DoorKey)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        OpenDoor.Play();

                        if (IsSprayed)
                        {
                            SoundSender.SendSound(SoundLevel, MovingMode.mM_Null);
                        }
                        else
                        {
                            CreakingDoor.Play();
                        }

                        CanOpen = false;
                        IsLocked = false;

                        _animate.SetBool("open", true);
                        PlayerInv.SetMessageText("", false);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenDoor.Play();

                    if (IsSprayed)
                    {
                        SoundSender.SendSound(SoundLevel, MovingMode.mM_Null);
                    }
                    else
                    {
                        CreakingDoor.Play();
                    }
                    IsLocked = false;
                    CanOpen = false;

                    _animate.SetBool("open", true);
                    PlayerInv.SetMessageText("", false);
                }
            }
        }

    }
        
}
