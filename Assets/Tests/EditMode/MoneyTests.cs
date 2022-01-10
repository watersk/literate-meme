using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;

public class MoneyTests
{
    [Test]
    public void InitializeBoard()
    {
        List<Property> board = Property.CreateBoard();
        Assert.AreEqual(40, board.Count);
    }
}
