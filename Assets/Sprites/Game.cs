using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour {

    public GameObject Grids;
    public GameObject Numbers;
    int childnum = 0; //子物件數量
    List<Transform> grid_ch = new List<Transform>();  //子物件List
    List<int> number = new List<int>(Enumerable.Range(1, 75));  //產生的數字陣列
    List<int> sumList = new List<int>(Enumerable.Range(1, 25));  //產生的數字陣列
    System.Random rand = new System.Random();
    string nowNum="";  //現在球的數字
    public int winLine = 1;
    public GameObject gameoverUI;
    int x = 0;
    int[,] win = new int[5,5];
    bool isWin = false;
    public int index;  //現在的數字

    void Awake() {
        childnum = Grids.transform.childCount;
        number = number.OrderBy(num => rand.Next()).ToList<int>();
        number = number.OrderBy(num => rand.Next()).ToList<int>();  //避免跟GameStart取得相同亂數
        for (int i = 0; i < childnum; i++) {
            var ch = Grids.transform.GetChild(i);
            grid_ch.Add(ch);
        }
        for (int x = 0; x < 5; x++)
            for (int y = 0; y < 5; y++)
                win[x,y] = 0;
        grid_ch[12].GetComponent<Renderer>().material.color = Color.yellow;
        grid_ch[12].GetComponent<Animator>().SetBool("chose", true);
        win[2,2] = 1;
    }

    //更新UI
    void Update() {
      
    }

    public void Checkwin() {
         nowNum = number[x].ToString();
        //Numbers.transform.GetChild(0).GetChild(Int32.Parse(nowNum) - 1).GetComponent<TextMesh>().color = Color.white;
        //Numbers.transform.GetChild(0).GetChild(x).GetComponent<MeshRenderer>().material.color = Color.white;
        //Debug.Log(Numbers.transform.GetChild(0).GetChild(x).GetComponent<MeshRenderer>().material.color.a);
        //Numbers.transform.GetChild(0).GetChild(x).GetComponent<TextMesh>().color = Color.clear;
        //sNumbers.transform.GetChild(0).GetChild(x).GetComponent<MeshRenderer>().enabled = true;
        Numbers.transform.GetChild(0).GetChild(x).GetComponent<MeshRenderer>().enabled = true;
        Numbers.transform.GetChild(0).GetChild(x).GetComponent<TextMesh>().color = Color.white;
        Numbers.transform.GetChild(0).GetChild(x).GetComponent<TextMesh>().text = nowNum;
        Numbers.transform.GetChild(0).GetChild(x).GetComponent<Animator>().SetTrigger("Play");
        index = sumList.IndexOf(sumList.Find(item => item==number[x]));        
        if ( index !=-1) {
            int x = index/5, y = index%5;
            win[x,y] = 1;
        }      
        int nowLine = 0;
        for(int i = 0; i < 5; i++) {
                if (win[0, i] + win[1, i] + win[2, i] + win[3, i] + win[4, i] == 5)
                    nowLine++;
                if(win[i, 0] + win[i, 1] + win[i, 2] + win[i, 3] + win[i, 4] == 5)
                    nowLine++;
        }
        if(win[0, 0] + win[1, 1] + win[2, 2] + win[3, 3] + win[4, 4] == 5)
            nowLine++;
        if(win[0, 4] + win[1, 3] + win[2, 2] + win[3, 1] + win[4, 0] == 5)
            nowLine++;
        if (nowLine >= winLine)
            isWin = true;
        x++;
    }

    //接收GameStart產生的亂數List
    public void GetList(List<int> numList) {
        sumList = numList; 
    }

    public void clickBingo() {
        if (isWin) {
            x = 99;
            gameoverUI.SetActive(true);
        }
    }

    public int getBallnum() {
        return x;
    }

    public string getBalltext() {
        return nowNum;
    }

    public void SetGridColor() {
        if (index != -1 && x!=0) {
            grid_ch[index].GetComponent<Renderer>().material.color = Color.yellow;
            grid_ch[index].GetComponent<Animator>().SetBool("chose", true);
        }
    }
}
