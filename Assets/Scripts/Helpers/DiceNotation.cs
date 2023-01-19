using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;

public class DiceNotation {
    public List<DiceRoll> diceToRoll { get; private set; }
    public int modifier;

    public void AddOneDie() {
        diceToRoll.Add(new DiceRoll(1, 6));
    }

    public void AddOneDie(DiceRoll die) {
        diceToRoll.Add(die);
    }

    public int rollDice() {
        int result = 0;
        foreach (DiceRoll dice in diceToRoll) {
            result += dice.Roll();
        }
        return result + modifier;
    }

    public bool ValidateStringAsDiceRoll(string input) {
        return ValidateStringAsDiceRoll(input, out _); ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static bool ValidateStringAsDiceRoll(string input, out DiceRoll output) {
        if (input.Contains(' '))
            Debug.LogWarning($"DiceRoll input '{input}' contains empty spaces!");
        output = new DiceRoll(1, 1);
        //Regex regex = new Regex.Split("(+|-)");
        string[] components = Regex.Split(input, "(\\+|\\-)");
        Debug.Log($"DiceRoll input {input} was split into {components.ToString()}");


        return false;
    }

}