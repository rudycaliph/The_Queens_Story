using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 	{
	
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength;

	public int maxStamina = 100;
	public int curStamina = 100;
	public float staminaBarLength; 

	public int maxSpecial = 25;
	public int curSpecial = 0;
	public float specialBarLength;

	GUIStyle style = new GUIStyle();
	GUIStyle style2 = new GUIStyle();
	GUIStyle style3 = new GUIStyle();

	Texture2D texture;
	Texture2D texture2;
	Texture2D texture3;

	Color redColor = Color.red;
	Color greenColor = Color.green;
	Color blueColor = Color.blue;
	Color blackColor = Color.black;

	void Start()
	{
		texture = new Texture2D(1, 1);
		texture.SetPixel(1, 1, redColor);

		texture2 = new Texture2D(1, 1);
		texture2.SetPixel(1, 1, greenColor);

		texture3 = new Texture2D(1,1);
		texture3.SetPixel(1,1, blackColor);

		healthBarLength = (float)(Screen.width / 2.0);
		staminaBarLength = (float)(Screen.width / 2.0);
		specialBarLength = (float)(Screen.width / 2.0);
	}
	
	private void Update()
	{
	
		/*if (curHealth == 0)
		{

		}*/

		AddjustCurrentHealth(0);
		AddjustCurrentStamina(0);
		AddjustCurrentSpecial(0);
	}
	
	public void OnGUI()
	{

		texture.Apply();

		style.normal.background = texture;
		GUI.Box(new Rect(10, 10, healthBarLength,20), new GUIContent(""), style);

		texture2.Apply();

		style2.normal.background = texture2;
		GUI.Box(new Rect(10, 32,staminaBarLength, 20), new GUIContent(""), style2);

		texture3.Apply();
		
		style3.normal.background = texture3;
		GUI.Box(new Rect(10, 55, specialBarLength, 20), new GUIContent(""), style3);
	}

	public void AddjustCurrentHealth(int adj)
		
	{
		curHealth += adj;
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (float)(Screen.width / 2.0*curHealth/maxHealth);
	}

	public void AddjustCurrentStamina(int adj)
	{
		curStamina += adj;
		if(curStamina < 0)
			curStamina = 0;
		
		if(curStamina > maxStamina)
			curStamina = maxStamina;
		
		if (maxStamina < 1)
			maxStamina = 1;
		
		staminaBarLength = (float)(Screen.width / 2.0*curStamina/maxStamina);
	}

	public void AddjustCurrentSpecial(int adj)
	{
		curSpecial += adj;
		if(curSpecial < 0)
			curSpecial = 0;
		
		if(curSpecial > maxSpecial)
			curSpecial = maxSpecial;
		
		if (maxSpecial < 1)
			maxSpecial = 1;
		
		specialBarLength = (float)(Screen.width / 2.0*curSpecial/maxSpecial);
	}
}