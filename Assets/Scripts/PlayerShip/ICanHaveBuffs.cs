using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICanHaveBuffs : IHaveStats
{
    List<string> attackPowerBuffs { get; }
    List<string> attackSpeedBuffs { get; }
    List<string> hullPointsBuffs { get; }
    List<string> movementBuffs { get; }
    List<string> rotationBuffs { get; }

    void updateBuffs();
    void addBuff(Stats buffedStat, string buff);
    void clearBuffs();
}
