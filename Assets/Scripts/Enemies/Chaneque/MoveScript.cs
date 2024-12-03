using TreeEditor;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private int rutin;
    private float cronometer;

    private Animator animator;

    private bool isWalking;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private Transform groundController;
    [SerializeField] private float distanceToGround;
    [SerializeField] private bool movingRight;

    [SerializeField] private Transform wallController;
    [SerializeField] private float distanceToWall;

    [SerializeField] private Transform rangeVisionCont;
    [SerializeField] private float rangeVision;
    private bool enemyDetected;

    private bool isAtacking;
    [SerializeField] private GameObject atackCollider;

    private Rigidbody2D rb;
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.enemyDetected = false;
        this.isWalking = false;
        this.isAtacking = false;
    }
    void FixedUpdate()
    {
        if (checkInRange.isPlayerDetected)
        {
            if (!isAtacking)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAtacking", true);

                isAtacking=true;
            }
        }
        else
        {
            RaycastHit2D groundInformation = Physics2D.Raycast(groundController.position, Vector2.down, distanceToGround);
            cronometer += 1 * Time.deltaTime;

            if (cronometer >= 4)
            {
                rutin = Random.Range(0, 3);
                cronometer = 0;
            }

            switch (rutin)
            {
                case 0:
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("isWalking", false);
                    isWalking = false;
                    break;
                default:
                    if (!isWalking)
                    {
                        isWalking = true;
                        animator.SetBool("isWalking", true);
                    }
                    if (!enemyDetected)
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
                    }
                    break;
            }

            RaycastHit2D wallInformation;

            if (movingRight)
            {
                wallInformation = Physics2D.Raycast(wallController.position, Vector2.left, distanceToWall);
            }
            else
            {
                wallInformation = Physics2D.Raycast(wallController.position, Vector2.right, distanceToWall);
            }

            RaycastHit2D rangeOfVision;

            if (movingRight)
            {
                rangeOfVision = Physics2D.Raycast(rangeVisionCont.position, Vector2.left, rangeVision);
            }
            else
            {
                rangeOfVision = Physics2D.Raycast(rangeVisionCont.position, Vector2.right, rangeVision);
            }

            if (groundInformation == false)
            {
                //Girar
                Girar();
            }
            if (rangeOfVision.collider != null)
            {
                if (rangeOfVision.collider.CompareTag("Player"))
                {
                    //Debug.Log("Enemigo detectado");
                    enemyDetected = true;
                }
                else
                {
                    enemyDetected = false;
                }
            }
            if (wallInformation.collider != null)
            {
                if (wallInformation.collider.CompareTag("Ground"))
                {
                    Girar();
                }
            }
        }
    }

    private void Girar()
    {
        movingRight = !movingRight;
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y + 180, 0);
        moveSpeed *= -1;
        runSpeed *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundController.position, groundController.transform.position + Vector3.down * distanceToGround);

        Gizmos.color = Color.blue;
        if(movingRight)
        {
            Gizmos.DrawLine(wallController.position, wallController.transform.position + Vector3.left * distanceToWall);
        }
        else
        {
            Gizmos.DrawLine(wallController.position, wallController.transform.position + Vector3.right * distanceToWall);
        }

        Gizmos.color = Color.yellow;
        if (movingRight)
        {
            Gizmos.DrawLine(rangeVisionCont.position, rangeVisionCont.transform.position + Vector3.left * rangeVision);
        }
        else
        {
            Gizmos.DrawLine(rangeVisionCont.position, rangeVisionCont.transform.position + Vector3.right * rangeVision);
        }
    }

    public void EndAtack()
    {
        isAtacking = false;
        animator.SetBool("isAtacking", false);
    }

    public void StartAtackCollider()
    {
        atackCollider.SetActive(true);
    }
    public void EndAtackCollider()
    {
        atackCollider.SetActive(false);
    }

}
