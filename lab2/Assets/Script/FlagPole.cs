using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    
	public Transform bottom, flag, drop, exitDoor;
	public float flagSlideSpeed, marioSlideSpeed;
	bool finishedSliding = false, hasStarted = false;
    bool isdrop = false;
	IEnumerator FlagSlide()
	{
		
		while (flag.position != bottom.position)
		{
			flag.position = Vector2.MoveTowards(flag.position, bottom.position, Time.deltaTime * flagSlideSpeed);
			yield return null;
		}
		finishedSliding = true;
	}

    IEnumerator MarioSlide(PlayerMovement player, float speed)
    {
        if (player.transform.position != drop.position)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, drop.position, speed * Time.deltaTime);

            yield return null;
            
        }
        // 假设这里player.Move是修改玩家位置的逻辑
        while (player.transform.position != exitDoor.position)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, exitDoor.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasStarted && collision.gameObject.CompareTag("Player"))
        {         
            //hasStarted = true;
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.EnableMovement(false);
            StartCoroutine(FlagSlide());
            StartCoroutine(MarioSlide(player, marioSlideSpeed));
        }
    }


    /*
    public Transform flag;
    public float slideSpeed = 2f;
    public Vector2 endPoint;

    private bool isSliding = false;

    private void Update()
    {
        if (isSliding)
        {
            flag.position = Vector2.MoveTowards(flag.position, endPoint, slideSpeed * Time.deltaTime);
            if (Vector2.Distance(flag.position, endPoint) < 0.1f)  // 使用一定的容差来判断是否到达
            {
                isSliding = false;
                Debug.Log("完成关卡！");
                // 在这里添加旗帜到达底部后的逻辑
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSliding = true;
            endPoint = new Vector2(flag.position.x, endPoint.y);
        }
    }
	*/
}
