using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
    public GUISkin guiSkin;
    public Texture2D background;
    public bool DragWindow = false;
    //public string levelToLoadWhenClickedPlay = "";
    public string[] InstructionsTextLines = new string[0];

    private string clicked = "", MessageDisplayOnInstructions = "In-Game Player Controls \n ";
    private Rect WindowRect = new Rect((Screen.width / 2) - 200, Screen.height / 4, 325, 325);

	private bool render = true;
	
    private void Start()
    {
        for (int x = 0; x < InstructionsTextLines.Length;x++ )
        {
            MessageDisplayOnInstructions += InstructionsTextLines[x] + " \n ";
        }
		MessageDisplayOnInstructions += "\n\n Movement Keys: \n\n Up Arrow Key: Jump \n Left Arrow Key: Move Left \n Right Arrow Key: Move Right \n\n Combat Controls: \n\n Space Bar: Attack Enemies\n Shift Button: Use Special Attack\nQ Button: Switch Between Characters \n\n General Controls: \n\n ESC Button: Pause Button";
    }

    private void OnGUI()
    {
		if(render)
		{
		    if (background != null)
            GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
        
        	GUI.skin = guiSkin;
        	if (clicked == "")
        	{
            	WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
      	    }
       
        	else if (clicked == "instructions")
     	    {
				WindowRect = GUI.Window(0,WindowRect, instructionsFunc, MessageDisplayOnInstructions);
        	}
		}
    }

	void ToggleWindow()
	{
		render = !render;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ToggleWindow ();
		}
	}
    private void menuFunc(int id)
    {
        //buttons 
        if (GUILayout.Button("Play Game"))
        {
           // Application.LoadLevel(levelToLoadWhenClickedPlay);
			ToggleWindow ();
        }

        if (GUILayout.Button("Instructions"))
        {
            clicked = "instructions";
        }
        if(GUILayout.Button("Quit Game"))
        {
			Application.Quit();
        }
        if (DragWindow)
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
    }

	private void instructionsFunc(int id)
	{
		if (GUILayout.Button("Back"))
		{
			clicked = "";
		}
	}
}
