using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form6 : Form
    {
        private bool _isCancel = false;
        public Form6()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)// awaitがある関数はasyncが必要
        {
            _isCancel= false;
            dataGridView1.DataSource = await Task.Run(() => GetData());// awaitを入れることでTask.Runが終わるまで次の処理に進まない

            if (_isCancel)
            {
                MessageBox.Show("キャンセルされました");
            }

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
                if (_isCancel)
                {
                    return null;
                }

                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }

        private void CancelButtun_Click(object sender, EventArgs e)
        {
            _isCancel = true;
        }
    }
}
