using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceNotation {
    [SerializeField]
    public string diceRoll = "1d6";
    public DiceRoll diceToRoll { get; private set; }

    public int rollDice() {
        int result = 0;
        result = diceToRoll.Roll();
        return result;
    }

    public static bool ValidateStringAsDiceRoll(string input) {
        return ValidateStringAsDiceRoll(input, out _); ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static bool ValidateStringAsDiceRoll(string input, out DiceRoll output) {
        output = new DiceRoll(1, 10);
        int rolls = 1, sides = 0, modifier = 0;

        bool modifierIsNegative = false;

        if (input == "" || input == null) {
            //Debug.LogWarning("DiceNotation received empty string");
            return false;
        }
        // example inputs: 1d6, 1d12, 2d6, 12d6, 1d6+10, 1d6-10, 
        if (Regex.IsMatch(input, "[dD]")) {
            if (input.Contains('-')) 
                modifierIsNegative = true;
            string[] components = Regex.Split(input, "[dD+-]");

            if (int.TryParse(components[0], out rolls) &&
                int.TryParse(components[1], out sides)) {
                // if there's a modifier (third component
                if (components.Length > 2) {
                    // if tryparse fails, return false
                    if (!int.TryParse(components[2], out modifier)) {
                        //Debug.LogWarning($"DiceNotation received string with flawed modifier: {input}");
                        return false;
                    }
                }
            }
            else {
                //Debug.LogWarning($"DiceNotation received flawed string: {input}");
                return false;
            }

        }
        // input didn't include [dD] chars
        // example inputs: 10, -10
        else {
            // TODO: Implement integer 
            //Debug.LogError("Non-random 'dice' (non-random variables) not implemented yet!");
            if (int.TryParse(input, out modifier)) {
            }
            else {
                //Debug.LogWarning($"DiceNotation received flawed string: {input}");
                return false;
            }
        }
        //Debug.Log($"output successful: {rolls}d{sides}+ {modifier}");
        if (modifierIsNegative)
            modifier *= -1;
        output = new DiceRoll(rolls, sides, modifier);
        return true;
    }

    public static string GetValueRange(string input) {
        DiceRoll die;
        if (ValidateStringAsDiceRoll(input, out die))
            return die.GetValueRange();

        return "error";
    }

}