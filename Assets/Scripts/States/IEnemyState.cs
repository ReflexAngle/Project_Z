using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public interface IEnemyState
{
    void Enter(isEnemy enemy);
    void Execute(isEnemy enemy);
    void Exit(isEnemy enemy);

}
