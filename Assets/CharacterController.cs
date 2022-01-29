using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float speed;
    public float walkSpeed = 1.02f;
    public float rotationSpeed = 2.5f;

    Rigidbody rigidbody;
    Animator animator;
    CapsuleCollider capsuleCollider;

    public Transform cameraTransform;

    private float yaw = 0;
    private float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0, yaw, 0);
        cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0);

        Vector3 movementDirection = new Vector3(y, 0, z);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();



        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsJumping", false);

                transform.Translate(Vector3.forward * Time.deltaTime);

            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsIdle", true);

            }

        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsJumping", true);
           
                transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
                transform.Translate(Vector3.forward * 2);

            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsIdle", true);

            }

        }
        

    }
}
