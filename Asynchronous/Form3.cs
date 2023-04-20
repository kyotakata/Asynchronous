using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(GetData);// 今回は第二引数で第一引数の引数(パラメータ)を指定しない
        }

        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        private void GetData(object o)
        {
            //var dto = o as DTO;
            //if (dto == null) { return; }

            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            // コントロールが作成されたスレッド以外のスレッド上で
            // UIスレッドで作成したコントロールにアクセスできない
            // ので、以下をおまじない的に書く
            this.Invoke((Action)delegate ()
            {
                dataGridView1.DataSource = result;
                MessageBox.Show("完了");
            });

        }
    }
}
