using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text deathsText;
    public Text goldText;
    public GameObject playcon;

    public float jumpForce = 5f;
    public float moveSpeed = 5f;

    public int currentGold = 100;
    public int coinValue = 5;
    public int monsterValue = 10;
    public int deathCount = 0;

    Animator anim;

    public bool startGame = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        goldText.text = "Gold: " + currentGold;
    }

    void FixedUpdate()
    {
        if (startGame)
        {
            rb.transform.position += rb.transform.right * Time.deltaTime * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("JumpButton"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if(coll.CompareTag("FightButton"))
        {
            // fight animation incl. fight function (maybe another script)
        }
        else if (coll.CompareTag("WaitButton"))
        {
            anim.SetBool("startMoving", false);
            // startGame = false;
            StartCoroutine(Waiting(3f));
        }
        else if (coll.CompareTag("damage") || coll.CompareTag("enemy"))
        {
            startGame = false;
            anim.SetBool("takingDamage", true);
            deathCount++;
            Debug.Log(deathCount);
            deathsText.text = "Deaths: " + deathCount;
            StartCoroutine(RestartGame(3f));
            
        }
        else if(coll.CompareTag("coin"))
        {
            currentGold += coinValue;
            goldText.text = "Gold: " + currentGold;
            Destroy(coll.gameObject);

        }
        // Muss noch getestet werden. Animation funktioniert noch nicht ganz.
        else if (coll.CompareTag("Goal"))
        {
            startGame = false;
            playcon.GetComponentInParent<Animator>().SetBool("Goal", true);
            // anim.SetBool("Goal", true);
            StartCoroutine(ChangeScene(3f));
        }
       /* else if (coll.CompareTag("ShrinkButton"))
        {
            startGame = false;
            anim.SetBool("startMoving", false);
            anim.SetBool("shrink", true);
            StartCoroutine(PlayerGrow(2f));
            transform.localScale = new Vector3(3, 3, 0);
        }*/
    }
    public void GetStartet()
    {
        anim.SetBool("startMoving", true);
        startGame = true;
    }

    public void StopMoving()
    {
        rb.transform.position = transform.position;
    }

    IEnumerator Waiting(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("startMoving", true);
        startGame = true;
    }

    IEnumerator RestartGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*IEnumerator PlayerGrow(float time)
    {
        yield return new WaitForSeconds(time);
        startGame = true;
        anim.SetBool("startMoving", true);
    }*/

}
