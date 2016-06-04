using UnityEngine;
using System.Collections;

public enum ItemTypes {MANA,HEALTH};

public class Item : MonoBehaviour {

    public ItemTypes type;

    public Sprite spriteNeutral;

    public Sprite spriteHighlighted;

    public int maxSize;

	public void Use()
    {
        switch(type)
        {
            
            case ItemTypes.MANA:
                Debug.Log("I just used a mana potion");
                break;
            case ItemTypes.HEALTH:
                Debug.Log("I just used a health potion");
                break;

        }
    }
}
