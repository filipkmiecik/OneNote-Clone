using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class NewContainerCommand : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

 

        public NewContainerCommand(NoteVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.CreateNewContainer();
            // zrub nowy kontener
        }
    }
}
