using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class HuanJingPanel : MonoBehaviour
    {
        public Text textPm25;
        public Text textPm10;
        public Text textTem;
        public Text textHum;
        public Text textNoise;
        public Text textWp;
        public Text textWs;
        public Text textWd360;

        public void UpdateHuanJingData(HuanJingData huanJingData)
        {
            if(huanJingData != null)
            {
                UpdateHuanJingData(
               huanJingData.pm25.ToString(),
               huanJingData.pm10.ToString(),
               huanJingData.tem.ToString(),
               huanJingData.hum.ToString(),
               huanJingData.noise.ToString(),
               huanJingData.wp.ToString(),
               huanJingData.ws.ToString(),
               huanJingData.wd360.ToString());
            }
            else
            {
                UpdateHuanJingData("0", "0", "0", "0", "0", "0", "0", "0");
            }
        }

        public void UpdateHuanJingData(string pm25,string pm10,string tem,string hum,string noise,string wp,string ws,string wd360)
        {
            textPm25.text = pm25 + "ug/m³";
            textPm10.text = pm10 + "ug/m³";
            textTem.text = tem + "℃";
            textHum.text = hum + "%RH";
            textNoise.text = noise + "dB";
            textWp.text = wp + "级";
            textWs.text = ws + "m/s";
            textWd360.text = wd360 + "°";
        }
    }
}