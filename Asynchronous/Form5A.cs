using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form5A : Form
    {
        public Form5A()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<List<DTO>> task = GetData();

            // 何か別の処理（この間もタスクは非同期で実行されている）

            var result = await task; //ここでタスクの完了を待つ

            dataGridView1.DataSource = result;
            MessageBox.Show("完了");

        }


        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        private Task<List<DTO>> GetData()// ThreadPoolとは違って、object以外の型を指定できる
        {

            Task<List<DTO>> task = Task.Run(() => {
                var tempresult = new List<DTO>();
                for (int i = 0; i < 5; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    tempresult.Add(new DTO(i.ToString(), "Name" + i));
                }
                return tempresult;
            });
            return task;

        }

    }
}
