using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _UIItems;
    [SerializeField] Transform _content;

    public void AddItem(ItemData data)
    {
        GameObject temp = Instantiate(_UIItems, _content);
        if(data._type == ItemType.Weapon)
        {

        }
        else if(data._type == ItemType.Food)
        {

        }
        else if(data._type == ItemType.Cloth)
        {

        }
        else if(data._type == ItemType.Medicine)
        {

        }
        else if(data._type == ItemType.Consumable)
        {

        }
    }
}
