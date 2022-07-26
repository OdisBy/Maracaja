using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{

    //Instancias
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;
    [SerializeField]
    public PictureManager pic;


    [Header("Layers")]
    public LayerMask groundLayer;
    public LayerMask escalavelLayer;

    [Space]

    [Header("Variaveis")]
    [HideInInspector]
    public bool Jumping;
    public bool canWalk;
    public bool isGrabbing;
    public bool isJumping;
    public bool isFlipping;
    public bool canMove;
    public bool inQuest;
    public bool Grounded;
    public bool isWalkPressed;
    public bool onWall;
    public bool climbing;
    public int wallSide;
    public float speed = 10;
    [Range(0, 10)]
    public float jumpForce;
    public string currentState;
    public bool onRightWall;
    public bool onLeftWall;
    public Vector3 moveposition;

    Vector3Int obstacleMapTile;

    [Space]

    [Header("Variaveis movimento")]
    public float verticalMove, horizontalMove;


    [Space]

    [Header("Collisao")]
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;
    public Tilemap obstacles;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = "Player_Idle";
    }

    void Start()
    {
        canMove = true;
    }


    void Update()
    {
        //MOVEMENT
        if (isGrabbing)
            canWalk = false;
        else
            canWalk = true;
        Vector2 dir = new Vector2(horizontalMove, verticalMove);
        if (isWalkPressed && canWalk && canMove)
        {
            Walk(dir);
        }
        if (Input.GetButtonDown("Jump") && !isGrabbing && canMove)
        {
            if (Grounded)
            {
                Jump();
                Jumping = true;
            }
        }



        //ESCALADA
        if (Input.GetButton("Jump") && isGrabbing && canMove)
        {
            escalar(true);
        }
        else if (Input.GetButtonUp("Jump") && isGrabbing && canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            climbing = false;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isGrabbing && canMove)
        {
            escalar(false);
        }
        else if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && isGrabbing && canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            climbing = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && isGrabbing && canMove)
        {
            iniciarFlipArvore();
        }





        if (rb.velocity.y != 0 && !isGrabbing && isJumping == false)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }


        if (!Mathf.Approximately(0, dir.x) && canWalk && canMove)
        {
            transform.rotation = dir.x > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }



        //INPUT
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (horizontalMove != 0)
        {
            isWalkPressed = true;
        }
        else
        {
            isWalkPressed = false;
        }
        if (onWall && Input.GetKey(KeyCode.LeftShift))
        {
            isGrabbing = true;
        }
        else
        {
            isGrabbing = false;
        }

        //Tirar foto
        if (Input.GetKey(KeyCode.Q) && canMove)
        {
            takingPicture();
        }


        //COLLISION
        Grounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, escalavelLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, escalavelLayer);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, escalavelLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, escalavelLayer);

        wallSide = onRightWall ? -1 : 1;



        //ANIMATION
        if (canMove)
        {
            if (isGrabbing)
            {
                if (climbing)
                {
                    ChangeState("Player_Climb");
                    return;
                }

                ChangeState("Player_Grab");
            }
            else if (Grounded)
            {
                if (isJumping)
                    return;
                if (isWalkPressed)
                    ChangeState("Player_Walk");
                else
                    ChangeState("Player_Idle");
            }
            else if (isJumping)
            {
                if (rb.velocity.y > 0)
                {
                    ChangeState("Player_Jump");
                    return;
                }
                ChangeState("Player_Fall");
                return;
            }
        }
    }
    void FixedUpdate()
    {
        if (isGrabbing)
        {
            rb.gravityScale = 0f;
            Physics2D.gravity = new Vector2(0, 0);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
            rb.gravityScale = 1f;
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void escalar(bool up)
    {
        if (!isFlipping)
        {
            if (up)
            {
                rb.velocity = Vector2.up * speed;
                climbing = true;
            }
            else
            {
                rb.velocity = Vector2.down * speed;
                climbing = true;
            }
        }
        else
        {
            rb.velocity = Vector2.up * 0;
        }
    }

    private void iniciarFlipArvore()
    {
        //TODO PLAYER PODER ENTRAR NA ARVORE
        isFlipping = true;
        anim.Play("Player_Arvore_Flip");
    }

    private void rodarArvore()
    {
        isFlipping = false;
        anim.Play("Player_Grab");

        if (onRightWall)
        {
            moveposition = transform.position + new Vector3(horizontalMove + -2.5f, verticalMove, 0);
            obstacleMapTile = obstacles.WorldToCell(moveposition);
        }
        else
        {
            moveposition = transform.position + new Vector3(horizontalMove + 2.5f, verticalMove, 0);
            obstacleMapTile = obstacles.WorldToCell(moveposition);
        }
        if (obstacles.GetTile(obstacleMapTile) == null)
        {

            transform.position = moveposition;
            transform.rotation = onRightWall ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
        else if (obstacles.GetTile(obstacleMapTile).name.Contains("pixil-frame-0_69"))
        {
            Debug.Log("Galho");
        }
        else
        {
            Debug.Log(obstacles.GetTile(obstacleMapTile).name);
        }
    }

    void takingPicture()
    {
        ChangeState("Player_Taking_Picture");
        canMove = false;
    }
    void finishPicture()
    {
        pic.picture();
        canMove = true;
    }

    public void returnPictureAnimal(AnimalScript _FotoAnimal)
    {
        Debug.Log("Return animal: " + _FotoAnimal);
    }
    public void returnPicturePlanta(PlantsScript _FotoPlanta)
    {
        Debug.Log("Return planta: " + _FotoPlanta);
    }
    public void returnPictureVazia()
    {
        Debug.Log("Return vazio");
    }



    //MAQUINA DE ESTADOS ANIMAÇÃO
    internal void ChangeState(string newState)
    {
        if (newState != currentState)
        {
            anim.Play(newState);
            currentState = newState;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);

        Gizmos.DrawSphere(moveposition, 0.2f);
    }

}
