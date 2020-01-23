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
        /// <summary>
        /// Instance of View Model
        /// </summary>
        public NoteVM VM { get; set; }

        /// <summary>
        /// Event Handleler
        /// </summary>
        public event EventHandler CanExecuteChanged;

 
        /// <summary>
        /// Constructor of NewContainerCommand
        /// </summary>
        /// <param name="vm"></param>
        public NewContainerCommand(NoteVM vm)
        {
            VM = vm;
        }

        /// <summary>
        /// this method check if you can extute NewContainerCommand
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execution of NewContainerCommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            VM.CreateNewContainer();
            // zrub nowy kontener
        }
    }
}
