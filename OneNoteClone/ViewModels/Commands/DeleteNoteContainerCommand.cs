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
    /// Command that delet NoteContainer
    /// </summary>
    public class DeleteNoteContainerCommand : ICommand
    {
        /// <summary>
        /// Note View Model
        /// </summary>
        public NoteVM Vm { get; set; }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Public constructor of DeleteNoteContainerCommand
        /// </summary>
        /// <param name="vM">View Model from binding</param>
        public DeleteNoteContainerCommand(NoteVM vM)
        {
            Vm = vM;
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
        /// Executrion of DeleteNoteContainerCommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            NoteContainer noteCotainer = parameter as NoteContainer;


            Vm.DeleteNoteContainer(noteCotainer);
            Vm.LoadNoteContainers();
        }
    }
}
