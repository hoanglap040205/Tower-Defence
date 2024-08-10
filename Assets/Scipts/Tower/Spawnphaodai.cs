using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnphaodai : MonoBehaviour
{
  
    // Prefab của GameObject mới
    public GameObject prefab;

    // Biến boolean để kiểm tra xem đã nhấn hay chưa
    private bool hasspawned = false;


    public float rangemove = 5f;

 



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        // Kiểm tra xem người chơi có nhấn chuột trái hay không
        if (Input.GetMouseButtonDown(0) && !hasspawned )
        {
            // Lấy vị trí của con trỏ chuột trong thế giới 2D
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Kiểm tra xem con trỏ chuột có chạm vào Collider2D hay không
            Collider2D hitcollider = Physics2D.OverlapPoint(mouseposition);
            if(hitcollider != null && hitcollider.gameObject == gameObject)
            {
                Vector2 collidercenter = hitcollider.bounds.center;
                // Tạo ra GameObject mới tại vị trí của con trỏ chuột
                Instantiate(prefab,collidercenter,Quaternion.identity);

                hasspawned=true;

               
            }
        }
    }
}
