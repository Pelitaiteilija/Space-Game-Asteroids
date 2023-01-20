using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DiceNotationEditorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void DiceNotationEditorTestsSimplePasses()
    {
        // Use the Assert class to test conditions
        DiceRoll result;

        // 1d6, 1d6+4, 2d6-2, 
        DiceNotation.ValidateStringAsDiceRoll("1d6", out result);
        CompareTwoDiceRolls(new DiceRoll(1,6) , result);
        DiceNotation.ValidateStringAsDiceRoll("1d6+4", out result);
        CompareTwoDiceRolls(new DiceRoll(1, 6, 4), result);
        DiceNotation.ValidateStringAsDiceRoll("2d6-2", out result);
        CompareTwoDiceRolls(new DiceRoll(2, 6, -2), result);

        // 3d6+10000, 10000d6-9999
        DiceNotation.ValidateStringAsDiceRoll("3d6+10000", out result);
        CompareTwoDiceRolls(new DiceRoll(3, 6, 10000), result);
        DiceNotation.ValidateStringAsDiceRoll("10000d6-9999", out result);
        CompareTwoDiceRolls(new DiceRoll(10000, 6, -9999), result);

        // 1000d1, 100d10, 10d10-1010
        DiceNotation.ValidateStringAsDiceRoll("1000d1", out result);
        CompareTwoDiceRolls(new DiceRoll(1000, 1), result);
        DiceNotation.ValidateStringAsDiceRoll("100d10", out result);
        CompareTwoDiceRolls(new DiceRoll(100, 10), result);
        DiceNotation.ValidateStringAsDiceRoll("10d10-1010", out result);
        CompareTwoDiceRolls(new DiceRoll(10, 10, -1010), result);
    }

    public void CompareTwoDiceRolls (DiceRoll a, DiceRoll b) {
        Assert.AreEqual(a.rolls, b.rolls);
        Assert.AreEqual(a.sides, b.sides);
        Assert.AreEqual(a.modifier, b.modifier);
    }
}
