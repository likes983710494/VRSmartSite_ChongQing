namespace Wzg
{
    public class RequestURLs
    {
        // 测试环境： 192.168.1.214 滨州职业：10.80.1.79
        //192.168.10.2              192.168.10.2:9999
        public static string BaseURL = "http://124.133.247.58:535/zhgd/vrinterface/";
        public static string addHongWaiAlarm = BaseURL + "addHongWaiAlarm";
        public static string addInspectionRecord = BaseURL + "addInspectionRecord";
        public static string addKaoQin = BaseURL + "addKaoQin";
        public static string addShengJiangJiData = BaseURL + "addShengJiangJiData";
        public static string addShenJiKengData = BaseURL + "addShenJiKengData";
        public static string addXieLiaoAlarm = BaseURL + "addXieLiaoData";
        public static string addYanGanAlarm = BaseURL + "addYanGanAlarm";
        public static string getHuanJingNowData = BaseURL + "getHuanJingNowData";
        public static string getPersonList = BaseURL + "getPersonList";
        public static string updatePerson = BaseURL + "updatePerson";
        public static string lightCmd = BaseURL + "command/";

        public static string deviceAlarm = "deviceAlarm";
        public static string gdInspectionRecord = "gdInspectionRecord";
        public static string gdKaoQin = "gdKaoQin";
        public static string deviceShengJiangJiData = "deviceShengJiangJiData";
        public static string deviceShenJiKengData = "deviceShenJiKengData";

        /// <summary>
        /// 项目ID
        /// </summary>
        public static string projectId = "86c22cc07ca54d46ed5b65f2c94fc43f";
        /// <summary>
        /// 环境检测设备ID
        /// </summary>
        public static string huanjingId = "c0fc919cb032b8c66ba366f7831a3f2e";
        /// <summary>
        /// 烟感报警设备ID
        /// </summary>
        public static string yanGanId = "cc4b3bacad21ba02660b42a4529b5fee";
        /// <summary>
        /// 升降机
        /// </summary>
        public static string shengJiangJiId = "64d2aa0aecf0297c9640f6463a979215";
        /// <summary>
        /// 卸料平台
        /// </summary>
        public static string xieLiaoPingTaiId = "8e4c1b05c03b50ce9472005e5f89aa79";
        /// <summary>
        /// 深基坑
        /// </summary>
        public static string shenJiKengId = "4ea5a60d9f228f4a030bb444e3f2609e";
        /// <summary>
        /// 红外入侵
        /// </summary>
        public static string hongwaiId = "004fab4cd0218b4b14d843bb1f6c5d25";

        /// <summary>
        /// 深基坑区域巡检
        /// </summary>
        public static string shenjiKengXunJianId = "0a521158a1037ea1b3082bc937175527";
        /// <summary>
        /// 塔吊区域巡检
        /// </summary>
        public static string tadiaoXunJianId = "6fda2a5da5067f67013d79d42955cab3";

    }
}