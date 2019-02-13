using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private float NoDetectedReach;
    [SerializeField] private float DetectedReach;
    [SerializeField] PostProcessingProfile PPProfile;

    private bool IsDetected = false;
    private float Range = 0;
    private VignetteModel.Settings VignetteSettings;

    private void Update()
    {
        if (IsDetected)
        {
            Range = DetectedReach;
        }
        else
        {
            Range = NoDetectedReach;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Range);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Enemy"))
            {
                //Play animation
                VignetteSettings = PPProfile.vignette.settings;
                VignetteSettings.color = new Color(0, 0, 0);

                PPProfile.vignette.settings = VignetteSettings;
            }
        }
    }
}
