using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class DataBase
    {
        private bool _isCancel = false;

        internal bool IsCancel 
        { 
            get 
            { 
                return _isCancel; 
            }
        }
        /// <summary>
        /// ワーカスレッドで実行する非同期な処理
        /// </summary>
        internal List<DTO> GetData()// ThreadPoolとは違って、object以外の型を指定できる
        {
            _isCancel = false;

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

        internal void Cancel()
        {
            _isCancel = true;
        }

    }
}
