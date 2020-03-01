﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavisDnB_AudioManager : MonoBehaviour
{
    public AK.Wwise.Event DavisDnBSongStart;

    public enum MusicLayer { Charleston, Dholak, Funk, OGProd, Sniper, Squeaker };

    public enum SongName { DavisDnB};

    public static DavisDnB_AudioManager Instance { get; private set; }

    public static event System.Action<MusicLayer> WallTriggerEvent;
    public static event System.Action<SongName> StartSongEvent;
    public static event System.Action StopAllMusic;

    float chargeLevel;
    public float chargeFadeMultiplier;
    public float chargeBoostValue;

    public bool songPlaying;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        songPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (songPlaying)
        {
            AkSoundEngine.SetRTPCValue("ChargeLevel", chargeLevel);
        }
        if (chargeLevel > 0)
        {
            FadeCharge();
        }

    }

    public void TriggerWallEvent(MusicLayer musicLayer)
    {
        WallTriggerEvent?.Invoke(musicLayer);
        switch (musicLayer)
        {
            case MusicLayer.Charleston:
                AkSoundEngine.PostEvent("LayerCharleston", gameObject);
                break;
            case MusicLayer.Dholak:
                AkSoundEngine.PostEvent("LayerDholak", gameObject);
                break;
            case MusicLayer.Funk:
                AkSoundEngine.PostEvent("LayerFunk", gameObject);
                break;
            case MusicLayer.OGProd:
                AkSoundEngine.PostEvent("LayerOGProd", gameObject);
                break;
            case MusicLayer.Sniper:
                AkSoundEngine.PostEvent("LayerSniper", gameObject);
                break;
            case MusicLayer.Squeaker:
                AkSoundEngine.PostEvent("LayerSqueaker", gameObject);
                break;
        }
        BoostCharge();
    }



    public void StartASong(SongName whichSongName)
    {
        StartSongEvent?.Invoke(whichSongName);
        DavisDnBSongStart.Post(gameObject, (uint)AkCallbackType.AK_MusicSyncBar, EveryMeasure);
        Debug.Log("Started Wizard Song!");
        songPlaying = true;
        chargeLevel = 0f;
    }

    void EveryMeasure(object in_cookie, AkCallbackType in_type, object in_info)
    {
        //Debug.Log("New Measure, Closing Fills.");
        AkSoundEngine.PostEvent("CloseFills", gameObject);
    }

    public void StopMusic()
    {
        AkSoundEngine.PostEvent("StopMusic", gameObject);
        StopAllMusic?.Invoke();
        songPlaying = false;
    }

    void BoostCharge()
    {
        chargeLevel = Mathf.Clamp(chargeLevel + chargeBoostValue, 0, 100);
        Debug.Log("Charge Level is now at: " + chargeLevel);
    }

    void FadeCharge()
    {
        chargeLevel = Mathf.Clamp(chargeLevel - chargeFadeMultiplier * Time.deltaTime, 0, 100);
    }















    //This is all just for Debugging in the canvas

    public void StartSong()
    {
        Debug.Log("Started Wixard Song!");
        DavisDnBSongStart.Post(gameObject, (uint)AkCallbackType.AK_MusicSyncBar, EveryMeasure);

    }

    public void TriggerCharleston()
    {
        AkSoundEngine.PostEvent("LayerCharleston", gameObject);
    }

    public void TriggerDholak()
    {
        AkSoundEngine.PostEvent("LayerDholak", gameObject);
    }

    public void TriggerFunk()
    {
        AkSoundEngine.PostEvent("LayerFunk", gameObject);
    }

    public void TriggerOGProd()
    {
        AkSoundEngine.PostEvent("LayerOGProd", gameObject);
    }

    public void TriggerSqueaker()
    {
        AkSoundEngine.PostEvent("LayerSqueaker", gameObject);
    }

    public void TriggerSniper()
    {
        AkSoundEngine.PostEvent("LayerSniper", gameObject);
    }
}
