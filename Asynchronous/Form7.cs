using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form7 : Form
    {
        private DataBase _dataBase = new DataBase();

        public Form7()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)// awaitがある関数はasyncが必要
        {
            dataGridView1.DataSource = await Task.Run(() => _dataBase.GetData());// awaitを入れることでTask.Runが終わるまで次の処理に進まない

            if (_dataBase.IsCancel)
            {
                MessageBox.Show("キャンセルされました");
            }
            else
            {
                MessageBox.Show("完了");
            }
        }


        private void CancelButtun_Click(object sender, EventArgs e)
        {
            _dataBase.Cancel();
        }
    }
}
