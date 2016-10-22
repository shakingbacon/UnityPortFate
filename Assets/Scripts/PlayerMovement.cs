using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rbody;
    Animator anim;
      


	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveVect = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveVect != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", moveVect.x);
            anim.SetFloat("input_y", moveVect.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        rbody.MovePosition(rbody.position + moveVect * Time.deltaTime);
	}
}
