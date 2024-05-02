using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType charType;

    private enum CharacterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList(); ;
    }

    private void Start()
    {
        ChangeOutfit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            charType = charType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOutfit();
        }
    }

    void ChangeOutfit()
    {
        foreach(SpriteResolver resolver in resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());
        }
    }
}
