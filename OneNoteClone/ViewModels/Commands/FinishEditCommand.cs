using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class FinishEditCommand : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public FinishEditCommand(NoteVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NoteContainer noteContainer = parameter as NoteContainer;
            VM.ChangedNoteContainerName(noteContainer);
        }
    }
}
