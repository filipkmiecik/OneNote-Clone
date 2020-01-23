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
    /// Command that adds Note to DB
    /// </summary>
    public class NewNoteCommand : ICommand
    {
        /// <summary>
        /// Note View Model
        /// </summary>
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Public constructor of DeleteNoteContainerCommand
        /// </summary>
        /// <param name="vM">View Model from binding</param>
        public NewNoteCommand(NoteVM vm)
        {
            VM = vm;
        }

        /// <summary>
        /// Checks if this method can execute this command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            NoteContainer selectedNoteCotainer = parameter as NoteContainer;
            if(selectedNoteCotainer != null)
                return true;

            return false;
        }

        /// <summary>
        /// Executrion of NewNoteCommand
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
