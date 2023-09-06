using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFly : MonoBehaviour
{
    //Responsible for flying around
    //When clicked, it should spawn DuckShot, and then go to Score Zone
    public GameObject duckShotPrefab;
    public GameObject duckLookingLeft;
    public GameObject duckLookingRight;
    public float currentX = 0;
    public float currentY = 0;
    public int vectorX; //-1,0,1
    public int vectorY; //-1,0,1

    public float speed = 4.5f;
    public float timer = 0f;
    public Vector3 direction = new Vector3();

    public bool duckWasShot = false;
    public float setTimer = 0;
    public bool birdLeaving = false;
    public int currentDuck = 0;
    void Start()
    {
        timer = 0;
        setTimer = 0;
        vectorX = Random.Range(-1, 2);
        vectorY = 1;
        direction = new Vector3(vectorX,vectorY,0);
        ChangeDuckLeftRight();
        birdLeaving = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        setTimer += Time.deltaTime;
        transform.Translate(direction *Time.deltaTime * speed);
        currentX = gameObject.transform.position.x;
        currentY = gameObject.transform.position.y;
        ChangeDuckLeftRight();

        //For the following sets of ifs...
            //-1,0,1  is a specific change in vector direction
            //2 represents a direction that WILL BE RANDOMIZED randomized between -1,0,1 in the method
        if (birdLeaving == false)
        {
            if (currentX < -4.3)
                ChangeDirection(1,2);
            if (currentX > 4.3)
                ChangeDirection(-1,2);
            if (currentY > 5.3)
                ChangeDirection(2,-1);
            if (timer > 1.5)//Duck is now free flying
            {
                if (currentY < 0)
                    ChangeDirection(2,1);
                if (timer > 2)
                {
                    ChangeDirection(2,2);
                }
            }       
        }

        if (setTimer > 8)
        {
            birdLeaving = true;
            if (currentX < 0)
                vectorX = -1;
            else if (currentX >= 0)
                vectorX = 1;
            ChangeDirection(vectorX,1);

            if (gameObject.transform.position.y > 7.5)
            {
                gameObject.transform.Translate(-gameObject.transform.position.x,-gameObject.transform.position.y,2);
                setTimer = 0;
            }
        }
    }

    void OnMouseDown()
    {
        Instantiate(duckShotPrefab, gameObject.transform.position, gameObject.transform.rotation);
        duckWasShot = true;
        gameObject.transform.Translate(0,0,2);   
    }

    void ChangeDirection(int xConstraint, int yConstraint)
    {
        //making the constraint 2 will make this out of bounds, but any value that is 2 is randomized between -1~1
        vectorX = xConstraint;
        vectorY = yConstraint;
        
        if (xConstraint==2)
            vectorX = Random.Range(-1, 2);
        if(yConstraint==2)
            vectorY = Random.Range(-1, 2);
        if (vectorX == 0 && vectorY == 0)
        {
            if (Random.Range(0, 2) == 1)
                vectorX = 1;
            else
                vectorX = -1;
        }
        
        direction = new Vector3(vectorX,vectorY,0);
        timer = 1.5f;
    }

    void ChangeDuckLeftRight()
    {
        if (vectorX == 1)
        {
            duckLookingLeft.gameObject.GetComponent<Renderer>().enabled = false;
            duckLookingRight.gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (vectorX == -1)
        {
            duckLookingRight.gameObject.GetComponent<Renderer>().enabled = false;
            duckLookingLeft.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}