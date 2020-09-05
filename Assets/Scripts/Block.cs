using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    Level level;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable"){
            level.CountBlocks();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            PlayBBlockDestroySFX();
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparklesVFX();
        }

    }

    private void PlayBBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX(){

        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position , transform.rotation);

    }

}
