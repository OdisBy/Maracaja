using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerScript : MonoBehaviour
{

    float proximoMiado = 0.0f;
    float period = 10f;

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
    public Album albumManager;
    public AudioController audioController;
    //public AudioController audioController;

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
    public bool canMove;
    public bool inQuest;
    public bool Grounded;
    public bool isWalkPressed;
    public bool onWall;
    public bool climbing;
    public int wallSide;
    public bool isTalking;
    public float speed = 10;
    [Range(0, 10)]
    public float jumpForce;
    public string currentState;
    public bool onRightWall;
    public bool onLeftWall;
    public Vector3 moveposition;
    public bool canGoNextPhase;
    public int faseAtual;
    public float questIdFloat;
    public gameConfigs gameConfigs;

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
    public BoxCollider2D spawnCollider;


    [Space]

    [Header("FMOD e outros")]
    
    public FMODUnity.EventReference EventFS;

    [SerializeField]
    public Light2D luzGlobal;

    [SerializeField]
    public Color[] coresLuz;

    public faseController faseController;
    



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = "Player_Idle";
        PlayerPrefs.SetInt("questPageId", 0);
        PlayerPrefs.SetInt("animalPageId", 0);
        animalPageManager.resetInfos();
        questManager.resetInfos();
        albumManager.updateInfos();
        audioController.atualizarSom();
    }

    void Start()
    {
        canMove = true;
        irSpawnPoint();
        getQuestId();
        luzGlobal.color = coresLuz[0];
        PlayerPrefs.SetInt("fase", 0);
    }

    public void getQuestId()
    {
        faseAtual = PlayerPrefs.GetInt("fase", 0);
    }


    void Update()
    {
        // Debug.Log(faseAtual);
        //SOM MIADO
        if (Time.time > proximoMiado) {
            proximoMiado += period;
            sonsPlay(2);
        }
        
        //MOVEMENT
        if (isGrabbing){
            canWalk = false;
        }
        else
            canWalk = true;
        Vector2 dir = new Vector2(horizontalMove, verticalMove);
        if (isWalkPressed && canWalk && canMove)
        {
            Walk(dir);
        }
        if (Input.GetButtonDown("Jump") && !isGrabbing && canMove && canWalk)
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
            getQuestId();
            if(faseAtual == 3){
                faseController.finalizarJogo();
            }else{
            faseController.atualizarFase();
            getQuestId();
            canGoNextPhase = false;
            
            questManager.updateInfos();
            animalPageManager.updateInfos();
            albumManager.updateInfos();
            irSpawnPoint();

            questIdFloat = PlayerPrefs.GetInt("fase", 0);
            Debug.Log("Fase = " + questIdFloat);
            if(questIdFloat % 2 == 0){
                Debug.Log("Mudando luz pra dia");
                luzGlobal.color = coresLuz[0];   
            }
            else{
                Debug.Log("Mudando luz pra noite");
                luzGlobal.color = coresLuz[1];
            }
            }
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
                gameConfigs.fecharConfiguracoes();
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
            gameConfigs.abrirConfiguracoes();

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
                if(verticalMove != 0)
                {
                    ChangeState("Player_Escalando");
                }else{
                    ChangeState("Player_Segurando_Arvore");
                }
            }
            else if (Grounded)
            {
                if (isJumping)
                    return;
                if (isWalkPressed && canWalk)
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
        rb.velocity = new Vector3(horizontalMove * speed, verticalMove * speed, 0);
    }

    public void sonsPlay(int a){
        if(a == 0){
            audioController.Passo();
        }else if(a == 1){
            audioController.miadoGatoFunc();
        }else if(a == 2){
            audioController.CairNoChao();
        }else if(a == 3){
            audioController.Pulando();
        }else if(a == 4){
            audioController.foto();
        }else if(a == 5){
            audioController.caindo();
        }else if(a == 6){
            audioController.Escalando();
        }else if(a == 7){
            audioController.zoom();
        }
    }


    void takingPicture()
    {
        ChangeState("Player_Taking_Picture");
        canMove = false;
    }
    void finishPicture()
    {
        ChangeState("Player_Idle");
        pic.picture();
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
            getQuestId();
            if(questManager.allPages[faseAtual].isUnlocked)
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

}
