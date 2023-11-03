using System.Collections;
using System.Collections.Generic;
using System;
public static class Playerdata
{
    public static float Health = 100;
    private static float maxHealth = 100;

    public static float MaxHealth { get => maxHealth; set => maxHealth = value; }
}
