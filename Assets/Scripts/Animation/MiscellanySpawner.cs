using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reaktion;
using static DavisDnB_AudioManager;

public class MiscellanySpawner : MonoBehaviour
{
    Animator animator;
    Spawner spawner;
    public MusicLayer davisLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spawner = GetComponent<Spawner>();
        spawner.enabled = false;
        //animator.Play("Base Layer");
        DavisDnB_AudioManager.WallTriggerEvent += BrieflyTurnOnSpawner;
    }

    void BrieflyTurnOnSpawner(MusicLayer givenLayer)
    {
        if (givenLayer == davisLayer)
        {
            spawner.enabled = true;
            StartCoroutine(BurstForABit());
        }

    }

    IEnumerator BurstForABit()
    {
        yield return new WaitForSeconds(3f);
        spawner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
