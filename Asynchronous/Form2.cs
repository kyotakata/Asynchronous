using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = new System.Threading.Thread(GetData);    // ワーカスレッド
            t.Start();    // ワーカスレッドスタート
        }

        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        private void GetData()
        {
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
            });

        }
    }
}
