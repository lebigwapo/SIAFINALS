using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats mystats;
    Transform target;
    CharacterCombat combat;

    void start()
    {
        target = PlayerManager.instance.player.transform;
        mystats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();
    }
    public override void Interact()
    {
        base.Interact();
        mystats = target.GetComponent<CharacterStats>();
        if (mystats != null)
        {
            combat.Attack(mystats);
        }

  
    }
}
