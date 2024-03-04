using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTerrain : Graphic
{

    private void OnGUI()
    {
        // 檢測更新繪製 OnPopulateMesh 中 transform.child 位置
        SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        if (transform.childCount <= 2)
        {
            return;
        }

        Color32 color32 = color;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                vh.AddVert(child.localPosition, color32, new Vector2(0f,0f));
            }
            else
            {
                return;
            }
        }

        for (int i = 0; i < transform.childCount - 2; i++)
        {
            vh.AddTriangle(i + 1, i + 2, 0);
        }
    }
}


//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
