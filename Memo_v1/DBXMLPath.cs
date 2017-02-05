using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v1 {
    class DBXMLPath {

        string path = "";

        public string DBPath {
            set { path = value; }
            get {
                getFilePathDB();
                return path;
            }
        }

        private void getFilePathDB() {
            if (path.Equals("")) {
                var directpryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

                var dataBaseFilePath = Path.Combine(directpryPath, @"memoDB.mdf");

                path = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}", new Uri(dataBaseFilePath).LocalPath);
            }
        }
    }
}
