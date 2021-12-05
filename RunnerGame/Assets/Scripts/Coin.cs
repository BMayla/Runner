using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.score += 1;
            Debug.Log("Coins:" + PlayerManager.score);
            Destroy(gameObject);
            /*GameObject effect = ObjectPool.instance.GetPooledObject();

            if (effect != null)
            {
                effect.transform.position = transform.position;
                effect.transform.rotation = effect.transform.rotation;
                effect.SetActive(true);
            }

            PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + 1);
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
            PlayerManager.score += 2;
            gameObject.SetActive(false);*/
        }
    }
}
