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

        public NewContainerCommand NewContainer { get; set; }

        public NewNoteCommand NewNote { get; set; }

        public NoteVM()
        {
            NewContainer = new NewContainerCommand(this);
            NewNote = new NewNoteCommand(this);
        }

        public void CreateNewNote(int noteContainerId)
        {
            Note note = new Note()
            {
                Title = "New Note",
                ContainerId = noteContainerId,
                UpdateDate = DateTime.Now,
                CreationDate = DateTime.Now
            };
            DataManager.Insert(note);
        }

        public void CreateNewContainer()
        {
            NoteContainer noteContainer = new NoteContainer()
            {
                Name = "New notebook"
            };

            DataManager.Insert(noteContainer);
        }


    }
}
