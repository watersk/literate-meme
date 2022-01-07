using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides1;
    private Sprite[] diceSides2;
    private SpriteRenderer rend1;
    private SpriteRenderer rend2;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Start is called before the first frame update
    private void Start()
    {
        rend1 = GetComponent<SpriteRenderer>();
        diceSides1 = Resources.LoadAll<Sprite>("Art/Dice");
        rend1.sprite = diceSides1[5];

        rend2 = GetComponent<SpriteRenderer>();
        diceSides2 = Resources.LoadAll<Sprite>("Art/Dice");
        rend2.sprite = diceSides2[5];
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide1 = 0;
        int randomDiceSide2 = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide1 = Random.Range(0, 6);
            randomDiceSide2 = Random.Range(0, 6);
            rend1.sprite = diceSides1[randomDiceSide1];
            rend2.sprite = diceSides2[randomDiceSide2];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = (randomDiceSide1 + randomDiceSide2) + 1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
