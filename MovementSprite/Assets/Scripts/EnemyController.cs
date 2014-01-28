using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    int maxWalkDist = 100;
    int curWalkDist = 0;
    public float speed = 4;
    float health = 200;
    Vector3 moveEnemy;
    public bool canBeHit = true;

    public GameObject coin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 moveEnemy = rigidbody2D.velocity;
        

        moveEnemy.x = speed;
        rigidbody2D.velocity = moveEnemy;

        curWalkDist++;

        if (curWalkDist == maxWalkDist)
        {
            Flip();
            curWalkDist = 0;
        }

        Debug.Log(health);

        if (health <= 0)
        {
           // Instantiate(coin, (rigidbody2D.transform.position.x, rigidbody2D.transform.position.y), Quaternion.identity) as GameObject).transform)
            Instantiate(coin, new Vector2(rigidbody2D.transform.position.x, rigidbody2D.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
            
        }
	
	}

    void Flip()
    {
        

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        speed *= -1;
        transform.localScale = theScale;
    }

    

    void OnTriggerEnter2D (Collider2D col) 
    {
        if (col.tag == "fistPunch" && canBeHit)
        {
            Debug.Log("hit");
            
            moveEnemy.x *= speed;
            rigidbody2D.velocity = moveEnemy;
            health -= 50;
        }
    }
}
