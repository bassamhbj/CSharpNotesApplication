using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Memo_v2.Logic {
    public abstract class Storage {
        private string path = "";

        protected string DBPath {
            set { path = value; }
            get {
                getFilePathDB();
                return path;
            }
        }

        protected string XMLPath {
            set { path = value; }
            get {
                getFilePathXML();
                return path;
            }
        }

        private void getFilePathDB() {

            // Check if works properly

            if (path.Equals("")) {
                var directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

                var dataBaseFilePath = Path.Combine(directoryPath, @"memoDB2.mdf");

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

        public abstract List<Memo> loadMemo();

        public abstract void newMemo(string title, string body);

        public abstract void deleteMemo(int index);

        public abstract void autoSave(string text, DateTime time, int index);
    }
}
