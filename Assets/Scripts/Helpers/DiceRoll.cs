using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll
{
    public int rolls    { get; private set; }
    public int sides    { get; private set; }
    public int modifier { get; private set; }

    /// <summary>
    /// A number of dice to roll, for example 2d6 defines a roll where two 6-sided die are thrown.
    /// </summary>
    /// <param name="rolls">The amount of dice to be rolled, the 1 in 1d6+N</param>
    /// <param name="sides">The number of sides in a die, the 6 in 1d6+N</param>
    /// <param name="modifier">Additional modifier added to the result, the N in 1d6+N. Can be a negative number.</param>
    public DiceRoll(int rolls, int sides, int modifier = 0) {
        this.rolls = rolls;
        this.sides = sides;
        this.modifier = modifier;
    }

    /// <summary>
    /// Throw the dice defined by a DiceRoll object and return the sum of the result.
    /// If the modifier is negative, the result may be negative as well.
    /// </summary>
    /// <returns></returns>
    public int Roll() {
        // call the static Roll() function
        return Roll(rolls, sides, modifier);
    }

    /// <summary>
    /// Static function that returns the result of a diceroll with specific parameters
    /// If the modifier is negative, the result may be negative as well. 
    /// </summary>
    /// <param name="rolls"></param>
    /// <param name="sides"></param>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public static int Roll(int rolls, int sides, int modifier = 0) {
        int result = modifier;
        for (int i = 0; i < rolls; i++) {
            result += Random.Range(1, sides);
        }
        return result;
    }


}
