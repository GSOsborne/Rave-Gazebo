using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class BurstOnGesture : MonoBehaviour
{
    public bool checkIfLH;
    ParticleSystem pStm;
    // Start is called before the first frame update
    void Start()
    {
        pStm = GetComponent<ParticleSystem>();
        DavisDnB_AudioManager.WallTriggerEvent += Burst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Burst(MusicLayer mLayer)
    {
        if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude > OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude)
        {
            if (checkIfLH)
            {
                pStm.Play();
            }
        }
        else
        {
            if (!checkIfLH)
            {
                pStm.Play();
            }
        }
    }
}
