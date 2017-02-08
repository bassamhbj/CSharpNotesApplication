using Memo_v2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v2.Interfaces {
    public interface Observer {
        void onLoadMemo(List<Memo> memoList);
        void onLoadMemoBody(string body);
        void onNewMemoCreated();
        void onMemoDeleted();
    }
}
