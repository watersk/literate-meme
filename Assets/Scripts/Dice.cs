using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Sprite[] diceSides1;
    public static Sprite[] diceSides2;
    public static SpriteRenderer rend1;
    public static SpriteRenderer rend2;
    public static int whosTurn = 1;
    private bool coroutineAllowed = true;
    public static bool isDoubles = false;
    public static int doublesCounter = 0;

    internal static Player Player1 { get; set; } = Player.CreatePlayer();
    internal static Player Player2 { get; set; } = Player.CreatePlayer();

    List<Property> board = Property.CreateBoard();

    // Start is called before the first frame update
    private void Start()
    {
        rend1 = GetComponent<SpriteRenderer>();
        diceSides1 = Resources.LoadAll<Sprite>("DiceSides/");
        rend1.sprite = diceSides1[diceSides1.Length - 1];
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    public int StoreRoll (int roll)
    {
        return roll;
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide1 = 0;
        int firstRoll = 0;
        int secondRoll = 0;
        int totalRoll = 0;
        int rolledValue = 0;
        for (int x = 0; x <=1; x++)
        {
            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide1 = Random.Range(0, 6);
                rend1.sprite = diceSides1[randomDiceSide1];
                yield return new WaitForSeconds(0.05f);
            }

            rolledValue = randomDiceSide1 + 1;
            if(x == 0)
            {
                firstRoll = StoreRoll(rolledValue);
            }
            else
            {
                secondRoll = StoreRoll(rolledValue);
            }
            totalRoll = totalRoll + rolledValue;
            randomDiceSide1 = 0;
        }

        Debug.Log("First roll: " + firstRoll);
        Debug.Log("Second roll: " + secondRoll);
        Debug.Log("in total: " + totalRoll);

        if (firstRoll == secondRoll)
        {
            isDoubles = true;
            doublesCounter++;
            Debug.Log("Did you roll doubles to get a " + totalRoll + "? " + isDoubles);
            Debug.Log("How many doubles did you roll? " + doublesCounter);
        }
        isDoubles = false;

        GameControl.diceSideThrown = totalRoll;

        List<Property> board = Property.CreateBoard();

        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
            Player.PurchaseProperty(
                Player1, 
                board[board.FindIndex(p => p.Name.Equals(Player1.CurrentLocation.Name)) + totalRoll]);
            Debug.Log("Money after purchase: " + Player1.Money);
            Debug.Log("Player 1 is currently on: " + Player1.CurrentLocation.Name);
            foreach(var prop in Player1.OwnedProperties)
            {
                Debug.Log("Player 1 owns: " + prop.Name);
            }
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
            Player.PurchaseProperty(
                Player2,
                board[board.FindIndex(p => p.Name.Equals(Player2.CurrentLocation.Name)) + totalRoll]);
            Debug.Log("Money after purchase: " + Player2.Money);
            Debug.Log("Player 2 is currently on: " + Player2.CurrentLocation.Name);
            foreach (var prop in Player2.OwnedProperties)
            {
                Debug.Log("Player 2 owns: " + prop.Name);
            }
        }
        whosTurn *= -1;
        isDoubles = false;
        doublesCounter = 0;
        coroutineAllowed = true;
    }
}
