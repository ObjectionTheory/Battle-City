using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveTime = 0.1f;
    public float speed;
    private bool isMoving;

    private Animator animator;
    private Rigidbody2D rb;

    private float inverseMoveTime;

    private float lastX;
    private float lastY;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        canMove();

        
    }

    void canMove()
    {
        if(isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(
                SmoothMovement(
                    new Vector3(transform.position.x, transform.position.y + 1f, 0)
                    )
                );
            animator.SetInteger("MovingY", 1);
        }
        
        

    }

    IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        Debug.Log("Derp");
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);
            rb.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return new WaitForFixedUpdate();
        }
        isMoving = false;
    }
}
