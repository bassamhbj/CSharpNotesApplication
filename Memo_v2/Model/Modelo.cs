using Memo_v2.Interfaces;
using Memo_v2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v2.Model {
    public class Modelo {
        Observer obs;
        private List<Memo> memoList;
        private DataBase dataBase;
        private XMLManager xml;

        public Modelo() {
            dataBase = new DataBase();
            xml = new XMLManager();
        }

        public void loadMemo() {
            memoList = dataBase.loadMemo();
            //memoList = xml.loadMemo();
            obs.onLoadMemo(memoList);
        }

        public void addObserver(Observer obs) {
            this.obs = obs;
        }

        public void loadMemoBody(int index) {
            obs.onLoadMemoBody(memoList[index].Body);
        }

        public void newMemo(string title, string body) {
            dataBase.newMemo(title, body);
            //xml.newMemo(title, body);
            obs.onNewMemoCreated();
        }

        public void autoSaveMemo(string text, DateTime time, int index) {
            dataBase.autoSave(text, time, index);
            //xml.autoSave(text, time, index);
        }

        public void deleteMemo(int index) {
            dataBase.deleteMemo(index);
            //obs.onMemoDeleted();
        }
    }
}
