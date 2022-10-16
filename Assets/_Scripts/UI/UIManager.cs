using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // hide canvas panel 
        // hide play button
        // turn HUD on (Life,Score,Bullets)
        // change to camera above player
    }
    public void HpBar()
    {
        // create a slider to change hp depends on life
    }
    public void BulletsStack()
    {
        // change bullet number depends on the magazine size
        // call reload function when empty
    }
    public void Reload()
    {
        //change bullet logo to reload bullets
        //on reload change it back to normal
    }
    public void Mute()
    {
       // mute sound
       // change logo to muted
    }
    public void UnMure()
    {
        // unmute sound
        // change logo to unmuted
    }

}
