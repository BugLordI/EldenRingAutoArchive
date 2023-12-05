/*************************************************************************************
 *
 * 文 件 名:   AppSetting.cs
 * 描    述:   工程配置文件工具类
 * 
 * 创 建 者：  BugLord 
 * 创建时间：  2022/06/18 13:03:52
*************************************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace AutoArchive.Tools
{
    /// <summary>
    /// 项目配置文件
    /// </summary>
    public class AppSetting
    {
        private JToken token;

        /// <summary>
        /// 初始化配置文件实例
        /// </summary>
        /// <param name="configFile">配置文件名(JSON)</param>
        public AppSetting(String configFile)
        {
            token = readJson(configFile, Encoding.UTF8);
        }

        /// <summary>
        /// 获取指定键对应的值
        /// </summary>
        /// <param name="key">key可以按照层级依次获取值，多个层级以':'隔开</param>
        /// <returns></returns>
        public String this[String key]
        {
            get
            {
                String result = String.Empty;
                if (token != null && key.Contains(":"))
                {
                    String[] keys = key.Split(':');
                    JToken jToken = token.DeepClone();
                    foreach (String p in keys)
                    {
                        jToken = jToken[p];
                    }
                    result = jToken.ToString();
                }
                else
                {
                    if (token != null)
                    {
                        result = token[key].ToString();
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 读取json文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonFile">json文件路径</param>
        /// <param name="encoding">文件编码，如果不指定则使用默认编码去读取</param>
        /// <returns>指定的对象</returns>
        public static JToken readJson(String jsonFile, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(jsonFile, encoding == null ? Encoding.Default : encoding))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    var array = JToken.ReadFrom(reader);
                    return array;
                }
            }
        }
    }
}
