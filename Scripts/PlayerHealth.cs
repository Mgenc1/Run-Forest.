using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public int Health;
    public GameObject[] HealthAll;
    public GameObject HealthPrefab;

    private GameObject Parent;


    private void Start()
    {
        HealthAll = new GameObject[Health];
        Parent = GameObject.FindGameObjectWithTag("Parent");
        for (int i = 0; i < HealthAll.Length; i++)
        {
            GameObject h = Instantiate(HealthPrefab);
            h.transform.SetParent(Parent.transform);
            HealthAll[i] = h;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health--;

            if (Health > 0)
            {
                HealthAll[Health].SetActive(false);

            }
            else if (Health <= 0)
            {
                HealthAll[0].SetActive(false);
                gameManager.EndGame();
                
            }
        }


    }

}