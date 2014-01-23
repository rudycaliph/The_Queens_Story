using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    bool isPrince = true;

	
	// Update is called once per frame
	void Update () {

        if (isPrince)
            GetComponent<MegaManController>().spriteRenderer.color = Color.red;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCharacter();
        }
	
	}

    private void SwitchCharacter()
    {

        GetComponent<MegaManController>().isSwitching = true;
        GetComponent<MegaManController>().anim.SetBool("isSwitching", true);
        
        if (isPrince)
        {
            GetComponent<MegaManController>().spriteRenderer.color = Color.blue;
            isPrince = false;
            GetComponent<MegaManController>().anim.SetTrigger("Switched");
            GetComponent<MegaManController>().rigidbody2D.AddForce(new Vector2(0, 800));
        }
        else
        {
            GetComponent<MegaManController>().spriteRenderer.color = Color.red;
            isPrince = true;
            GetComponent<MegaManController>().anim.SetTrigger("Switched");
            GetComponent<MegaManController>().rigidbody2D.AddForce(new Vector2(0, 800));
        }
        SwitchingAnim();
        
    }

    IEnumerator SwitchingAnim()
    {
        GetComponent<MegaManController>().isSwitching = false;
        GetComponent<MegaManController>().anim.SetBool("isSwitching", false);
        // Wait for 2 seconds.
        yield return new WaitForSeconds(2);
        
    }

}
