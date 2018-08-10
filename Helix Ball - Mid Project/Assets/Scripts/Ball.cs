using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void OnCollisionEnter(Collision collision)
    {
        isForce = true;

        if (collision.gameObject.tag == "Enemy")
        {
            isGameOver = true;
        }
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
