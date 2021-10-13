using FreeSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFreesql
{
    public partial class Form1 : Form
    {
        IFreeSql Fsql;
        public Form1()
        {
            InitializeComponent();

            var connectionString = "data source=(local);initial catalog=TestFreesql;user id=sa;password=123456;MultipleActiveResultSets=True;Min pool size=1";
            Fsql = new FreeSqlBuilder()
                .UseConnectionString(DataType.SqlServer, connectionString)
                .UseAutoSyncStructure(false)
                .Build();
            Fsql.Aop.CurdAfter += (s, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(e.Sql);
                Console.WriteLine("".PadRight(20, '*'));

                Console.ResetColor();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = Fsql.Select<tTest>().ToList(i => new tTestVM
            {
                Id = i.Id,
                Name = i.Name,
            });

            MessageBox.Show("Test");
        }
    }
}
