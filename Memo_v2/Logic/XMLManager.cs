using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v2.Logic {
    public class XMLManager : Storage {

        private List<Memo> memoList;

        public override void autoSave(string text, DateTime time, int index) {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(getFileText());

            XmlNode root = doc.DocumentElement;

            XmlElement newElem = getMemoElement(memoList[index].Title, text, time, doc);

            Debug.Print(newElem.GetAttribute("date").ToString() + newElem.Name + newElem.InnerText);
            XmlNode node = newElem;

            XmlNodeList nodeList = root.ChildNodes;

            root.ReplaceChild(node, nodeList[index]);

            memoList[index].Body = text;

            doc.Save(XMLPath);
        }

        public override void deleteMemo(int index) {
            throw new NotImplementedException();
        }

        public override List<Memo> loadMemo() {
            //throw new NotImplementedException();
            string aux2 = "";

            memoList = new List<Memo>();
            Memo memoAux = new Memo();

            using (XmlTextReader reader = new XmlTextReader(XMLPath)) {
                while (reader.Read()) {
                    switch (reader.NodeType) {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("Memo"))
                                memoAux.Date = Convert.ToDateTime(reader.GetAttribute("date"));
                            else if (reader.Name.Equals("Title"))
                                aux2 = "title";
                            else if (reader.Name.Equals("Body"))
                                aux2 = "body";
                            break;
                        case XmlNodeType.Text:
                            if (aux2.Equals("title")) {
                                memoAux.Title = reader.Value;
                                //Debug.Print("title: " + memoAux.Title);
                            }
                            else if (aux2.Equals("body")) {
                                memoAux.Body = reader.Value;
                                //Debug.Print("body: " + memoAux.Body);
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.Name.Equals("Memo")) {
                                memoList.Add(new Memo(memoAux.Date, memoAux.Title, memoAux.Body));
                                //memoAux = new Memo();
                            }
                            break;
                    }
                }
            }

            return memoList;
        }

        public override void newMemo(string title, string body) {
            if (!File.Exists(XMLPath)) {
                createXML(title, body);
            }
            else {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(getFileText());

                XmlNode root = doc.DocumentElement;

                root.AppendChild(getMemoElement(title, body, DateTime.Now, doc));

                doc.Save(XMLPath);
            }
        }

        private void createXML(string title, string body) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineOnAttributes = true;
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(XMLPath, settings)) {

                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                writer.WriteStartElement("Memo");
                writer.WriteAttributeString("date", DateTime.Now.ToString());
                writer.WriteElementString("Title", title);
                writer.WriteElementString("Body", body);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private XmlElement getMemoElement(string title, string body, DateTime time, XmlDocument doc) {
            XmlElement elem = doc.CreateElement("Memo");

            elem.SetAttribute("date", time.ToString());

            XmlElement titleElem = doc.CreateElement("Title");
            titleElem.InnerText = title;

            XmlElement bodyElem = doc.CreateElement("Body");
            bodyElem.InnerText = body;

            elem.AppendChild(titleElem);
            elem.AppendChild(bodyElem);

            return elem;
        }

        private string getFileText() {
            string text = "";

            using (XmlTextReader reader = new XmlTextReader(XMLPath)) {
                while (reader.Read()) {
                    switch (reader.NodeType) {
                        case XmlNodeType.Element:
                            if (!reader.HasAttributes) {
                                text += string.Format("<{0}>", reader.Name);
                            }
                            else {
                                text += string.Format(@"<{0} date=""{1}"">", reader.Name, reader.GetAttribute("date"));
                            }
                            break;
                        case XmlNodeType.Text: text += reader.Value; break;
                        case XmlNodeType.EndElement: text += string.Format("</{0}>", reader.Name); break;
                    }
                }
                Debug.Print(text);
            }

            return text;
        }
    }
}
