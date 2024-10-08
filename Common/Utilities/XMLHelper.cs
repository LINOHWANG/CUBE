using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace SDCafeCommon.Utilities
{
    public static class XMLHelper
    {
        /// <summary>
        /// Usage: var xmlString = XMLHelper.Serialize<MyObject>(value);
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="value">giá trị</param>
        /// <param name="omitXmlDeclaration">bỏ qua declare</param>
        /// <param name="removeEncodingDeclaration">xóa encode declare</param>
        /// <returns>xml string</returns>
        public static string Serialize<T>(T value, bool omitXmlDeclaration = false, bool omitEncodingDeclaration = true)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = omitXmlDeclaration, //true: remove <?xml version="1.0" encoding="utf-8"?>
                    Encoding = Encoding.UTF8,
                    NewLineChars = "", // remove \r\n
                };

                var xmlserializer = new XmlSerializer(typeof(T));

                using (var memoryStream = new MemoryStream())
                {
                    using (var xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                    {
                        xmlserializer.Serialize(xmlWriter, value);
                        //return stringWriter.ToString();
                    }

                    memoryStream.Position = 0;
                    using (var sr = new StreamReader(memoryStream))
                    {
                        var pureResult = sr.ReadToEnd();
                        var resultAfterOmitEncoding = ReplaceFirst(pureResult, " encoding=\"utf-8\"", "");
                        if (omitEncodingDeclaration)
                            return resultAfterOmitEncoding;
                        return pureResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XMLSerialize error: ", ex);
            }
        }

        private static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);

            if (pos < 0)
            {
                return text;
            }

            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
