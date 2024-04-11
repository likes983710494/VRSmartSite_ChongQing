using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UDPSend : MonoBehaviour
{
    UDPManager manager;
    // Start is called before the first  update
    void Start()
    {
        //获取到UDPManager 脚本内部自己开启了线程无需再次开启
        manager = GetComponent<UDPManager>();
        if (manager == null)
        {
            manager = gameObject.AddComponent<UDPManager>();
        }
        //设置好解析的方法
    }
    // Update is called once per 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 FF FF FF FF65"); 


        }
        if (Input.GetKeyDown(KeyCode.D))//关闭全部
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");

        }
        if (Input.GetKeyDown(KeyCode.A))//关闭全部 只开1个
        { 
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");
            Invoke("openOne",0.5f);

        }
        if (Input.GetKeyDown(KeyCode.F))//关闭全部 只开1个
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 11 00 00 00 0168");

        }
    }
    void openOne()
    {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 12 00 00 00 0169");// 打开第1路
    }


    public void SOne() {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 FF FF FF FF65");
    }
    public void AOne()
    {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");
        Invoke("openOne", 0.5f);
    }
    public void DOne()
    {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");
    }
    public void FOne()
    {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 11 00 00 00 0168");
    }
}
