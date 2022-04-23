using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Text countText;
    public int speed = 500000000;
    private int count;


    void Start()
    {
       count = 0;
       SetCountText();
       rb = GetComponent <Rigidbody>();
    }

    void FixedUpdate()
    {
        float mouveHorizental = Input.GetAxis("Horizontal");
        float mouveVertical = Input.GetAxis("Vertical");

        Vector3 mouvement = new Vector3(mouveHorizental,0,mouveVertical);
        rb.AddForce(mouvement * speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cube")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            }
        if (other.gameObject.tag == "Vide")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetCountText()
    {
        countText.text = "Cubes : " + count.ToString();
    }
}
