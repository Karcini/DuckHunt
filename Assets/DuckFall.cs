using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fallLeftImage;
    public GameObject fallRightImage;
    public bool isFallingLeft = true;
    public float timer = 0f;
    public float speed = 5f;
    public bool duckMoved = false;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2)
        {
            if (isFallingLeft)
            {
                fallLeftImage.gameObject.GetComponent<Renderer>().enabled = false;
                fallRightImage.gameObject.GetComponent<Renderer>().enabled = true;
                isFallingLeft = false;
                timer = 0;
            }
            else
            {
                fallRightImage.gameObject.GetComponent<Renderer>().enabled = false;
                fallLeftImage.gameObject.GetComponent<Renderer>().enabled = true;
                isFallingLeft = true;
                timer = 0;
            }
        }

        if (gameObject.transform.position.y < -1.5)
        {
            if (duckMoved == false)
            {
                gameObject.transform.Translate(0,0,2);
                duckMoved = true;
            }
        }

        transform.Translate(Vector3.down *Time.deltaTime * speed);
    }
}
