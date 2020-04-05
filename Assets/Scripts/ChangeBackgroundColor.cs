using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class ChangeBackgroundColor : MonoBehaviour
{
    public Color charlestonColor, dholakColor, funkColor, ogProdColor, sniperColor, squeakerColor;
    Camera cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = GetComponent<Camera>();
        DavisDnB_AudioManager.WallTriggerEvent += ChangeThatBackgroundColor;
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeThatBackgroundColor;
    }

    void ChangeThatBackgroundColor(MusicLayer mLayer)
    {
        switch (mLayer)
        {
            case MusicLayer.Charleston:
                cameraMain.backgroundColor = charlestonColor;
                break;
            case MusicLayer.Dholak:
                cameraMain.backgroundColor = dholakColor;
                break;
            case MusicLayer.Funk:
                cameraMain.backgroundColor = funkColor;
                break;
            case MusicLayer.OGProd:
                cameraMain.backgroundColor = ogProdColor;
                break;
            case MusicLayer.Sniper:
                cameraMain.backgroundColor = sniperColor;
                break;
            case MusicLayer.Squeaker:
                cameraMain.backgroundColor = squeakerColor;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
