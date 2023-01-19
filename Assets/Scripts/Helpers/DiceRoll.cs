using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll
{
    int rolls;
    int sides;
    int modifier = 0;

    public DiceRoll(int rolls, int sides) {
        this.rolls = rolls;
        this.sides = sides;
    }

    public DiceRoll(int rolls, int sides, int modifier) {
        this.rolls = rolls;
        this.sides = sides;
        this.modifier = modifier;
    }

    public int Roll() {
        int result = modifier;
        for (int i = 0; i < rolls; i++) {
            result += Random.Range(1, sides);
        }
        return result;
    }

    public static int Roll(int rolls, int sides, int modifier = 0) {
        int result = modifier;
        for (int i = 0; i < rolls; i++) {
            result += Random.Range(1, sides);
        }
        return result;
    }


}
