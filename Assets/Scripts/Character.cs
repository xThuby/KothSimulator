
using UnityEngine;

public class Character : MonoBehaviour
{
    public StatBlock StatBlock;
    public int DieCount;

    public bool Attack(Character target, bool isMagic = false)
    {
        if (DieCount < 1)
        {
            Debug.LogError($"{DieCount} cannot be lower than 1");
            return false;
        }

        int critCount = 0;
        int sum = 0;
        for (int i = 0; i < DieCount; i++)
        {
            int roll = Random.Range(1, 6);
            if (roll == 6) critCount++;
            sum += roll;
        }

        int enemyDef = isMagic ? target.StatBlock.SpellDefense : target.StatBlock.Defense;
        if (sum < enemyDef)
            return false;

        float dmgMult = 1;

        if (sum == enemyDef)
            dmgMult = 0.5f;
        if (critCount >= 2)
            dmgMult = 1.5f;

        int dmg = isMagic ? StatBlock.SpellAttack : StatBlock.Attack;

        target.DealDamage(Mathf.RoundToInt(dmg * dmgMult));

        return true;
    }

    public void DealDamage(int dmg)
    {
        StatBlock.CurrentHP = Mathf.Max(StatBlock.CurrentHP - dmg, 0);
    }
}
