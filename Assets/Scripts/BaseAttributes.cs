using UnityEngine;

[CreateAssetMenu(fileName = "New Attributes", menuName = "Player/Attributes")]
public class BaseAttributes : ScriptableObject
{
    /// <summary>
    /// Attribute governing HP.
    /// Also affects fire resistance and Immunity stat.
    /// </summary>
    public float vigor;

    /// <summary>
    /// Attribute governing FP.
    /// Also affects the Focus stat.
    /// </summary>
    public float mind;

    /// <summary>
    /// Attribute governing Stamina.
    /// Also affects Robustness.
    /// This attribute also determines how heavy your equipment 
    /// </summary>
    public float endurance;

    /// <summary>
    /// Attribute required to wield heavy armaments.
    /// Also boosts attacks power of strength-scaling armaments and affects your Physical Defense.
    /// </summary> 
    public float strength;

    /// <summary>
    /// Attribute required to wield advanced armaments.
    /// Also boosts attack power of dexterity-scaling armaments, reduces casting time of Spells, softens fall damage, and makes it harder to be knocked off your horse.
    /// </summary>
    public float dexterity;

    /// <summary>
    /// Attribute required to perform glintstone sorceries. Also boosts the power of intelligence-scaling Sorceries and improves Magic Resistance.
    /// </summary>
    public float intelligence;
    
    /// <summary>
    /// Attribute required to perform sacred Incantations. Also boosts the power of faith-scaling Incantations.
    /// </summary>
    public float faith;
    
    /// <summary>
    /// Attribute governing Discovery.
    /// Also affects Holy Defense, Vitality, and certain Sorceries and Incantations.
    /// </summary>
    public float arcane;
}