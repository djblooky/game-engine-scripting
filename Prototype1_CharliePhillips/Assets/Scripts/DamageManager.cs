using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{
    private int damage;
    [SerializeField] Text damageText; 

    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        UpdateDamageText();
    }

    public void IncrementDamage()
    {
        damage++;
        UpdateDamageText();
    }

    private void UpdateDamageText()
    {
        damageText.text = $"Damage: {damage}";
    }

    private void Update()
    {
        if(damage >= 100)
        {
            damage = 0;
        }
    }
}
