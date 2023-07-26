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
                // ���� �������� �÷��̾��� ���� ���Կ� �߰��ϰų� �����ϴ� ���� ����
                tempImg.sprite = _sprites[0];
                break;

            case ItemType.Food:
                // ���� �������� �÷��̾��� ü���� ȸ����Ű�� ���� ����
                tempImg.sprite = _sprites[1];
                break;

            case ItemType.Cloth:
                // �Ƿ� �������� �÷��̾��� ������ �����ϴ� ���� ����
                tempImg.sprite = _sprites[2];
                break;
            case ItemType.Medicine:
                // �Ǿ�ǰ �������� �÷��̾��� ü���̳� ���¸� �����ϴ� ���� ����
                tempImg.sprite = _sprites[3];
                break;

            case ItemType.Other:
                // ��Ÿ ������
                tempImg.sprite = _sprites[4];
                break;

            default:
                // �� �� ���� Ÿ���� ������
                break;
        }
    }
}
