using UnityEngine;
using UnityEngine.UI;

public class Inventory : GenericSingleton<Inventory>
{
    [SerializeField] GameObject _UIItems;
    [SerializeField] Transform _content;
    [SerializeField] Sprite[] _sprites;

    public void AddItem(ItemData data)
    {
        GameObject temp = Instantiate(_UIItems, _content);
        Image tempImg = temp.GetComponentsInChildren<Image>()[0];
        switch (data._type)
        {
            case ItemType.Weapon:
                // 무기 아이템을 플레이어의 무기 슬롯에 추가하거나 장착하는 동작 수행
                tempImg.sprite = _sprites[0];
                break;

            case ItemType.Food:
                // 음식 아이템을 플레이어의 체력을 회복시키는 동작 수행
                tempImg.sprite = _sprites[1];
                break;

            case ItemType.Cloth:
                // 의류 아이템을 플레이어의 외형을 변경하는 동작 수행
                tempImg.sprite = _sprites[2];
                break;
            case ItemType.Medicine:
                // 의약품 아이템을 플레이어의 체력이나 상태를 변경하는 동작 수행
                tempImg.sprite = _sprites[3];
                break;

            case ItemType.Other:
                // 기타 아이템
                tempImg.sprite = _sprites[4];
                break;

            default:
                // 알 수 없는 타입의 아이템
                break;
        }
    }
}
