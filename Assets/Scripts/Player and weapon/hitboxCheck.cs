using UnityEngine;

public class hitboxCheck : MonoBehaviour
{
    [SerializeField] private AudioClip CollisionSFX;
    //Pelle
    public GameObject weap;
    int damage;
    int spells;
    //checks collision and gives dmg
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        enemyHP enemyComponent = enemy.GetComponent<enemyHP>();
        wall wallComponent = enemy.GetComponent<wall>();
        weapon spell = weap.GetComponent<weapon>();
        if (enemyComponent != null)
        {
            if (gameObject.tag == "water")
            {
                //Plays sound FX
                SoundFXManager.instance.PlaySoundFXclip(CollisionSFX, transform, 1f);

                spells = 1;
                //förstör proj och skada
                damage = 80;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.tag == "fire")
            {
                spells = 2;
                //förstör proj och skada
                damage = 5;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.tag == "stone")
            {
                //Plays sound FX
                SoundFXManager.instance.PlaySoundFXclip(CollisionSFX, transform, 1f);

                spells = 3;
                //skada
                damage = 150;
            }
            if (gameObject.tag == "lightning")
            {
                //Plays sound FX
                SoundFXManager.instance.PlaySoundFXclip(CollisionSFX, transform, 1f);

                spells = 4;
                //förstör proj och skada
                damage = 290;
                Destroy(gameObject);

            }
            enemyComponent.damageCall(damage, spells);
        }
        if (wallComponent != null)
        {
            //Plays sound FX
            SoundFXManager.instance.PlaySoundFXclip(CollisionSFX, transform, 1f);

            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

    }
    private void Update()
    {

    }
}
