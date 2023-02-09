using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Test that dice notation formats are read correctly
/// </summary>
public class DiceNotationFormatComprehensionTests
{
    [Test]
    public void DiceNotationTests_FormatcomprehensionTestCases()
    {
        Debug.Log("<color=yellow>Testing dice notation format comprehension, i.e. if the text '2d6-5' is interpreted as a correct DiceRoll</color>\n");
        // Use the Assert class to test conditions
        DiceRoll result;

        // 1d6, 1d6+4, 2d6-2, 
        DiceNotation.ValidateStringAsDiceRoll("1d6", out result);
        CompareTwoDiceRolls(new DiceRoll(1, 6), result);
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

        Debug.Log("<color=#33FF99>Dice notation format tests were passed successfully.</color>\n");
    }

    public void CompareTwoDiceRolls(DiceRoll a, DiceRoll b)
    {
        Assert.AreEqual(a.rolls, b.rolls);
        Assert.AreEqual(a.sides, b.sides);
        Assert.AreEqual(a.modifier, b.modifier);
    }

    public void CheckDiceValueRange(DiceRoll roll, int minimum, int maximum)
    {
        int rollValue;
        for (int i = 0; i < 100; i++)
        {
            rollValue = roll.Roll();
            Assert.GreaterOrEqual(rollValue, minimum);
            Assert.LessOrEqual(rollValue, maximum);
        }
    }

    public void CheckDiceResultVariation(DiceRoll roll)
    {
        int[] resultArray = new int[roll.rolls * roll.sides];
        int rollValue;
        // repeat 100 to 5000 times
        int repeats = Mathf.Min(
                        Mathf.Max(
                            100,
                            roll.rolls * 50),
                        5000);
        for (int i = 0; i < 100; i++)
        {
            rollValue = roll.Roll();
            resultArray[FindResultArrayPosition(roll, rollValue)]++;
        }
        Debug.Log(resultArray);

        foreach (int value in resultArray)
        {
            Assert.Greater(value, 0);
        }
    }

    public int FindResultArrayPosition(DiceRoll roll, int result)
    {
        int maximumPossiblevalue = roll.rolls * roll.sides + roll.modifier;
        return maximumPossiblevalue - result;
    }

}
