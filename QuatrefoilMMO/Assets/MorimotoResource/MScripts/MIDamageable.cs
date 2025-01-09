using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamageable
{
    public void Recovery(int value);

    public void Damage(int value);
    public void Death();
}
