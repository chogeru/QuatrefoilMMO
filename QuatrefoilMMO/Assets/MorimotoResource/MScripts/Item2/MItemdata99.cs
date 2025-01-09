using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MItemdata99
{
    public MItemSourceData data;
    public int count;

    public void Add(int addnum)
    {
        count = Mathf.Min(count + addnum, 99);
    }

    public void Use()
    {
        count--;
        UseItem();
    }

    private void UseItem()
    {
        if (data == null) return;
        switch (data.GetEffectType)
        {
            case ItemEffectType.RecoveryHP:
                UseRecoveryHP();
                break;

        }
    }

    private void UseRecoveryHP()
    {
        MPlayerControllerFencer.Recovery(data.GetHP);
    }
}
