using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    /// <summary>
    /// Command to create New Note
    /// </summary>
    public class NewNoteCommand : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Constuctor of NewNoteCommand
        /// </summary>
        /// <param name="vm"></param>
        public NewNoteCommand(NoteVM vm)
        {
            VM = vm;
        }
        /// <summary>
        /// Determines if canExecute NewNodeCommand
        /// </summary>
        /// <param name="parameter">Instace of NoteContainer</param>
        /// <returns>True if </returns>
        public bool CanExecute(object parameter)
        {
            NoteContainer selectedNoteCotainer = parameter as NoteContainer;
            if(selectedNoteCotainer != null)
                return true;

            return false;
        }
        /// <summary>
        /// Execution of NewNote command pattern
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            NoteContainer selectedNoteCotainer = parameter as NoteContainer;
            VM.CreateNewNote(selectedNoteCotainer.Id);
            //new notes will be born here
        }
    }
}
