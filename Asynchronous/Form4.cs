using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();// contextはおまじない
            Task.Run(() => GetData()).ContinueWith(x => 
            {
                // コントロールが作成されたスレッド以外のスレッド上で
                // UIスレッドで作成したコントロールにアクセスできない
                // この中にUIスレッド上で処理したい処理を書く
                dataGridView1.DataSource = x.Result;
                MessageBox.Show("完了");
            }, context);
        }

        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        private List<DTO> GetData()// ThreadPoolとは違って、object以外の型を指定できる
        {
            //var dto = o as DTO;
            //if (dto == null) { return; }

            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }
    }
}
