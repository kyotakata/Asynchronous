using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous
{
    public partial class Form8 : Form
    {
        System.Threading.CancellationTokenSource _token;
        private DataBase2 _dataBase = new DataBase2();

        public Form8()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)// awaitがある関数はasyncが必要
        {
            try
            {
                _token = new System.Threading.CancellationTokenSource();// ボタン押されたときにnew
                dataGridView1.DataSource = await Task.Run(// awaitを入れることでTask.Runが終わるまで次の処理に進まない
                    () => _dataBase.GetData(_token.Token), _token.Token);// 第二引数でトークンを投げておくと、既にキャンセルされていた場合にTask.Runが動かずにすぐに止まるようになる。
                MessageBox.Show("完了");
            }
            catch (OperationCanceledException o)
            {
                MessageBox.Show("キャンセルされました");
            }
            finally
            {
                _token.Dispose();
                _token = null;
            }

        }


        private void CancelButtun_Click(object sender, EventArgs e)
        {
            _token?.Cancel();
        }
    }
}
