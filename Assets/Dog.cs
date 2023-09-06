using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //Dog is initiated by click of start game from title
        //This is purely an aesthetic script called on once, by round
    public GameObject dogWalk;
    public GameObject dogJump;

    public float timer = 0f;
    public float sniffDelay = 0f;
    public float jumpTime = 0f;
    public int sniffed = 0;
    public float speed = 0.75f;
    public float jumpSpeed = 0.1f;
    public bool dogJumpedOverGrass = false;
    void Start()
    {
        sniffed = 0;
        dogJumpedOverGrass = false;
    }

    void Update()
    {
        if (timer < 1.5)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.right *Time.deltaTime * speed);   
        }
        else if (sniffed < 2)
        {
            sniffDelay += Time.deltaTime;
            if (sniffDelay > 1.5)
            {
                timer = 0;
                sniffDelay = 0;
                sniffed += 1;
            }
        }
        if (sniffed >=2)
        {
            jumpTime += Time.deltaTime;
            dogWalk.SetActive(false);
            dogJump.SetActive(true);
            transform.Translate(Vector3.right *Time.deltaTime * jumpSpeed);  
            transform.Translate(Vector3.down *Time.deltaTime * speed*3);
            if (jumpTime > .25 && dogJumpedOverGrass==false)
            {
                gameObject.transform.Translate(0,0,0.03f);
                dogJumpedOverGrass = true;
            }

            if (jumpTime > 1)
            {
                gameObject.transform.Translate(0,0,2f);
                jumpTime = 0;
            }
        }
    }

    void OnMouseDown()
    {
        print("Do NOT Shoot your dog.");
    }
}
