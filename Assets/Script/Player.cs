// using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject[] CircleInstance;
    public GameObject[] CurrentCircles;
    public string currentColor;
    public float jumpForce = 10f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Color blue,yellow,pink,purple;
    public static int score = 0;
    public Text scoreText;
    void Start()
    {
        setRandomColor();
    }

    void Update()
    {
        if( Input.GetButtonDown("Jump") || Input.GetMouseButton(0) ) {
            circle.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D( Collider2D collision ) {
        if( collision.CompareTag("Scored") ) {
            score++;
            scoreText.text = score.ToString();
            Destroy( collision.gameObject );
            InstanceCircle();
            return;
        }
        if( collision.CompareTag("ColorChanger") ) {
            setRandomColor();
            Destroy( collision.gameObject );
            return;
        }
        if( !collision.CompareTag( currentColor ) ) {
            print("Die!!!");
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            score = 0;
            scoreText.text = score.ToString();
        }
        print(collision.tag); 
    }

    void setRandomColor() {
        int rand = Random.Range( 0 , 4 );
        switch ( rand )
        {
            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
        }
    }

    void InstanceCircle() {
        int randomNumber = Random.Range( 0 , CircleInstance.Length );

        /* foreach (GameObject item in CurrentCircles) {
            Destroy( item );
        } */

        switch ( randomNumber )
        {
            case 0:
                System.Array.Resize(ref CurrentCircles, CurrentCircles.Length + 1);
                CurrentCircles.SetValue(Instantiate( CircleInstance[0] , new Vector2( transform.position.x , transform.position.y + 11f ) , transform.rotation ), CurrentCircles.Length - 1);
                break;
            case 1:
                System.Array.Resize(ref CurrentCircles, CurrentCircles.Length + 1);
                CurrentCircles.SetValue(Instantiate( CircleInstance[1] , new Vector2( transform.position.x , transform.position.y + 11f ) , transform.rotation ), CurrentCircles.Length - 1);
                break;
        }
    }
}
