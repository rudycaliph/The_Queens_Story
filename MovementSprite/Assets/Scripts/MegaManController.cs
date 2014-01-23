using UnityEngine;
using System.Collections;

public class MegaManController : MonoBehaviour {

    public Animator anim;
    public float maxSpeed = 10f;
    bool facingRight = true;
    float punchForce = 3000;

    public bool isSwitching = false;

    //bool isPrince = true;

    bool grounded = true;
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
	}

    void backToNormal()
    {
        isSwitching = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.SetBool("isSwitching", true);
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

    //void OnCollisionEnter(Collision collision)
    //{
    //    isHit = Physics2D.OverlapCircle(enemyCheck.position, punchRadius, isThisEnemy);
    //}

    void Update()
    {

        

            if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("ground", false);

                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("punch");
                //  rigidbody2D.AddForce(new Vector2(punchForce, 0));
                if (facingRight)
                {
                    GameObject fistPunch = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("fist2"),
                        new Vector3(rigidbody2D.transform.position.x + 1,
                            rigidbody2D.transform.position.y),
                            Quaternion.identity);
                    //fistPunch.rigidbody2D.active = true;
                    fistPunch.tag = "fistPunch";
                }
                else
                    if (!facingRight)
                    {
                        GameObject fistPunch = (GameObject)Instantiate(GameObject.FindGameObjectWithTag("fist2"),
                        new Vector3(rigidbody2D.transform.position.x - 1,
                            rigidbody2D.transform.position.y),
                            Quaternion.identity);
                        fistPunch.tag = "fistPunch";
                    }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameObject[] fist = GameObject.FindGameObjectsWithTag("fistPunch");
                for (int x = 0; x < fist.Length; x++)
                {
                    Destroy(fist[x]);
                }
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
}
