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
                LoadNote();
            }
        }

        private Note _selectedNote;

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set {
                _selectedNote = value;
                selectedNoteChanges(this, new EventArgs());
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewContainerCommand NewContainer { get; set; }

        public NewNoteCommand NewNote { get; set; }

        public DeleteNoteContainerCommand DeleteNoteContainerCom { get; set; }

        public event EventHandler selectedNoteChanges;

        public NoteVM()
        {
            NewContainer = new NewContainerCommand(this);
            NewNote = new NewNoteCommand(this);
            DeleteNoteContainerCom = new DeleteNoteContainerCommand(this);

            NoteContainer = new ObservableCollection<NoteContainer>();
            Notes = new ObservableCollection<Note>();

            LoadNoteContainers();
            LoadNote();
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
            LoadNote();
        }

        public void CreateNewContainer()
        {
            NoteContainer noteContainer = new NoteContainer()
            {
                Name = "New Notebook"
            };

            DataManager.Insert(noteContainer);

            LoadNoteContainers();
        }

        public void LoadNoteContainers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataManager.databaseFile))
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
        public void LoadNote()
        {
            using(SQLiteConnection conn = new SQLiteConnection(DataManager.databaseFile))
            {
                if(SelectedContainer != null)
                {
                    conn.CreateTable<Note>();
                    var notes = conn.Table<Note>().Where(n => n.ContainerId == SelectedContainer.Id).ToList();

                    Notes.Clear();
                    foreach(var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
                
            }
        }

        public void UpdateNoteThatIsSelected()
        {
            DataManager.Update(SelectedNote);
        }

        public void DeleteNoteContainer(NoteContainer noteContainer)
        {
            if(noteContainer != null)
            {
                DataManager.Delete(noteContainer);
                LoadNoteContainers();
            }
            LoadNoteContainers();
        }
    }
}
