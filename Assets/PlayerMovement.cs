using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator PlayerAnim;
    float speed = 10.0f;
    bool onCube = false;


    public GameObject Cube;
    Rigidbody player;


    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Move Forward Bool
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            PlayerAnim.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnim.SetBool("isStrafe", false);
        }

        //Attack Trigger
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }

        if (onCube == true)
        {
            
            PlayerAnim.SetBool("isCol", true);
        }
    }

    void PlayerAttack()
    {
        PlayerAnim.SetTrigger("isAttack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            PlayerAnim.SetBool("isCol", true);
            onCube = true;
        }
    }
}
