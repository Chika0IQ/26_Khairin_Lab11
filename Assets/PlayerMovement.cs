using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float speed = 2.0f;
    float health = 100f;
    bool isDead = false;

    public GameObject Cube;
    public GameObject HealthText;
    Rigidbody player;
    Animator PlayerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePlay(); // Start of Gameplay
    }

    void PlayerAttack()
    {
        PlayerAnim.SetTrigger("isAttack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Decrease Health when player touches the cube by -10
        if (collision.gameObject.CompareTag("Cube"))
        {
            health -= 10;
            HealthText.GetComponent<Text>().text = ("Health: " + health);
        }
    }

    private void GamePlay()
    {
        bool iscol = PlayerAnim.GetBool("isCol");
        if (!isDead)
        {
            //Forward Movememt
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnim.SetBool("isStrafe", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Backward Movement
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnim.SetBool("isStrafe", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Left Movement
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                PlayerAnim.SetBool("isStrafe", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Right Movement
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnim.SetBool("isStrafe", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            // Call Attack Trigger
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAttack();
            }

            // Health of Player 
            if (health <= 0)
            {
                PlayerAnim.SetBool("isCol", true);
                isDead = true;
            }
        }
    }
}
