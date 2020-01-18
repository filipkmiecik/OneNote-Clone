using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class NewContainer : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public NewContainer(NoteVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // zrub nowy kontener
        }
    }
}
