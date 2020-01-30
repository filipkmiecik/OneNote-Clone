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
        /// <summary>
        /// Colection of all NoteContainers
        /// </summary>
        public ObservableCollection<NoteContainer> NoteContainer { get; set; }

        /// <summary>
        /// Holds current selectedContainer
        /// </summary>
        private NoteContainer selectedContainer;

        /// <summary>
        /// public getter/setter of selectedContainer
        /// </summary>
        public NoteContainer SelectedContainer
        {
            get { return selectedContainer; }
            set
            {
                selectedContainer = value;
                LoadNote();
            }
        }

        /// <summary>
        /// Holds  current selected Note
        /// </summary>
        private Note _selectedNote;

        /// <summary>
        /// public getter/setter of selectedContainer
        /// </summary>
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set {
                _selectedNote = value;
                selectedNoteChanges(this, new EventArgs());
            }
        }

        /// <summary>
        /// Colection of all Notes
        /// </summary>
        public ObservableCollection<Note> Notes { get; set; }


        public NewContainerCommand NewContainer { get; set; }

        public NewNoteCommand NewNote { get; set; }

        public DeleteNoteContainerCommand DeleteNoteContainerCom { get; set; }

        public event EventHandler selectedNoteChanges;

        /// <summary>
        /// Public constructor of NoteVM
        /// </summary>
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

        /// <summary>
        ///  Method that adds note to db and refresh note block
        /// </summary>
        /// <param name="noteContainerId"></param>
        public void CreateNewNote(int noteContainerId)
        {
            Note note = new Note()
            {
                Title = "Note",
                ContainerId = noteContainerId,
                UpdateDate = DateTime.Now,
                CreationDate = DateTime.Now
            };
            DataManager.Insert(note);
            LoadNote();
        }


        /// <summary>
        /// Method that adds noteContainer to db and refresh note container block
        /// </summary>
        public void CreateNewContainer()
        {
            NoteContainer noteContainer = new NoteContainer()
            {
                Name = "Notebook"
            };

            DataManager.Insert(noteContainer);

            LoadNoteContainers();
        }

        /// <summary>
        /// Loads all NoteContainers
        /// </summary>
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
        /// <summary>
        /// Method that updates Note that is selected
        /// </summary>
        public void UpdateNoteThatIsSelected()
        {
            DataManager.Update(SelectedNote);
        }

        /// <summary>
        /// Method that deletes selected noteContaier
        /// </summary>
        /// <param name="noteContainer"></param>
        public void DeleteNoteContainer(NoteContainer noteContainer)
        {
            if(noteContainer != null)
            {
                DataManager.Delete(noteContainer);
                LoadNoteContainers();
            }
        }
    }
}
