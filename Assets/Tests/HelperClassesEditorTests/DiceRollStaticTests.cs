using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DiceRollTests {
    // A Test behaves as an ordinary method
    [Test]
    public void DiceRollTests_StaticRolls_SimplePasses() {
        Debug.Log("Dice tests started");
        for (int i = 0; i < 100; i++) {
            int result = -1;
            // test simplest case
            // 1d1
            Assert.AreEqual(1, DiceRoll.Roll(1, 1));

            // test 'manually' that results can't be too big (in case function isn't correct
            // 1d2
            result = DiceRoll.Roll(1, 2);
            Assert.LessOrEqual(result, 2);
            // 1d6
            result = DiceRoll.Roll(1, 6);
            Assert.LessOrEqual(result, 6);

            // use functions to test different max roll results
            TestRoll(2);
            TestRoll(6);
            TestRoll(10);
            TestRoll(100);

            // with modifier
            // 1d1+9
            Assert.AreEqual(10, DiceRoll.Roll(1, 1, 9));
            // 1d6+4
            result = DiceRoll.Roll(1, 6, 4);
            Assert.GreaterOrEqual(result, 5);
            Assert.LessOrEqual(result, 10);

            //1d1-1, 1d1+10, 1d1-10, 1d1+10000, 1d1-10000
            TestRollWithModifier(1, -1);
            TestRollWithModifier(1, 10);
            TestRollWithModifier(1, -10000);
            TestRollWithModifier(1, -10000);
            // 1d4+16, 1d4-16
            TestRollWithModifier(4, 16);
            TestRollWithModifier(4, -16);

            // multiple dice
            // 2d1, 10d1, 50d1
            TestRollWithMultiples(2, 1, 0);
            TestRollWithMultiples(10, 1, 0);
            TestRollWithMultiples(50, 1, 0);
            //10d2, 10d3, 10d4
            TestRollWithMultiples(10, 2, 0);
            TestRollWithMultiples(10, 3, 0);
            TestRollWithMultiples(10, 4, 0);
        }
        Debug.Log("Dice tests done");
    }

    public void TestRoll(int maxValue) {
        int result = DiceRoll.Roll(1, maxValue);
        Assert.GreaterOrEqual(result, 1);
        Assert.LessOrEqual(result, maxValue);
    }

    public void TestRollWithModifier(int maxValue, int modifier) {
        int result = DiceRoll.Roll(1, maxValue, modifier);
        Assert.GreaterOrEqual(result, 1 + modifier);
        Assert.LessOrEqual(result, maxValue + modifier);
    }

    public void TestRollWithMultiples(int rolls, int sides, int modifier) {
        int result = DiceRoll.Roll(rolls, sides, modifier);
        Assert.GreaterOrEqual(result, rolls + modifier);
        Assert.LessOrEqual(result, (rolls*sides) + modifier);
    }

}
