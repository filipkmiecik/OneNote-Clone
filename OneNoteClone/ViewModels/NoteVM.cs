using OneNoteClone.Models;
using OneNoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OneNoteClone.ViewModels
{
    public class NoteVM
    {
        public ObservableCollection<NoteContainer> NoteContainer { get; set; }

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

            NoteContainer = new ObservableCollection<NoteContainer>();
            Notes = new ObservableCollection<Note>();

            loadNoteContainers();
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

        public void loadNoteContainers()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DataManager.databaseFile))
            {
                conn.CreateTable<NoteContainer>();
                var noteContainer = conn.Table<NoteContainer>().ToList();

                NoteContainer.Clear();
                foreach(var container in noteContainer)
                {
                    NoteContainer.Add(container);
                }
            }
        }
        /// <summary>
        /// Get all the notes where id of note container Id is equal to conatainer Id
        /// </summary>
        public void loadNote()
        {
            using(SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(DataManager.databaseFile))
            {
                if(SelectedContainer != null)
                {
                    var notes = connection.Table<Note>().Where(n => n.ContainerId == SelectedContainer.Id).ToList();

                    Notes.Clear();
                    foreach(var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
                
            }
        }
    }
}
