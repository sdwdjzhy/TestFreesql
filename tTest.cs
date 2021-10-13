using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFreesql
{
    public class tTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppEnum.Type1 Type { get; set; }
    }


    public class tTestVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppEnum.Type2 Type
        {
            get
            {
                if (Name == "成功")
                {
                    return AppEnum.Type2.成功;
                }
                else
                {
                    return AppEnum.Type2.失败;
                }
            }
        }
    }
    public class AppEnum
    {
        public enum Type1
        {
            已成功,
            已失败,
        }
        public enum Type2
        {
            成功,
            失败,
        }
    }
}
