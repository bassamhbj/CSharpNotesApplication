using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_v1 {
    class Memo {
        DateTime date;
        string title;
        string body;

        public Memo() { }

        public Memo(DateTime date, string title, string body) {
            this.date = date;
            this.title = title;
            this.body = body;
        }

        public DateTime Date {
            set { date = value; }
            get { return date; }
        }

        public string Title {
            set { title = value; }
            get { return title; }
        }

        public string Body {
            set { body = value; }
            get { return body; }
        }
    }
}
