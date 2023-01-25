using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            musicList = GetMusics();
            recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        ObservableCollection<Music> musicList;
        public ObservableCollection<Music> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Music recentMusic;
        public Music RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Music selectedMusic;
        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlayerViewModel(selectedMusic, musicList) ;
                var playerPage = new PlayerPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
            }
        }

        private ObservableCollection<Music> GetMusics()
        {
            return new ObservableCollection<Music> 
            {
                new Music { Title = "Line Without a Hook", Artist = "Ricky Montgomery", Url = "https://od.lk/s/NF8yNjQ3OTIwNDZf/Montgomery%20%20Line%20Without%20a%20Hook%20Official%20Lyric%20Video.mp3", CoverImage = "https://od.lk/s/NF8yNjQ3OTM4NDlf/WhatsApp%20Image%202023-01-07%20at%2022.14.06.jpeg", IsRecent = true},
                new Music { Title = "Sunshine", Artist = "The Panturas", Url = "https://od.lk/s/NF8yNjQ1NzQwMjlf/The%20Panturas%20%20Sunshine%20Official%20Music%20Video.mp3", CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRm-su97lHFGZrbR6BkgL32qbzZBj2f3gKGrFR0Pn66ih01SyGj&usqp=CAU"},
                new Music { Title = "Sesuatu Di Jogja", Artist = "Adhitia Sofyan", Url = "https://od.lk/s/NF8yNjQ1NzQwMjNf/Sesuatu%20Di%20Jogja%20%20Adhitia%20Sofyan%20official%20audio.mp3", CoverImage="https://od.lk/s/NF8yNjQ5NzYwMzdf/1.jpg"},
                new Music { Title = "Cigarettes of ours", Artist = "Ardhito Pramono", Url = "https://od.lk/s/NF8yNjQ1NzQwMTJf/Ardhito%20Pramono%20%20cigarettes%20of%20ours.mp3", CoverImage=""},
                new Music { Title = "Masih Kurang", Artist = "SISITIPSI", Url = "https://od.lk/s/NF8yNjQ1NzQwMjRf/SISITIPSI%20%20Masih%20Kurang%20Official%20Music%20Video.mp3"},
                new Music { Title = "There Is A Light That Never Goes Out", Artist = "The Smith", Url = "https://od.lk/s/NF8yNjQ1NzQwMzdf/The%20Smith%20%20There%20Is%20A%20Light%20That%20Never%20Goes%20Out%20%20%20with%20lyrics.mp3", CoverImage="https://od.lk/s/NF8yNjQ5ODMwNDdf/there%20is%20a%20light%20that%20never%20gose%20out.png"},
                new Music { Title = "Bitterlove", Artist = "Ardhito Pramono", Url = "https://od.lk/s/NF8yNjQ1NzQwMThf/Ardhito%20Pramono%20%20Bitterlove%20Official%20Video.mp3", CoverImage="https://od.lk/s/NF8yNjQ5ODMwNDhf/bitterkove.jpg"},
                new Music { Title = "RUMAH SINGGAH", Artist = "FABIO ASHER", Url = "https://od.lk/s/NF8yNjQ1NzQwMTdf/%20FABIO%20ASHER%20%20RUMAH%20SINGGAH%20OFFICIAL%20MUSIC%20VIDEO.mp3", CoverImage="https://od.lk/s/NF8yNjQ5ODMwNDlf/rumah%20singgah.jpg" }
            };
        }
    }
}
