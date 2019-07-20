using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecenChage : MonoBehaviour
{
   // public Transform target;
    public string transferMapName;
    public BoxCollider2D targetbound;

    private PlayerManager thePlayer;
    private CameraManager theCamera;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theCamera = FindObjectOfType<CameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            thePlayer.currenMapName = transferMapName;
            theCamera.SetBound(targetbound);
             SceneManager.LoadScene(transferMapName);
          //  theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
           // thePlayer.transform.position = target.transform.position;
        }
    }
}
