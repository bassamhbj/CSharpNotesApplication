using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v1 {
    interface Observer {
        //void addNote();
        void newMemo(string title, string body);
        void deleteMemo(int index);
        List<Memo> loadMemo();
        void autoSave(string text, DateTime time, int index);
    }
}
