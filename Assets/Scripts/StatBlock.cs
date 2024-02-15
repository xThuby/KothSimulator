
public class StatBlock
{
    public readonly int Attack;
    public readonly int Defense;
    public readonly int SpellAttack;
    public readonly int SpellDefense;
    public readonly int BaseHP;
    public int CurrentHP;

    public StatBlock(int atk, int def, int spAtk, int spDef, int hp)
    {
        Attack = atk;
        Defense = def;
        SpellAttack = spAtk;
        SpellDefense = spDef;
        BaseHP = CurrentHP = hp;
    }
}
