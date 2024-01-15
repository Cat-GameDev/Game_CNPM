using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform TF;
    public Transform playerTF;

    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        if(GameManager.Instance.IsState(GameState.Shop))
        {
            transform.position = new Vector3(0,3,-2.95000005f);
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
            return;
        }

        if(GameManager.Instance.IsState(GameState.MainMenu))
        {
            transform.position = new Vector3(0,3,-2.95000005f);
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        }

        

        if(!GameManager.Instance.IsState(GameState.Gameplay))
            return;
        
        else if(playerTF != null)
        {
            TF.position = Vector3.Lerp(TF.position, playerTF.position + offset, Time.deltaTime * 5f);
        }
        else
        {
            playerTF = LevelManager.Instance.GetPlayer();
        }
        
    }
}
