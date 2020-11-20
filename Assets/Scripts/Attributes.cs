using System.Collections.Generic;

[System.Serializable]
public class Attributes
{
    public enum CharacterAttribute
    {
        人性,
        佛性,
        水性,
        杨花,
    }
    public CharacterAttribute characterAttri;
    public Attributes(CharacterAttribute characterAttribute, float value)
    {
        this.characterAttri = characterAttribute;
        this.Value = value;
    }
    public float Value;
    public static Dictionary<CharacterAttribute, float> CharacterStatistic = new Dictionary<CharacterAttribute, float>();
}