using System.ComponentModel.DataAnnotations;

namespace Sube2.KitapMVC.Models
{
    public class Kitap : Object
    {
        public int KitapId { get; set; }

        [Display(Name = "Kitap Adı")]
        public string Ad { get; set; }

        [Display(Name = "Yazar")]
        public string Yazar { get; set; }

        [Display(Name = "Tür")]
        public string Tur { get; set; }

        [Display(Name = "Fiyat (₺)")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Stok Adedi")]
        public int Stok { get; set; }

        [Display(Name = "Yayın Yılı")]
        public int YayinYili { get; set; }

        public override string ToString()
        {
            return $"Ad:{this.Ad} Yazar:{this.Yazar}";
        }
    }
}
