using OneNoteClone.Models;
using OneNoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace OneNoteClone.ViewModels
{
    public class NoteVM : INotifyPropertyChanged
    {
        private bool _isModified;

        public bool isModified {
            get { return _isModified; }
            set {
                _isModified = value;
                OnPropertyChanged("isModified");
            }
        }
        /// <summary>
        /// Public list of the Notes Containers
        /// </summary>
        public ObservableCollection<NoteContainer> NoteContainer { get; set; }
        /// <summary>
        /// Private instance of NoteContainer it contains selectedContainer.
        /// </summary>
        private NoteContainer selectedContainer;

        public event PropertyChangedEventHandler PropertyChanged;

        public StartEditCommand StartEditCommand { get; set; }
        /// <summary>
        /// Public instance of NoteContainer it contains selectedContainer.
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
        /// List of Notes 
        /// </summary>
        public ObservableCollection<Note> Notes { get; set; }
        
        public FinishEditCommand FinishEditCommand { get; set; }
        public NewContainerCommand NewContainer { get; set; }

        public NewNoteCommand NewNote { get; set; }

        /// <summary>
        /// Constructor of Note View Model
        /// </summary>
        public NoteVM()
        {
            isModified = false;

            NewContainer = new NewContainerCommand(this);
            NewNote = new NewNoteCommand(this);
            StartEditCommand = new StartEditCommand(this);
            FinishEditCommand = new FinishEditCommand(this);

            NoteContainer = new ObservableCollection<NoteContainer>();
            Notes = new ObservableCollection<Note>();

            LoadNoteContainers();
            LoadNote();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// This method creates new note and adds it to DB.
        /// </summary>
        /// <param name="noteContainerId">Selected noteContainer</param>
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
        /// <summary>
        /// Creates new Container and adds it to DB
        /// </summary>
        public void CreateNewContainer()
        {
            NoteContainer noteContainer = new NoteContainer()
            {
                Name = "New Notebook"
            };

            DataManager.Insert(noteContainer);

            LoadNoteContainers();
        }
        /// <summary>
        /// Loads all Notes COintainers in our DB
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
        /// Get all the notes where id of note container Id is equal to conatainer Id from our DB
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

        public void EditNoteContainer()
        {
            isModified = true;
        }

        public void ChangedNoteContainerName(NoteContainer noteContainer)
        {
            if(noteContainer != null)
            {
                DataManager.Update(noteContainer);
                isModified = false;
                LoadNoteContainers();
            }
        }
    }
}
