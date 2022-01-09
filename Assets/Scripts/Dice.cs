using System.Collections;
using System.Collections.Generic;
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
                Debug.Log("First roll: " + firstRoll);
            }
            else
            {
                secondRoll = StoreRoll(rolledValue);
                Debug.Log("Second roll: " + secondRoll);
            }
            Debug.Log("rolled a " + rolledValue);
            totalRoll = totalRoll + rolledValue;
            Debug.Log("in total: " + totalRoll);
            randomDiceSide1 = 0;
        }

        if (firstRoll == secondRoll)
        {
            isDoubles = true;
            doublesCounter++;
            Debug.Log("Did you roll doubles to get a " + totalRoll + "? " + isDoubles);
            Debug.Log("How many doubles did you roll? " + doublesCounter);
        }
        isDoubles = false;

        GameControl.diceSideThrown = totalRoll;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        isDoubles = false;
        doublesCounter = 0;
        coroutineAllowed = true;
    }
}
