using System;

using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable All
// ReSharper disable All

public class Ball : MonoBehaviour
{
    public Rigidbody ball;
    public float speed;
    public static float globalGravity = -9.8f;
    public float gravityScale = 1.0f;
    private bool isForce = false;
    private bool isGameOver = false;
    public static int scoreInRow = 0;

    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        ball.AddForce(gravity, ForceMode.Acceleration);
    }

    private void force()
    {
        isForce = false;
        ball.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    void Update()
    {

        if (isForce)
        {
            force();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isForce = true;

        if (other.gameObject.tag == "Enemy")
        {
            //Fail();
            isGameOver = true;
        }

        else if (other.gameObject.tag == "Helix")
        {
            scoreInRow = 0;
            Debug.Log(string.Format("Score in row: {0}", scoreInRow));

        }

        else if (other.gameObject.tag == "Finish")
        {
            //Win();
            scoreInRow = 0;
            Debug.Log(string.Format("Score in row: {0}", scoreInRow));
            Debug.Log("Finish , you are win");
        }

        //if (other.gameObject.tag == "PassPlatform" && other.gameObje)
        //{
        //    String floorName = other.transform.parent.name;
        //    GameObject floor = GameObject.Find(floorName);

        //    Destroy(floor);

        //    Debug.Log(string.Format("{0} DESTROYED", floorName));
        //}
    }



    private void OnGUI()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
            this.isGameOver = false;
        }
    }
}
