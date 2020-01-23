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
    /// Command that adds NoteContainer to DB
    /// </summary>
    public class NewContainerCommand : ICommand
    {
        /// <summary>
        /// Note View Model
        /// </summary>
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Public constructor of NewContainerCommand
        /// </summary>
        /// <param name="vM">View Model from binding</param>
        public NewContainerCommand(NoteVM vm)
        {
            VM = vm;
        }

        /// <summary>
        /// Checks if this command can execute 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executrion of NewContainerCommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            VM.CreateNewContainer();
            // zrub nowy kontener
        }
    }
}
