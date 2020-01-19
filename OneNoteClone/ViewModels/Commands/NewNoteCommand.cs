using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public NewNoteCommand(NoteVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            NoteContainer selectedNoteCotainer = parameter as NoteContainer;
            if(selectedNoteCotainer != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            NoteContainer selectedNoteCotainer = parameter as NoteContainer;
            VM.CreateNewNote(selectedNoteCotainer.Id);
            //new notes will be born here
        }
    }
}
