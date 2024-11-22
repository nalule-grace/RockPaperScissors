using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
   //enum for player and computer choices
    public enum choice{Rock, Paper, Scissors}


    private choice playerChoice;
    private choice computerChoice;

    //scores
    private int playerScore;
    private int computerScore;

    //UI Elements
    public TextMeshProUGUI Display;
    public TextMeshProUGUI Player;
    public TextMeshProUGUI computer;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI computerText;
    public Button rock;
    public Button paper;
    public Button scissor;
    public Button shoot;
    public Button Replay;

    //image components
    public Image computerChoiceImage;
    public Image playerChoiceImage;

    //sprites for choices
    public Sprite RockSprite;
    public Sprite PaperSprite;
    public Sprite ScissorsSprite;


    //Method to set the player's choice
    public void SetChoice(int selectedChoice)
    {
        playerChoice = (choice)selectedChoice;
        UpdateChoiceImage(playerChoiceImage, playerChoice );

       playerChoiceImage.enabled = true;
        
    }


    //get player choice by keyboard input
    public void GetKey()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetChoice((int)choice.Rock);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            SetChoice((int)choice.Paper);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetChoice((int)choice.Scissors);
        }
    }


    //Method to generate the computer's choice
    private void Generatechoice()
    {
        computerChoice = (choice)Random.Range(0, 3);
        UpdateChoiceImage(computerChoiceImage, computerChoice );

        computerChoiceImage.enabled =true;
    }

    
 // Update the choice image
    private void UpdateChoiceImage(Image imageComponent, choice choice)
    {
        switch (choice)
        {
            case choice.Rock:
                imageComponent.sprite = RockSprite;
                break;
            case choice.Paper:
                imageComponent.sprite = PaperSprite;
                break;
            case choice.Scissors:
                imageComponent.sprite = ScissorsSprite;
                break;
        }
    }


    //determine winner
    public void whoWins()
    {
        
        Generatechoice();
        if(playerChoice == computerChoice)
        {
                Display.text = "Its a draw!";
                  
        }
        else if((playerChoice ==choice.Rock && computerChoice ==choice.Scissors)||
            (playerChoice ==choice.Paper && computerChoice ==choice.Rock)||
            (playerChoice ==choice.Scissors && computerChoice ==choice.Paper)){
                Display.text = "You Win!";
                playerScore++;
        }
         else
         {
            
             Display.text = "Computer Wins!";
             computerScore++;
         }  
         UpdateScoreUI();
        ToggleButtons(false); //disable buttons for the new round
        Replay.interactable = true; 
    } 


    //Update score UI
    private void UpdateScoreUI()
    {
        playerText.text = "Player Score: " + playerScore.ToString();
        computerText.text = "Computer Score: "+ computerScore.ToString();
    }
    
       

    //replay the game and reset UI
    public void ReplayGame()
    {
        ResetUI();
        ToggleButtons(true);

       
        
    }
    //reset UI elements to default
    private void ResetUI()
    {
        Display.text = "Click to play!";
        Player.text ="your choice: ";
        computer.text="Computer's choice: ";
        playerChoiceImage.sprite = null;
        computerChoiceImage.sprite = null;
        playerChoiceImage.enabled = false;
        computerChoiceImage.enabled =false;
    }
    //  toggle interactivity
    private void ToggleButtons(bool state)
    {
        rock.interactable = state;
        paper.interactable =state;
        scissor.interactable=state;
        shoot.interactable =state;
    }




    // Start is called before the first frame update
    void Start()
    {
       playerChoiceImage.enabled = false;
       computerChoiceImage.enabled =false;
        ResetUI();
        Replay.interactable =false;
        ToggleButtons(true);
      
    }


  

    void Update()
    {
        GetKey();
    }
}

