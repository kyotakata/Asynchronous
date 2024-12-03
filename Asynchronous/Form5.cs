using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)// awaitがある関数はasyncが必要
        {
            dataGridView1.DataSource = await Task.Run(() => GetData());// awaitを入れることでTask.Runが終わるまで次の処理に進まない
            MessageBox.Show("完了");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
