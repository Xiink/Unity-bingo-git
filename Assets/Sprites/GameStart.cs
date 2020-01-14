using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class GameStart : MonoBehaviour {
    //遊戲一開始先產生24個不重複數字並加入格子中

    public GameObject Grids; //格子父物件
    List<Transform> grid_ch = new List<Transform>();  //子物件List
    int childnum = 0; //子物件數量
    Game game;
    List<int> number = new List<int>(Enumerable.Range(1, 75));  //產生的數字陣列
    List<int> sum = new List<int>(Enumerable.Range(1, 25));
    System.Random rand = new System.Random();
    int getnum = 0;

    // Start is called before the first frame update
    void Start() {
        game = FindObjectOfType<Game>();
        childnum = Grids.transform.childCount;
        SaveChild();  //儲存父物件
        UpadteGridsText(); //更新格子上的數字
    }

    // Update is called once per frame
    void Update() {

    }

    void SaveChild() {
        for (int i = 0; i < childnum; i++) {
            var ch = Grids.transform.GetChild(i);
            grid_ch.Add(ch);
        }
    }

    void UpadteGridsText() {
        number = number.OrderBy(num => rand.Next()).ToList<int>();
        for (int i = 0; i < childnum; i++) {
            var gtxt = grid_ch[i].transform.GetChild(0).GetComponent<TextMesh>();
            gtxt.text = number[i].ToString();
            if (i == 12) {
                gtxt.text = "★";
                number[i] = 99;  //中間為特殊位置
            }
            sum[i] = number[i];
        }
        game.GetList(sum);
    }
}
