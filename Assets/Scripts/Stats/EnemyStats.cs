using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private GameObject Soul;
    [SerializeField] private bool CanDie = true;

    private GameObject GameManager;
    private EquipmentManager GameManagerComponent;
    private Vector3 SoulOffestSpawnPosition = new Vector3(0, 1.5f, 0);

    public override void Die()
    {
        if (CanDie == true)
        {
            if (GameManagerComponent.CurrentEquipment[3] != null)
                if (GameManagerComponent.CurrentEquipment[3].ID == "10")
                {
                    Instantiate(Soul, transform.position + SoulOffestSpawnPosition, Quaternion.identity);
                } //  Emitting Soul
            base.Die();
        
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager == null)
            Debug.LogWarning("No Game Manager at Scene");
        GameManagerComponent = GameManager.GetComponent<EquipmentManager>();
    } // Find Game Manager
}
