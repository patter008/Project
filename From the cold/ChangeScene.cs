using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    // Use this for initialization
    public void ChangeToScene (int sceneToChangeTo) {
    Application.LoadLevel(sceneToChangeTo);
    //}
    // fade out the game and load a new level
    //IEnumerator ChangeLevel() {
        
       // float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
       // yield return new WaitForSeconds(fadeTime);
    
        //Application.LoadLevel(Application.loadedLevel+1);
    }
}
