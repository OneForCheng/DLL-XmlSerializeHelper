using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ForCheng.XmlSerialize
{
    /// <summary>
    /// 将一个类型序列化为文件或从文件反序列化的辅助类
    /// </summary>
    /// <typeparam name="T">目标类型</typeparam>
    public abstract class XmlSerializeHelper<T>
    {
        private readonly string _defaultXmlFilePath;
        private readonly XmlSerializer _xmlSerializer;

        protected XmlSerializeHelper()
        {
            _xmlSerializer = new XmlSerializer(typeof(T));
            _defaultXmlFilePath =  $"{typeof(T).Name}.xml";
            XmlFilePath = _defaultXmlFilePath;
        }

        [XmlIgnore]
        public string XmlFilePath { get; set; }

        public void Load(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    if (path == null) path = _defaultXmlFilePath;
                    path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                    if (!File.Exists(path)) return;
                }
                XmlFilePath = path;
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    LoadCore((T)_xmlSerializer.Deserialize(fs));
                }
            }
            catch (Exception ex)
            {
                LoadException(ex);
            }
        }

        public void Save()
        {
            SaveAs(XmlFilePath);
        }

        public void SaveAs(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    if (path == null) path = _defaultXmlFilePath;
                    path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
                }

                var file = new FileInfo(path);

                if (file.Directory != null && !file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                using (var sw = new StreamWriter(file.FullName))
                {
                    _xmlSerializer.Serialize(sw, this);
                }
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }

        protected abstract void LoadCore(T obj);

        protected virtual void LoadException(Exception ex)
        {
            Trace.Write(ex.ToString());
        }

        protected virtual void SaveException(Exception ex)
        {
            Trace.Write(ex.ToString());
        }
    }
}
