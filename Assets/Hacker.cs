using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "Options are Up, Down, Equal, or Restart";

    // Game state
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	int max = 1000;
	int min = 1;
	int guess = 500;

	// Use this for initialization
	void Start ()
    {
        ShowMainMenu ();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

		Terminal.WriteLine("Welcome to Number Wizard");
		Terminal.WriteLine("Pick a number in your head,");
		Terminal.WriteLine("but don't tell me!");
		
		Terminal.WriteLine("The highest number you can pick is " + max);
		Terminal.WriteLine("The lowest number you can pick is " + min);
		
		Terminal.WriteLine("Is the number higher or lower than " + guess + "?");
		Terminal.WriteLine("Up = higher, Down = lower,");
		Terminal.WriteLine("Equal = equal");
    }

    void OnUserInput(string input)
    {
        if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
		if (input == "Up" || input == "up") {
			min = guess;
			NextGuess();
        }
		else if (input == "Down" || input == "down") {
			max = guess;
			NextGuess();
        }
		else if (input == "Equal" || input == "equal") {
			Terminal.WriteLine("I won!");
			Terminal.WriteLine("Type Restart to play again.");
			//ShowMainMenu ();
        }
		else if (input == "Restart" || input == "restart") {
			ShowMainMenu ();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid option");
            Terminal.WriteLine(menuHint);
        }
    }
	void NextGuess () {
		guess = (max + min) / 2;
		Terminal.WriteLine("Higher or lower than " + guess);
		Terminal.WriteLine("Up = higher, Down = lower,");
		Terminal.WriteLine("Enter = equal");
	}

}
