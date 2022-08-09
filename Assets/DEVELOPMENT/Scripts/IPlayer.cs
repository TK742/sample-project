using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public void AddToInventory(string item)
    {
        inventory.Add(item);
    }

    [System.Serializable] public class Inventory
    {
        public List<string> inventory;

        public bool Add(string item)
        {
            if (Find(item) != null) return false;
            inventory.Add(item);
            return true;
        }

        public bool Remove(string item)
        {
            if (Find(item) == null) return false;
            inventory.Remove(item);
            return true;
        }

        public string Find(string item) => inventory.Find(i => i == item);
    }
}
