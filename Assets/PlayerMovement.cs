using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator PlayerAnim;
    float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
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
            PlayerAnim.SetBool("isAttack" , true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            PlayerAnim.SetBool("isAttack", false);
        }

    }
}
