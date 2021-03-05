using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBehav : MonoBehaviour
{
    public static AudioClip fireball, die, dmg;
    static AudioSource audioSource;

    // ----------------------- 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        fireball = Resources.Load<AudioClip>("Sounds/fireball");
        die = Resources.Load<AudioClip>("Sounds/die");
        dmg = Resources.Load<AudioClip>("Sounds/dmg");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch (clip){
            case "fireball":
                audioSource.PlayOneShot(fireball);
                break;
            case "die":
                audioSource.PlayOneShot(die);
                break;
            case "dmg":
                audioSource.PlayOneShot(dmg);
                break;
        }
    }
}
