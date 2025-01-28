using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    internal interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T data);
        void Update(T data);
        bool DeleteById(int id);
    }
}
