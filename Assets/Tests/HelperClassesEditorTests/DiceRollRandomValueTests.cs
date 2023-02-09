using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DiceRollRandomValueTests
{
    [Test]
    public void DiceRollRandomValueTestCases()
    {
        CheckDiceValueRange(new DiceRoll(1, 2, 0), 1, 2);
        CheckDiceValueRange(new DiceRoll(2, 2, 0), 2, 4);
        CheckDiceValueRange(new DiceRoll(1, 6, 0), 1, 6);
        CheckDiceValueRange(new DiceRoll(2, 6, 0), 2, 12);
        CheckDiceValueRange(new DiceRoll(1, 2, 10), 11, 12);
        CheckDiceValueRange(new DiceRoll(20, 6, -10), 10, 110);

        CheckDiceResultVariation(new DiceRoll(1, 2, 0));
        CheckDiceResultVariation(new DiceRoll(1, 2, 10));
        CheckDiceResultVariation(new DiceRoll(1, 2, -100));
        CheckDiceResultVariation(new DiceRoll(2, 2, 0));
        CheckDiceResultVariation(new DiceRoll(3, 2, 0));
        CheckDiceResultVariation(new DiceRoll(3, 2, 5));
        CheckDiceResultVariation(new DiceRoll(10, 2, 100));
        CheckDiceResultVariation(new DiceRoll(3, 10, 0));
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

        // create a new empty int[] array where occurences of each possible diceroll result will be recorded
        int[] resultArray = new int[roll.rolls * roll.sides + 1 - roll.rolls];
        // value of a given roll
        int rollValue;

        // possible result:
        // 1d6 can have results 1, 2, 3, 4, 5, 6 so 6 possible results
        // 2d2 can have results 11, 12, 22, so 3 possible results
        // 3d2 can have results 111, 112, 122, 222 so 4 possible results
        // 4d3 can have results 111, 112, 113, 122, 123, 222, 223, 233, 333 so 9 possible results

        // choose how often to repeat the calculation, increase repeats exponentially for 
        // dicerolls with more dice or more sides
        int repeats = Mathf.Min(
                        roll.rolls * roll.rolls * 25 * roll.sides * roll.sides,
                        50000);
        // roll the dice, and increment the result's position in resultArray by 1
        for (int i = 0; i < repeats; i++)
        {
            rollValue = roll.Roll();
            resultArray[FindResultArrayPosition(roll, rollValue)]++;
        }

        DrawResultGraph(roll, repeats, resultArray);

        for (int i = 0; i < resultArray.Length; i++)
        {
            Assert.Greater(resultArray[i], 0);
        }


    }

    /// <summary>
    /// Finds the given result's position in the result array
    /// </summary>
    /// <param name="roll"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    private int FindResultArrayPosition(DiceRoll roll, int result)
    {
        // The position in array is calculated with RESULT - ROLLS - MODIFIER
        // examples: 
        //                   2d2  | 2d2+4 | 1d6       | 1d6-2
        // result             3   |   8   |  1        |  -1
        // rolls              2   |   2   |  1        |   1
        // modifier           0   |   4   |  0        |  -2
        // --------------------------------------------------
        //                    1   |   2   |  0        |   0
        // possible results  234  | 678   |  123456   |  -101234

        // Uncomment to test, NOTE: outputs over 15k characters...
        // Debug.Log($"Finding array position for value {result} in {roll.rolls}d{roll.sides}+{roll.modifier}, should be {result - roll.rolls - roll.modifier}");
        return result - roll.rolls - roll.modifier;
    }

    /// <summary>
    /// Draws a row of ten characters representing how often a specific result occurs in the array
    /// 
    /// </summary>
    /// <param name="occurences"></param>
    /// <param name="highestOccurence"></param>
    /// <returns></returns>
    private string DrawGraphRow(int occurences, int highestOccurence)
    {
        string returnValue = "";
        // converts value to ratio, where the highest occurence is always 50% of the row width
        int ratio = (int)Mathf.Ceil(
            (float)occurences / highestOccurence * 9.1f
            );
        returnValue = "".PadLeft(ratio, '#') + "".PadLeft(10 - ratio, '_');

        return returnValue;
    }

    /// <summary>
    /// Draw an ASCII graph to Debug.Log() using the following format:
    /// <code>
    /// Testing array 2d2+0 with 400 rolls:
    /// Drawing result graph... (works best in monospace)
    ///    2: #####_____ | 102
    ///    3: ########## | 215
    ///    4: ####______ | 83
    /// </code>
    /// </summary>
    /// <param name="roll"></param>
    /// <param name="repeats"></param>
    /// <param name="resultArray"></param>
    private void DrawResultGraph(DiceRoll roll, int repeats, int[] resultArray)
    {

        string values = $"Testing array {roll.rolls}d{roll.sides}+{roll.modifier} with {repeats} rolls:\nDrawing result graph... (works best in monospace)\n\n";
        for (int i = 0; i < resultArray.Length; i++)
        {

            // the prefix tells which result's occurence is measured, in the format '   6: '
            // the graph row is in the format '#####_____'
            // the end of the row is in the format '| 12' and lists the number of occurences as an int
            string prefix = (i + roll.rolls + roll.modifier).ToString().PadLeft(4, ' ');

            values += $"{prefix}: {DrawGraphRow(resultArray[i], resultArray.Max())} | {resultArray[i]}\n";
        }
        Debug.Log(values);
    }
}
