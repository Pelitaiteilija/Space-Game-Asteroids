public interface IHaveStats
{
    int attackPower { get; }
    float attackSpeed { get; }
    int hullPoints { get; }
    float movementMultiplier { get; }
    float rotationMultiplier { get; }

    void ChangeStat(Stats targetStat, float amount);
    void ReplaceStat(Stats targetStat, float amount);
}

public enum Stats
{
    attackPower, 
    attackSpeed,
    hullPoints,
    movement,
    rotation
}
