using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UDPSend : MonoBehaviour
{
    UDPManager manager;
    // Start is called before the first  update
    void Start()
    {
        //��ȡ��UDPManager �ű��ڲ��Լ��������߳������ٴο���
        manager = GetComponent<UDPManager>();
        if (manager == null)
        {
            manager = gameObject.AddComponent<UDPManager>();
        }
        //���úý����ķ���
    }
    // Update is called once per 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 FF FF FF FF65"); 


        }
        if (Input.GetKeyDown(KeyCode.D))//�ر�ȫ��
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");

        }
        if (Input.GetKeyDown(KeyCode.A))//�ر�ȫ�� ֻ��1��
        { 
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 13 00 00 00 0069");
            Invoke("openOne",0.5f);

        }
        if (Input.GetKeyDown(KeyCode.F))//�ر�ȫ�� ֻ��1��
        {
            manager.UDPSendMessage("192.168.1.8", 8899, "5501 11 00 00 00 0168");

        }
    }
    void openOne()
    {
        manager.UDPSendMessage("192.168.1.8", 8899, "5501 12 00 00 00 0169");// �򿪵�1·
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
