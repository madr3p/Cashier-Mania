using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlayClick()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayClick();
        }
    }
}