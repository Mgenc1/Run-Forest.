using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))] 

public class Player : MonoBehaviour
{
    public float Speed;
    public float SwerveFactor;

    private float Pos;
    private float moveFactorX;

    [Header("CLAMP VALUES")]
    public float MinClamp;
    public float MaxClamp;

    [SerializeField] GameManager gameManager;

    
    void Start()
    {

    }

   
    void Update()
    {
        if (gameManager.isStart == true)
        {
            Movement();
            ClampMovement();
            CursorLockAndVisible();
        }
        
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Down");
            Pos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - Pos;
            Pos = Input.mousePosition.x;
            Debug.Log("Button");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
            Debug.Log("Up");
        }

        transform.Translate(moveFactorX * Time.deltaTime * SwerveFactor, 0, Time.deltaTime * Speed);
    }

    private void ClampMovement()
    {
        Vector3 ClampPos = transform.position;
        ClampPos.x = Mathf.Clamp(ClampPos.x, MinClamp, MaxClamp);
        transform.position = ClampPos;
    }

    private void CursorLockAndVisible()   //bu fonk çalışmıyor.Animasyonlar.
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            UIManager.Money += 10;
            SoundManager.Instance.PlayGoldCollection();
        }
        if (other.gameObject.CompareTag("End"))
        {
            gameManager.Win();
            SoundManager.Instance.StopSounds();
        }
    }

}

