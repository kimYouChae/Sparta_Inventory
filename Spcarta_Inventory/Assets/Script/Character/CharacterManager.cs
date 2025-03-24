using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // ΩÃ±€≈Ê
    // ΩÃ±€≈Ê
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            return instance;
        }
    }


    [Header("===State===")]
    [SerializeField] private Character character;
    public Character Character { get => character; set => character = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        character = new Character(10f ,7f, 15, 3f);
    }

    public void UPDateCharacterState(float Attack = 0, float Defence = 0, float Hp = 0, float Critical = 0) 
    {
        character.Attack += Attack;
        character.Defence += Defence;
        character.Hp += Hp;
        character.CriticalHit += Critical;
    }
}
