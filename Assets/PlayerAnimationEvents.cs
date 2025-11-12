using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    public void AttackEnemies() => player.AttackEnemy();
    private void EnableMoveAndJump() => player.EnableMoveAndJump(true);
    private void DisableMoveAndJump() => player.EnableMoveAndJump(false);
}
