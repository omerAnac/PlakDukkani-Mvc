using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.ViewModel.AdminViewModels
{
    public class AdminAlbumVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string AlbumArtUrl { get; set; }
        public bool Continued { get; set; } = true;
        public decimal Discount { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        //public AdminArtistVM Artist { get; set; }
        //public AdminGenreVM Genre { get; set; }

    }
}
