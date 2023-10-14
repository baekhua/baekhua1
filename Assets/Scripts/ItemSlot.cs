using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    ItemData _itemData;
    Image _image;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Init(ItemData itemData, Sprite sprite)
    {
        _itemData = itemData;
        _image.sprite = sprite;
    }
}
