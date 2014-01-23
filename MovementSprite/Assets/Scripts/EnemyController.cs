using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    int maxWalkDist = 100;
    int curWalkDist = 0;
    public float speed = 4;
    float health = 200;

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
        if (col.tag == "fistPunch")
        {
            Debug.Log("hit");
            health -= 50;
        }
    }
}
