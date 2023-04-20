using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class DataBase2
    {
        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        internal List<DTO> GetData(System.Threading.CancellationToken token)// ThreadPoolとは違って、object以外の型を指定できる
        {

            //var dto = o as DTO;
            //if (dto == null) { return; }

            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                //トークンでキャンセルされるのを睨んでいる。
                token.ThrowIfCancellationRequested();// このトークンに対して取り消しが要求された場合、OperationCanceledExceptionをスローします。

                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }

    }
}
