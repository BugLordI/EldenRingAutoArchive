/*************************************************************************************
 *
 * 文 件 名:   DateUtil.cs
 * 描    述:   DateUtil
 * 
 * 创 建 者：  BugLord 
 * 创建时间：  2022/6/18 13:40:47
*************************************************************************************/
using System;

namespace AutoArchive.Tools
{
    public class DateUtil
    {
        /// <summary>
        /// 时间转换为unix时间戳
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long toUnixTimestamp(DateTime datetime)
        {
            return (datetime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// 【秒级】获取时间（北京时间）
        /// </summary>
        /// <param name="timestamp">10位时间戳</param>
        public static DateTime getDateTime(long timestamp)
        {
            long begtime = timestamp * 10000000;
            DateTime dt_1970 = new DateTime(1970, 1, 1, 8, 0, 0);
            long tricks_1970 = dt_1970.Ticks;//1970年1月1日刻度
            long time_tricks = tricks_1970 + begtime;//日志日期刻度
            DateTime dt = new DateTime(time_tricks);//转化为DateTime
            return dt;
        }
    }
}
