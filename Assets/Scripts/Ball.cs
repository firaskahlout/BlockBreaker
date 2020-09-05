using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPath = 2f;
    [SerializeField] float yPath = 15f;
    [SerializeField] AudioClip[] ballSounds ;

    //state
    Vector2 paddleToBallVector;


    // Cached component reference
    AudioSource myAudioSource;


	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}
    bool hasStarted = false;
    // Update is called once per frame
    void Update ()
    {
        if(!hasStarted){

            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }
    private void LaunchOnMouseClick(){
        if(Input.GetMouseButtonDown(0)){
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPath , yPath);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted){
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }

    }

}
