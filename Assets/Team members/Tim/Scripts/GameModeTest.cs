using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeTest : GameModeBase
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("TestGameMode active");
    }
}
