using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;


public class BallControlScript : MonoBehaviour {

    // Reference to Rigidbody2D component of the ball game object
    public TextMesh scoreText;
    public TextMesh GameOver;

    public GameObject MenuGameOver;
    private int Yrotate = 0;
    private int Xrotate = 0;
    double interval = 0.5;
    double nextTime1 = 0.25;
    double nextTime = 0;
    float actualY;
    static int levelCount = 1;
    Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;

    // Range option so moveSpeedModifier can be modified in Inspector
    // this variable helps to simulate objects acceleration
    [Range(0.5f, 2f)]
	public float moveSpeedModifier = 1.5f;

	// Direction variables that read acceleration input to be added
	// as velocity to Rigidbody2d component
	float dirX, dirY;

	// Reference to Balls Animator component to control animaations transition
	Animator anim;

    public static GameObject life1;
    public static GameObject life2;
    public static GameObject life3;


    public static int life;

    static bool Pause = false;

    static bool stoper;

	// Setting bool variable that ball is alive at the beginning
	static bool isDead;

    static bool subLife = false;

    // Adding points to score 
    static bool addPoint;

	// Variable to allow or disallow movement when ball is alive or dead
	static bool moveAllowed;

	// Variable to be set to true if you win
	static bool youWin;

    // Reference to WinText game object to control its appearance
    // Text game object can be added in inspector because of [SerializeField] line

    [SerializeField]
    public static int score;

    // Use this for initialization
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start () {


        //if(levelCount == 1)
        // score = 0;
        if(life == 3)
        {

            stoper = false;
            UpdateScore();

            // You don't win at the start
            youWin = false;

            // Movement is allowed at the start
            moveAllowed = true;

            // Ball is alive at the start
            isDead = false;

            // Getting Rigidbody2D component of the ball game object
            rb = GetComponent<Rigidbody2D>();

            // Getting Animator component of the ball game object
            anim = GetComponent<Animator>();

            // Set BallAlive animation
            anim.SetBool("BallDead", isDead);
        }
        if(life == 2)
        {
            stoper = false;
            life3 = GameObject.Find("life3");
            life3.SetActive(false);

            UpdateScore();

            // You don't win at the start
            youWin = false;

            // Movement is allowed at the start
            moveAllowed = true;

            // Ball is alive at the start
            isDead = false;

            // Getting Rigidbody2D component of the ball game object
            rb = GetComponent<Rigidbody2D>();

            // Getting Animator component of the ball game object
            anim = GetComponent<Animator>();

            // Set BallAlive animation
            anim.SetBool("BallDead", isDead);
        }
        if (life == 1)
        {
            stoper = false;
            life3 = GameObject.Find("life3");
            life3.SetActive(false);
            life2 = GameObject.Find("life2");
            life2.SetActive(false);

            UpdateScore();

            // You don't win at the start
            youWin = false;

            // Movement is allowed at the start
            moveAllowed = true;

            // Ball is alive at the start
            isDead = false;

            // Getting Rigidbody2D component of the ball game object
            rb = GetComponent<Rigidbody2D>();

            // Getting Animator component of the ball game object
            anim = GetComponent<Animator>();

            // Set BallAlive animation
            anim.SetBool("BallDead", isDead);
        }

	}

    // Update is called once per frame
    void Update() {

       

        if (Pause)
        {
            Time.timeScale = 0F;
        }
        // Getting devices accelerometer data in X and Y direction
        // multiplied by move speed modifier
        else
        {
            Time.timeScale = 1F;
            dirX = Input.acceleration.x * moveSpeedModifier;
            dirY = Input.acceleration.y * moveSpeedModifier;




            //if addPoint true add Point to score
            if (addPoint)
            {
                AddScore(10);
                UpdateScore();
                addPoint = false;
            }
            // if isDead is true
            if (isDead)
            {
                moveAllowed = false;
                if (life == 1 && stoper == false)
                {
                    life = 0;
                    levelCount = 0;
                    stoper = true;
                    life1 = GameObject.Find("life1");
                    Destroy(life1);
                    // then ball movement is stopped
                    rb.velocity = new Vector2(0, 0);
                    //UpdateGameOver();

                    MenuGameOver.SetActive(true);

                    // Set Animators BallDead variable to true to switch to 
                    anim.SetBool("BallDead", isDead);

                  //  Invoke("RestartScene", 1f);

                }
		  
                if (life == 2 && stoper == false)
                {
		    moveAllowed = false;
                    life = 1;
                    stoper = true;

                    rb.velocity = new Vector2(0, 0);

                    anim.SetBool("BallDead", isDead);
                    
                    Invoke("RestartScene", 1f);

                }

                if (life == 3 && stoper ==false)
                {
                    life = 2;
                    stoper = true;
                    // then ball movement is stopped
                    rb.velocity = new Vector2(0, 0);

                    // Set Animators BallDead variable to true to switch to 
                    anim.SetBool("BallDead", isDead);

                    
                    Invoke("RestartScene", 1f);
                    

                }            
            }

            // If you win
            if (youWin)
            {

                // then ball movement is stopped
                rb.velocity = new Vector2(0, 0);



                // ball movement is not allowed anymore
                moveAllowed = false;

                // switch to Ball Dead Animation so ball falls into exit hole
                anim.SetBool("BallDead", true);

                // Restart scene to play again in 2 seconds
                Invoke("RestartScene", 2f);
            }
        }

	}

    void FixedUpdate()
	{

        // Setting a velocity to Rigidbody2D component according to accelerometer data
        if (moveAllowed)
            rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y + dirY);

        //screen always active
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //get actual postion ball Y
        if (Time.time >= nextTime1)
        {
            var pos1 = rb.transform.position;
            actualY = pos1.y;
            nextTime1 += interval;
        }
            
            if (Time.time >= nextTime)
            {
            var pos = rb.transform.position;
                
                if(pos.y - actualY < 1 && pos.y - actualY > -1)
                {
                 nextTime += interval;
                    Yrotate++;
                }
                else
                {
                    if (Yrotate % 2 == 0)
                        mySpriteRenderer.flipY = true;
                    if (Yrotate % 2 == 1)
                        mySpriteRenderer.flipY = false;
                    nextTime += interval;
                    Yrotate++;
                }
            }
            
    }


    public void Updatelife()
    {
        life = life - 1;

    }
    public void AddScore (int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score:     " + score;
    }

    void UpdateGameOver()
    {
        GameOver.text = "Game Over!";
    }
    // Method is invoked by DeathHoleScript when ball touches deathHole collider
    public static void setIsDeadTrue()
	{
		// Setting isDead to true
		isDead = true;

	}

    public static void setLifeOnThree()
    {
        // Setting isDead to true
        life = 3;

    }

    public static void setScoreOnZero()
    {
        // Setting isDead to true
        score = 0;

    }

    public static void setPauseTrue()
    {
        Pause = true;
    }

    public static void setPauseFalse()
    {
        Pause = false;
    }


    public static void setAddPointTrue()
    {
        // Setting isDead to true
        addPoint = true;

    }

    public static void setlevelCount(int i)
    {
        // Setting isDead to true
        levelCount = i;
    }

    // Method is inviked by exit hole game object when ball thouches its collider
    public static void setYouWinToTrue()
	{
		youWin = true;
	}

	// Method to restart current scene
	void RestartScene()
	{
        if (youWin)
            SceneManager.LoadScene(0);
        if(isDead)
            SceneManager.LoadScene(levelCount);
    }
}
