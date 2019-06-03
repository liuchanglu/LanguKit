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
            //String sql = "select name from sys.objects where type='P' and name like 'usp_report%'";
            //var dt = SqlHelper.Adapter(sql);
            //return dt;
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            String procs = @"usp_report_cwzt_srtj
usp_report_sszt_dcsstj
usp_report_bqzt_xmfytj
usp_report_bqzt_syltj
usp_report_bqzt_zysyltj
usp_report_mz_mzsygzltj
usp_report_mzzt_sy_cxsybrqk
usp_report_bqzt_rcztj_ks
usp_report_bqzt_zry_15or30
usp_report_bqzt_xsrsmdj
usp_report_bqzt_sybrcx_mzhsz
usp_report_bqzt_cyfstj
usp_report_sszt_ysqsszcx
usp_report_zyzt_zyysyzb
usp_report_zyzt_zyylbb
usp_report_sszt_sstj_ks
usp_report_bqzt_xmfytj_ks
usp_report_zyzt_bfzb
usp_report_cwzt_srrb_wjs
usp_report_cwzt_fplyhx
usp_report_cwzt_fpsyqkcx
usp_report_cwzt_czyfp_syzstj
usp_report_cwzt_gzltj_cwczy
usp_report_ypzt_mzfyygzltj
usp_report_ypzt_yfyprktj
usp_report_ypzt_yfksfytj
usp_report_ypzt_yfzyfytj
usp_report_ypzt_yfmzfytj
usp_report_ypzt_yfypdrtj
usp_report_ypzt_yfypdctj
usp_report_ypzt_yfyppdtj
usp_report_ypzt_yfbsbytj
usp_report_ypzt_yfyptktj
usp_report_ypzt_yfyptjtj
usp_report_ypzt_ykyprktj
usp_report_ypzt_ykypthtj
usp_report_ypzt_ykypcktj
usp_report_ypzt_ykyptktj
usp_report_ypzt_ykyppdtj
usp_report_ypzt_ykbsbytj
usp_report_ypzt_ykyptjtj
usp_report_ypzt_ykypdrtj
usp_report_ypzt_ykypdctj
usp_report_ypzt_ykksfytj
usp_report_ypzt_yktzmx_jjje
usp_report_ypzt_yftzmx_jjje
usp_report_sszt_ssfytj
usp_report_sszt_ssfymxcx
usp_report_zyzt_zyzbdb_tb
usp_report_sszt_sj_ssls
usp_report_cwzt_cwsrzzl
usp_report_sszt_ssbrzyqk
usp_report_zyzt_cqzhbrlb
usp_report_sszt_sshsfx
usp_report_ypzt_ykgyszb
usp_report_zyzt_zyxmpm
usp_report_cwzt_zysrybb
usp_report_cwzt_zysrybb
usp_report_cwzt_mzrbb
usp_report_cwzt_mzkssrtj_wxg
usp_report_cwzt_zykssrtj_wxg
usp_report_cwzt_zycybrfyzk_ex2_yj
usp_report_cwzt_clfytj
usp_report_cwzt_ylxmgzltj
usp_report_cwzt_ylxmtj
usp_report_cwzt_mjzzyrc
usp_report_cwzt_ybhc
usp_report_zyzt_hzqk
usp_report_zyzt_zybrblcx
usp_report_zyzt_zybrtscx
usp_report_zyzt_ksybjftj
usp_report_zyzt_eczy
usp_report_zyzt_zycfy
usp_report_zyzt_zyecsstj
usp_report_ypzt_ykypckmxhztj
usp_report_ypzt_ykyptkmxhztj
usp_report_ypzt_ykyprkmxhztj
usp_report_ypzt_ykypthmxhztj
usp_report_ypzt_ykwgrkhztj
usp_report_bqzt_qfhztj
usp_report_ypzt_jbywsyltj
usp_report_ypzt_jyzbtj
usp_report_ypzt_zyjyzbtj_js
usp_report_ypzt_jbywsyqk_kdks
usp_report_ypzt_tsypxhtj_fy
usp_report_ypzt_zxyfyzgzltj
usp_report_ypzt_jpyftdtj
usp_report_ypzt_jpyfgzltj
usp_report_ypzt_tsypzxhtj
usp_report_ypzt_tsypsybl_sf
usp_report_ypzt_tsypzcdjb
usp_report_ypzt_yfypxhtj_sf
usp_report_ypzt_tsypdjb
usp_report_ypzt_ypjxc_sjd
usp_report_ypzt_yfgzypxhtj
usp_report_ypzt_gjysyqktj
usp_report_ypzt_kzlorcwyyypxhjetj
usp_report_cwzt_mb_mjzysgzltj
usp_report_mzzt_ghrcbb_ys
usp_report_cwzt_rcbb_2_mb
usp_report_cwzt_mb_zgfgmztjb
usp_report_mzzt_ghrcbb_zj
usp_report_ypzt_mb_rjbqsjltj
usp_report_mzzt_mb_rcbb_anl
usp_report_cwzt_qyjcftj
usp_report_ypzt_tsypzxhtj
usp_report_ypzt_tsypzcdjb_fy
usp_report_ypzt_yktzmx_jjje
usp_report_ypzt_yftzmx_jjje
usp_report_ypzt_ypjxc_sjd_dyplx
usp_report_ypzt_mzzyzsj
usp_report_ypzt_yftsypyltj
usp_report_zyzt_zygrskb
usp_report_cwzt_yyztqk
usp_report_mzzt_mjzjxkhy
usp_report_mzzt_ghqktj_aczy
usp_report_zyzt_rycygzl
usp_report_zyzt_zyczygzl
usp_report_zyzt_kssyjsyqk
usp_report_zyzt_kssyjsyqk_mx
usp_report_cwzt_zzj_czcgmx
usp_report_cwzt_mzzzghcx
usp_report_ypzt_yfypzlyhoryxq
usp_report_mzzt_yybb_hzb1
usp_report_ypzt_mb_yyly
usp_report_mzzt_yybb_aks
usp_report_mzzt_zzjgzltj_mb
usp_report_mzzt_mzfytj
usp_report_mzzt_mzfytj
usp_report_mzzt_zfy_ybfl
usp_report_mzzt_yy_mzhyfx
usp_report_mzzt_mjzrc
usp_report_cwzt_yjj_xjzhtj
usp_report_cwzt_yjj_czjl
usp_report_cwzt_gzltj_zzjczy
usp_report_mzzt_ghrcbb
usp_report_cwzt_rcbb_2_mb
usp_report_cwzt_rcbb_2_mb
usp_report_mzzt_rcrbb
usp_report_mzzt_qfbrtj
usp_report_yfbjzt_nzzxjgsxx
usp_report_yfbjzt_gxytnbxx
usp_report_yfbjzt_qybrzdxx
usp_report_cwzt_mb_ghwsfmx
usp_report_cwzt_ghyzbb_mb
usp_report_mzzt_sqdsl_mb
usp_report_mzzt_mzbzfytj_mb
usp_report_ypzt_mb_qyys_kjszbsyl
usp_report_mzzt_decfcx
usp_report_ypzt_mz_jyzb_ksys
usp_report_cwzt_mb_cfghtj
usp_report_mzzt_mb_azdtjyp
usp_report_ypzt_mz_jyzb
usp_report_mzzt_zdqktj_hz
usp_report_mzzt_zdqktj
usp_report_mzzt_hzjzcstj
usp_report_mzzt_hzjzxxcx
usp_report_mzzt_ghjzfx
usp_report_mzzt_dcfcx
usp_report_mzzt_mzysjyzb
usp_report_ypzt_mb_kjszb
usp_report_ypzt_mb_kjssyl_1
usp_report_ypzt_mz_jyzb_ksys
usp_report_mzzt_mzbzfytj
usp_report_mzzt_ypyl_top
usp_report_mzzt_cyyl_top
usp_report_cwzt_mb_scjzys
usp_report_cwzt_mzgh_ghcx
usp_report_mzzt_mjzjxkhy
usp_report_ypzt_mjzcfjetj
usp_report_ypzt_mzksypxhtj
usp_report_ypzt_mjzzsjsyqktj
usp_report_ypzt_mzzyzsj
usp_report_ypzt_mjzkscffltj
usp_report_ypzt_mjzjmsysyqktj
usp_report_ypzt_qyypxhfltj
usp_report_ypzt_ylqkbryzxx
usp_report_ypzt_mycybrxxtj
usp_report_cwzt_ghscgyptj
usp_report_cwzt_yftbhzb
usp_report_cwzt_ckfy_yf
usp_report_cwzt_ckfy_yf_tjq
usp_report_cwzt_yfykpdb
usp_report_cwzt_ykckbb
usp_report_cwzt_ykrkfpmx
usp_report_cwzt_yfyksycbb
usp_report_cwzt_yfykpdykb
usp_report_cwzt_yfykksfy
usp_report_cwzt_yfykksfy_ks
usp_report_cwzt_yfyktjykb
usp_report_cwzt_yfrktkbb
usp_report_cwzt_ykjxcyb_jj
usp_report_cwzt_yfjxcyb_jj
usp_report_cwzt_zycybrfyzk_ex4
usp_report_zyzt_sssqjb
usp_report_mzzt_zycfs
usp_report_cwzt_sryjjrbb
usp_report_cwzt_czydz
usp_report_cwzt_sktjb_fzq_yb
usp_report_cwzt_sktjb_fzq
usp_report_ypzt_gyskccx_gys
usp_report_ypzt_gyskccx
usp_report_ypzt_tjdjmxhz
usp_report_cwzt_mzyjjye
usp_report_ypzt_ykypzzl
usp_report_cwzt_cqwjs
usp_report_cwzt_qfhztj
usp_report_zyzt_cyrcalxtj
usp_report_cwzt_xmfytj
usp_report_cwzt_jzsrtj
usp_report_ypzt_sycgje_aylj
usp_report_ypzt_sycgje_ay
usp_report_ypzt_ykcgtwsypgyshztj
usp_report_ypzt_ykcgylsjgyshztj
usp_report_ypzt_ykcgypgystj
usp_report_ypzt_skbb
usp_report_ypzt_dlcgyptj
usp_report_ypzt_ykcgypgyshztj
usp_report_ypzt_mjzcffltj
usp_report_cwzt_mb_mjzysgzltj_ksyscfz
usp_report_mzzt_ghmjztj_fb
usp_report_mzzt_ghrs
usp_report_mzzt_ghrc_sjd
usp_report_mzzt_jyzbtj_zy
usp_report_ypzt_yfxsqk
usp_report_ypzt_yfypxhph
usp_report_ypzt_yfypxhtj_tjq
usp_report_ypzt_ypflxhjeph
usp_report_ypzt_ksypmxsyqktj
usp_report_ypzt_ypxhph_sf
usp_report_ypzt_yfypxhzzl_sf
usp_report_ypzt_qyypsylqktj
usp_report_ypzt_ypxhjeph_sf
usp_report_ypzt_ypflxhjetj
usp_report_ypzt_ypxhtj
usp_report_ypzt_myyyyptj
usp_report_ypzt_ypzdwhqhb
usp_report_ypzt_xjypzdqhb
usp_report_ypzt_mjkjyjmsysyqktj
usp_report_ypzt_zyjpkjywcx
usp_report_ypzt_mjzkjywtj
usp_report_ypzt_mjzkjywsylph
usp_report_ypzt_kjywxhjeph_sf
usp_report_ypzt_kjywxhslph_sf
usp_report_ypzt_kjywcydycx
usp_report_ypzt_kjywsyjeph
usp_report_ypzt_zyhzkjywsyl
usp_report_ypzt_kjyzbtj
usp_report_ypzt_kjywsjl
usp_report_ypzt_xzjkjywsjl
usp_report_ypzt_tsjkjywsjl
usp_report_ypzt_kjywlhyytj
usp_report_ypzt_ylqkssyfykjyw
usp_report_ypzt_kjywxhph
usp_report_ypzt_kssqdtj_tsjrc
usp_report_ypzt_kssqdtj_tsjqd
usp_report_ypzt_ssyfkjs
usp_report_ypzt_yf_kssxhtj
usp_report_ypzt_mzkjs_ksssyl_rcjpzs
usp_report_ypzt_kjs_kjywsyl
usp_report_ypzt_kssqdtj_tsj
usp_report_ypzt_kssqdtj_ayp
usp_report_ypzt_kssqdtj
usp_report_ypzt_zyhzkjywjmsyzb
usp_report_zyzt_cyrcalxtj
";
            procs.Split('\n').ToList().ForEach(p =>
            {
                dt.Rows.Add(new object[] { p.Replace("\r","") });
            });
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
