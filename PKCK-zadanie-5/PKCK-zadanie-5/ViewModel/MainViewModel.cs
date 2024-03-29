﻿using DataModel;
using PKCK_zadanie_5.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using XmlService;

namespace PKCK_zadanie_5.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MusicXmlReader xmlReader = new MusicXmlReader();
        public ObservableCollection<Cd> Cds { get; set; }
        public ObservableCollection<Musician> Musicians { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<Distributor> Distributors { get; set; }

        public ICommand EditButton { get; set; }
        public ICommand AddButton { get; set; }
        public ICommand DeleteButton { get; set; }
        public ICommand SaveButton { get; set; }
        public DataContext dataContext { get; set; }
        public Cd SelectedCd { get; set; }
        public MainViewModel()
        {
            dataContext = xmlReader.Read(@"..\..\..\..\resources\music.xml");
            Cds = new ObservableCollection<Cd>(dataContext.Cds);
            Musicians = new ObservableCollection<Musician>(dataContext.Musicians.Musicians.Values);
            Genres = new ObservableCollection<Genre>(dataContext.Genres.Genres.Values);
            Languages = new ObservableCollection<Language>(dataContext.Languages.Languages.Values);
            Distributors = new ObservableCollection<Distributor>(dataContext.Distributors.Distributors.Values);
            EditButton = new RelayCommand(o => ButtonEdit());
            AddButton = new RelayCommand(o => ButtonAdd());
            DeleteButton = new RelayCommand(o => Delete());
            SaveButton = new RelayCommand(o => SaveData());

        }

        private void Delete()
        {
            dataContext.Cds.Remove(SelectedCd);
            Cds.Remove(SelectedCd);
        }

        private void ButtonAdd()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.DataContext = new AddViewModel(Cds, dataContext);
            addWindow.Show();
        }

        private void ButtonEdit()
        {
            EditWindow editWindow = new EditWindow();
            editWindow.DataContext = new EditViewModel(SelectedCd, Musicians, Languages, Distributors, Genres);
            editWindow.Show();
        }
        private void SaveData()
        {
            string startingPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\resources"));
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                InitialDirectory = startingPath,
                FileName = "music_saved",
                Filter = "XML files (*.xml)|*.xml",
                RestoreDirectory = true
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFilePath = fileDialog.FileName;
                try
                {
                    MusicXmlWriter.Serialize(dataContext, saveFilePath);
                }
                catch (XsdValidationException e)
                {
                    MessageBox.Show(e.Message, "XSD validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
