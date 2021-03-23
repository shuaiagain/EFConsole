using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole3;
using EFConsole3.Entity;

namespace EFConsole3
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        /// <summary>
        /// 初始化器允许我们在目标数据库创建之后运行其他代码
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Context context)
        {
            context.PayWays.AddRange(new List<PayWay>()
            {
                new PayWay{Name = "支付宝"},
                new PayWay{Name = "微信"},
                new PayWay{Name = "QQ红包"}
            });
        }
    }
}
