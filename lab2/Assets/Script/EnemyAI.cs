using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Sprite deathSprite;
    [SerializeField] float moveSpeed = 1.0f;
    bool movingLeft = true;
    GameObject ui;
    //UIController uiController;

    private void Start()
    {
        //ui = GameObject.FindGameObjectWithTag("UIController");
        //uiController = ui.GetComponent<UIController>();
    }

    private void Update()
    {
        float moveStep = moveSpeed * Time.deltaTime * (movingLeft ? -1 : 1);
        transform.position = new Vector2(transform.position.x + moveStep, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("TurnPoint"))
        {
            movingLeft = !movingLeft;
        }/*
        else if (collider.gameObject.CompareTag("Player"))
        {
            Death();
        }*/
    }



    public void Death()
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            GetComponent<EnemyAnim>().SetSprites(deathSprite);
            //uiController.score += 100;
            //GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}
