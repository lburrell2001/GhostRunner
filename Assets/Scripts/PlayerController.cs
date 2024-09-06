using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float xInput;
    private float yInput;
    private Rigidbody rb;
    private int coinsCollected;
    public GameObject WinText;
    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(xInput, 0, yInput) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void OnTriggerEnter(Collider other)  // Note the corrected capitalization
    {
       if (other.CompareTag("Coin"))
       {
            coinsCollected++;
            other.gameObject.SetActive(false);

            if (coinsCollected >= 9)
            {
                //win game
                WinText.SetActive(true);
            }
       }
    }
}




   