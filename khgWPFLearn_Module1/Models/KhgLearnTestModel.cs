using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace khgWPFLearn_Module1.Models
{
    public class KhgLearnTestModel : BindableBase
    {
        public string TestText { get; set; }

        public KhgLearnTestModel()
        {
            TestText = "表示テスト";
        }
    }
}
