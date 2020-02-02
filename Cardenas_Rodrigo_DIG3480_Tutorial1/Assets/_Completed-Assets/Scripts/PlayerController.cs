using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text LivesText;
    public GameObject player;

    private Rigidbody2D rb2d; 
    private int count;
    private int count1;       

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        count1 = 3;
        winText.text = "";
        SetCountText ();
        SetLivesText ();
    }

    void FixedUpdate()
    {    
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
        if (count1 <= 0)
            {
            Destroy(player);
            }
        if (Input.GetKey("escape"))
            {
            Application.Quit();
            }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
          other.gameObject.SetActive(false);
          count1 = count1 - 1;  
          SetLivesText();
        }
        if (count == 12)
        {
            transform.position = new Vector2(0f, 584.0f); 
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 20)
        {
            winText.text = "YOU WIN! Game created by Rodrigo Cardenas!";
        }
    }

    void SetLivesText ()
    {
        LivesText.text = "Lives: " + count1.ToString ();
        if (count1 <= 0)
        {
            winText.text = "YOU LOSE";
        }
    }
}