using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSeclector : MonoBehaviour
{
    // clip part 6
    public static CharacterSeclector instance;
    public CharacterScriptableObject characterData;
    // Start is called before the first frame update
    
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Debug.LogWarning("EXTRA " +  this + " DELETED");
            Destroy(gameObject);
        }

    }
    public static CharacterScriptableObject GetData(){
        return instance.characterData;
    }
    public void SelectCharacter(CharacterScriptableObject ch){
        characterData = ch;
    }
    public void DestroySingleton(){
        instance = null;
        Destroy(gameObject);
    }
}
