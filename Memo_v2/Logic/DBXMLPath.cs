using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Memo_v2.Logic {
    class DBXMLPath {
        string path = "";

        public string DBPath {
            set { path = value; }
            get {
                getFilePathDB();
                return path;
            }
        }

        public string XMLPath {
            set { path = value; }
            get {
                getFilePathXML();
                return path;
            }
        }

        private void getFilePathDB() {
            if (path.Equals("")) {
                var directpryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

                var dataBaseFilePath = Path.Combine(directpryPath, @"memoDB.mdf");

                Debug.Print(dataBaseFilePath);

                path = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}", new Uri(dataBaseFilePath).LocalPath);             
            }
        }

        private void getFilePathXML() {
            if (path.Equals("")) {
                var directpryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

                var dataBaseFilePath = Path.Combine(directpryPath, @"file.xml");

                path = new Uri(dataBaseFilePath).LocalPath;
            }
        }
    }
}
