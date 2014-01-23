using UnityEngine;
using System.Collections;


public class OniController : MonoBehaviour {


	public KeyCode right;
	public KeyCode left;
	public KeyCode space;
    public KeyCode up;
    
    //public Animation jumpPlz;

    public float keyDelay = 1f;  // 1 second

    private float timePassed = 0f;

    Animator anim;

	Vector3 rightVec;
	Vector3 leftVec;

	float speed = 5;
	int counter = 0;
	int charMapNum = 0;
    //float time = Time.deltaTime;
    int shootTime = 0;

    bool isFacingLeft = false;
    bool characterStandingStill = true;
    bool shooting = false;
    public bool jumping = false;
	
	public Sprite[] sprites;

	private SpriteRenderer spriteRenderer;

   

	// Use this for initialization
	void Start () {

        anim = (Animator)gameObject.GetComponentInChildren<Animator>();
		spriteRenderer = renderer as SpriteRenderer;
	}


	
	// Update is called once per frame
    void Update()
    {
        anim.SetFloat("jump", rigidbody2D.velocity.y);
        timePassed += Time.deltaTime;
        if (Input.GetKey(left) && !isFacingLeft)
        {
            FlipLeft();
        }
        else if (Input.GetKey(right) && isFacingLeft)
        {
            FlipLeft();
        }
        if (Input.GetKeyUp(left))
        {
            anim.SetBool("isRunning", false);
            rightVec.x = 0;
            rigidbody2D.velocity = rightVec;
        }
        if (Input.GetKeyUp(right))
        {
            anim.SetBool("isRunning", false);
            rightVec.x = 0;
            rigidbody2D.velocity = rightVec;
        }
        if (Input.GetKeyUp(space))
        {
            anim.SetBool("isShooting", false);
            characterStandingStill = true;
            charMapNum = 0;
        }
        if (Input.GetKeyUp(up))
        {
            anim.SetBool("isJumping", false);
            rightVec.y = 0;
            rigidbody2D.velocity = rightVec;
        }
        if (Input.GetKey(right))
        {
            //characterStandingStill = false;
            anim.SetBool("isRunning", true);


            rightVec = rigidbody2D.velocity;
            rightVec.x = speed;
            rigidbody2D.velocity = rightVec;
            if (Input.GetKey(up)){
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", true);
            jumpKey();
            }

        }
        else if (Input.GetKey(left))
        {
            //characterStandingStill = false;
            anim.SetBool("isRunning", true);

            leftVec = rigidbody2D.velocity;
            leftVec.x = speed * -1;
            rigidbody2D.velocity = leftVec;
            if (Input.GetKey(up))
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", true);
                jumpKey();
            }

        }
        else
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isShooting", true);

            }
            else if (Input.GetKeyDown(up))
            {
                anim.SetBool("isJumping", true);
                jumpKey();
            }
            //else
            //    if (Input.GetKey(right) && (Input.GetKey(up)))
            //    {

            //        anim.SetBool("isJumping", true);
            //        rightVec = rigidbody2D.velocity;
            //        rightVec.x = speed;
            //        rigidbody2D.velocity = rightVec;
            //        jumpKey();

            //    }


    }

    private void jumpKey()
    {
        
        rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, speed * 200f));
        //anim.SetFloat("jump", rigidbody2D.velocity.y);
    }


    private void FlipLeft()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
    }

}
//public class Player : OniController
//{
//    int health;
//    int mana;
//    int spPwr;
//    int comboCount;
//    int currExp;
//    int lvl;

//    public Player(int mana, int health, int spPwr, int comboCount, int currExp, int lvl)
//    {
//        this.mana = mana;
//        this.health = health;
//        this.spPwr = spPwr;
//        this.comboCount = comboCount;
//        this.currExp = currExp;
//        this.lvl = lvl;
//    }

//    public void Move(Input key)
//    {
//        if (Input.GetKey(right))
//        {
//            //characterStandingStill = false;
//            anim.SetBool("isRunning", true);


//            rightVec = rigidbody2D.velocity;
//            rightVec.x = speed;
//            rigidbody2D.velocity = rightVec;
//            if (Input.GetKey(up))
//            {
//                anim.SetBool("isRunning", false);
//                anim.SetBool("isJumping", true);
//                jumpKey();
//            }

//        }
//        else if (Input.GetKey(left))
//        {
//            //characterStandingStill = false;
//            anim.SetBool("isRunning", true);

//            leftVec = rigidbody2D.velocity;
//            leftVec.x = speed * -1;
//            rigidbody2D.velocity = leftVec;
//            if (Input.GetKey(up))
//            {
//                anim.SetBool("isRunning", false);
//                anim.SetBool("isJumping", true);
//                jumpKey();
//            }

//        }
//        else
//            if (Input.GetKey(KeyCode.Space))
//            {
//                anim.SetBool("isShooting", true);

//            }
//            else if (Input.GetKeyDown(up))
//            {
//                anim.SetBool("isJumping", true);
//                jumpKey();
//            }

//    }

//    public void Jump()
//    {

//    }

//    public void Attack()
//    {

//    }

//    public void spAttack()
//    {

//    }

//}