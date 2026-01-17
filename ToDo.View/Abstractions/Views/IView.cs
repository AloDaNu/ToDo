using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.View.Abstractions.Views
{
    public interface IView
    {
        event EventHandler OpenEvent;

        event EventHandler ExitEvent;

        void Open();

        void Exit();

        void ShowMessage(string message);
        
        void ShowError(string message);

        void ShowWarning(string message);
    }
}
