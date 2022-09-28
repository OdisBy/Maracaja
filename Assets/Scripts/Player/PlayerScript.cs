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
    public CatalogueManager catalogue;
    public QuestPageManager questManager;
    public AnimalPageManager animalPageManager;

    [Header("Manager")]
    public bool isPaused;


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

    public bool canGoNextPhase;
    public BoxCollider2D spawnCollider;
    public int questId;

    [Space]

    [Header("Variaveis movimento")]
    public float verticalMove;
    public float horizontalMove;


    [Space]

    [Header("Collisao")]
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;
    public FlipTree flipScript;
    



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = "Player_Idle";
    }

    void Start()
    {
        PlayerPrefs.SetInt("questPageId", 0);
        PlayerPrefs.SetInt("animalPageId", 0);
        canMove = true;
        irSpawnPoint();
        getQuestId();
        questManager.updateInfos();
        animalPageManager.updateInfos();
    }

    public void getQuestId()
    {
        questId = PlayerPrefs.GetInt("questPageId", 0);
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
        if(isGrabbing && canMove)
        {
            escalar();
        }


        //JUMP

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

        //GO NEXT PHASE
        if(Input.GetKey(KeyCode.P) && canGoNextPhase)
        {
            canGoNextPhase = false;
            Debug.Log("Next Phase");
            questId += 1;
            PlayerPrefs.SetInt("questPageId", questId);
            questManager.updateInfos();
            animalPageManager.updateInfos();
        }

        //MOVEMENT
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

        //TAKE PICTURE
        if (Input.GetKey(KeyCode.Q) && canMove)
        {
            takingPicture();
        }

        //UI
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!catalogue.isOpen){
                catalogue.openCatalogue();
            }else{
                catalogue.closeCatalogue();
            }
        }


        //ESC FUNCTIONS
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                return;
            }
            if(catalogue.isOpen){
                catalogue.closeCatalogue();
                return;
            }
            Time.timeScale = 0;
            isPaused = true;

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
                ChangeState("Player_Escalando_Costas");
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

    public void irSpawnPoint()
    {
        transform.position = new Vector3(105.32f, -45.5f, 1);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
    

    private void escalar()
    {
        climbing = true;
        rb.velocity = new Vector3(horizontalMove * speed, verticalMove * speed, 0);
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Casa"))
        {
            if(questManager.allPages[questId].isUnlocked)
            {
                canGoNextPhase = true;
            }
            else{
                canGoNextPhase = false;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Casa"))
        {
            canGoNextPhase = false;
        }
    }


    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;

    //     var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

    //     Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    //     Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
    //     Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);

    //     Gizmos.DrawSphere(moveposition, 0.2f);
    // }

}
