using LanguUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MssqlProcExport
{
    public partial class ExportFrm : Form
    {
        public ExportFrm()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            String dir = AppDomain.CurrentDomain.BaseDirectory;
            this.textBox1.AppendText("正在查找过程");
            var dt = await Task.Run(() => { return LoadAllProcNames(); }
            );
            this.textBox1.AppendText("查找到" + dt.Rows.Count + "个存储过程");
            var procs = dt.AsEnumerable().Select(dr => dr.Field<String>(0));
            foreach (var name in procs)
            {
                this.textBox1.AppendText("正在导出" + name);
                String content = await Task.Run(() =>
                {
                    return Export(name);
                });
                this.textBox1.AppendText("正在写入" + name + Environment.NewLine);
                String path = Path.Combine(dir, "script", name + ".sql");
                await Task.Run(() =>
                {
                    WriteFile(path, content);
                });
            }
            this.textBox1.AppendText("OJBK");
        }

        private DataTable LoadAllProcNames()
        {
            String sql = "select name from sys.objects where type='P' and name like 'usp_report%'";
            var dt = SqlHelper.Adapter(sql);
            return dt;

        }

        private String Export(String name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("if exists(select 1 from sys.objects where type='P' and name='{0}'){1}", name, Environment.NewLine);
            sb.AppendFormat("drop proc {0}{1}", name, Environment.NewLine);
            sb.AppendFormat("go{0}", Environment.NewLine);
            var text = SqlHelper.Adapter("sp_helptext " + name);
            text.AsEnumerable().ToList().ForEach(dr =>
            {
                sb.Append(dr.Field<String>(0));
            });
            sb.AppendFormat("{0}go{0}", Environment.NewLine);
            return sb.ToString();
        }

        private void WriteFile(String path, String content)
        {
            var dir = Path.GetDirectoryName(path);
            Directory.CreateDirectory(dir);

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                Byte[] buffer = Encoding.Default.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
            }
        }


    }
}
