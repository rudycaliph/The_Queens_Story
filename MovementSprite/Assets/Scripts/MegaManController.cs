using UnityEngine;
using System.Collections;

public class MegaManController : MonoBehaviour {

    public Animator anim;
    public float maxSpeed = 10f;
    bool facingRight = true;
    float punchForce = 3000;
    float punchDist = 1.5f;

    Vector3 hitVec;
    Vector3 playerVec;

    GameObject fistPunch;
    public bool isSwitching = false;

    
    public EnemyController enemy;

    //bool isPrince = true;

    public bool grounded = true;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask isThisGround;

    float damage = 10;

    public Transform enemyCheck;
    float punchRadius = 0.4f;
    public LayerMask isThisEnemy;
    bool isHit = false;

    float jumpForce = 600f;
    public SpriteRenderer spriteRenderer;
    

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = renderer as SpriteRenderer;
        spriteRenderer.color = Color.red;
       // fistPunch = new GameObject() ;
        
	}

    void backToNormal()
    {
        isSwitching = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //anim.SetBool("isSwitching", true);
        
        if (!isSwitching)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, isThisGround);



            anim.SetBool("ground", grounded);

            float move = Input.GetAxis("Horizontal");

            anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

            rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

            anim.SetFloat("speed", Mathf.Abs(move));

            if (move > 0 && !facingRight)
                Flip();
            else
                if (move < 0 && facingRight)
                    Flip();
        }
        
	}



    void Update()
    {
        playerVec = rigidbody2D.transform.position;
        
        if (!isSwitching)
        {
            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("ground", false);

                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("PunchWait");
                anim.SetTrigger("punch");
                //  rigidbody2D.AddForce(new Vector2(punchForce, 0));
                if (facingRight)
                {
                    fistPunch = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("fist2"),
                        new Vector3(rigidbody2D.transform.position.x + punchDist,
                            rigidbody2D.transform.position.y),
                            Quaternion.identity);
                    enemy.canBeHit = false;
                    
                    
                    fistPunch.tag = "fistPunch";
                }
                else
                    if (!facingRight)
                    {
                        fistPunch = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("fist2"),
                        new Vector3(rigidbody2D.transform.position.x - punchDist,
                            rigidbody2D.transform.position.y),
                            Quaternion.identity);
                        enemy.canBeHit = false;
                        fistPunch.tag = "fistPunch";
                    }
                
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {

                StartCoroutine("PunchWait");
                
            }

            if (fistPunch != null)
            {
                if (facingRight)
                {
                    playerVec.x += punchDist;
                    fistPunch.transform.position = playerVec;
                }
                if (!facingRight)
                {
                    playerVec.x -= punchDist;
                    fistPunch.transform.position = playerVec;
                }
            }

        }
    }

    public void beingHitAgain()
    {
        enemy.canBeHit = true;
    }

    IEnumerator PunchWait()
    {
        
        Debug.Log("waiting...");
        yield return new WaitForSeconds(.55f);
        GameObject[] fist = GameObject.FindGameObjectsWithTag("fistPunch");
        for (int x = 0; x < fist.Length; x++)
        {
            Destroy(fist[x]);
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        punchForce *= -1;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Coin")
        {
            Debug.Log("Coin Hit");
            Destroy(col.gameObject);

        }
    }
}
