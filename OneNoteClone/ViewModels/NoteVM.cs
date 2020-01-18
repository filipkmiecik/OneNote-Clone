using OneNoteClone.Models;
using OneNoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNoteClone.ViewModels
{
    public class NoteVM
    {
        ObservableCollection<NoteContainer> NoteContainer { get; set; }

        private NoteContainer selectedContainer;

        public NoteContainer SelectedContainer
        {
            get { return selectedContainer; }
            set
            {
                selectedContainer = value;
                // this is where notes will be retrieved like frostmourne from icecrown
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewContainer NewContainer { get; set; }

        public NewNote NewNote { get; set; }

        public NoteVM()
        {
            NewContainer = new NewContainer(this);
            NewNote = new NewNote(this);
        }
    }
}
