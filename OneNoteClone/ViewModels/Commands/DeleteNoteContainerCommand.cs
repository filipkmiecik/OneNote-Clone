using OneNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneNoteClone.ViewModels.Commands
{
    public class DeleteNoteContainerCommand : ICommand
    {

        public NoteVM Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public DeleteNoteContainerCommand(NoteVM vM)
        {
            Vm = vM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NoteContainer noteCotainer = parameter as NoteContainer;


            Vm.DeleteNoteContainer(noteCotainer);
            Vm.LoadNoteContainers();
        }
    }
}
