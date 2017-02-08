using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memo_v2.Model;
using Memo_v2.Interfaces;

namespace Memo_v2.Controller {
    public class Controlador {
        private Modelo model;

        public Controlador(Modelo m) {
            this.model = m;
        }

        public void loadMemo() {
            model.loadMemo();
        }

        public void addObserver(Observer obs) {
            model.addObserver(obs);
        }

        public void loadMemoBody(int index) {
            model.loadMemoBody(index);
        }

        public void newMemo(string title, string body) {
            model.newMemo(title, body);
        }

        public void deleteMemo(int index) {
            model.deleteMemo(index);
        }

        public void autoSave(string text, DateTime time, int index) {
            model.autoSaveMemo(text, time, index);
        }
    }
}
