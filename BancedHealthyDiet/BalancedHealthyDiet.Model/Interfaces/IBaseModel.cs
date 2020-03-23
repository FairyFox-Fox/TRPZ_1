using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealthyDiet.Model.Interfaces
{
   public interface IBaseModel:INotifyPropertyChanged
    {
        Guid Id { get; }
    }
}
