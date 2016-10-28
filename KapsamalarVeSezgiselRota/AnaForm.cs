using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KapsamalarVeSezgiselRota
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        public DataGridView matris = new DataGridView();  //Matris icin datagridview olusturuldu.

        private void AnaForm_Load(object sender, EventArgs e)
        {
            btn_islem_basla.Enabled = false;
            btn_ilerle.Enabled = false;
            this.AcceptButton = btn_olustur;          
        }

        /*Olusturulan matrisin butun degerleri 0 a esitleniyor.*/
        public void ilk_deger_ata()
        {
            int satir = matris.Rows.Count - 2; //Agirlik sutununu da doldurmamasi icin -2 yaziyoruz.
            int sutun = matris.Columns.Count - 1;

            /*Deger atanacak satir ve sutunlar 0 ile dolduruluyor.*/
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    matris.Rows[i].Cells[j].Value = 0;
                }
            }


        }

        /*Satır ve sutunların ağırlıklarının hesaplandiği fonksiyon*/
        public void agirlik_hesapla()
        {
            int satir = matris.Rows.Count - 1; //satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //sutun sayisi tutulan degsiken tanimlandi.

            int[] sutun_dizisi = new int[sutun]; //Sutunlardaki 1 lerin tutulacagi dizi tanımlandı.

            /*-------------Sutunlardaki toplam 1 leri bulmak icin (sutun_hesapla())--------------*/
            int toplam = 0;
            int i = 0;
            int j = 0;

            for (i = 0; i < sutun; i++)
            {
                for (j = 0; j < satir; j++)
                {
                    /*j.satir i.sutun diyerek kolon tarama gerçeklestirildi.*/
                    if (Convert.ToInt32(matris.Rows[j].Cells[i].Value) == 1) //j.satir i.sutun daki kutunun degeri 1 e esitmi kontrol edildi.
                    {
                        toplam++;  //Toplam 1 arttirildi.
                        matris.Rows[j].Cells[i].Style = new DataGridViewCellStyle { BackColor = Color.Blue, ForeColor = Color.White }; //Degeri 1 olan kolonlara yeni stil eklendi.
                    }
                }
                sutun_dizisi[i] = toplam; //Her sutunun degeri "sutun_dizisi" dizisine atildi.
                matris.Rows[satir].Cells[i].ReadOnly = true; //1 lerin sayisinin yazildigi sutun sadece okunabilir yapildi.
                matris.Rows[satir].Cells[i].Style = new DataGridViewCellStyle { BackColor = Color.Red, ForeColor = Color.White }; //1 lerin yazıldıgı kolona yeni stil eklendi.
                matris.Rows[satir].Cells[i].Value = toplam;  //1 lerin sayisi en alt sutunlara yazildi.
                toplam = 0; //Toplam degiskeni diger degerlere bakabilmek icin sifirlandi.
            }

            /*------------ Agırlık hesaplama || Satırların agırlinin hesaplanmasi -------------*/


            int satir_sayisi = matris.Rows.Count - 1; //Matris'deki satır sayısı degiskene atandi.
            float degerler_toplami = 0;               //Kolonlardaki 1 sayisininin toplamini tutacak degisken tanimlandi.

            /*Soldan saga dogru her satır , sutun sutun taranıyor.*/
            for (int a = 0; a < satir; a++)
            {
                for (int b = 0; b < sutun; b++)
                {
                    if (Convert.ToInt32(matris.Rows[a].Cells[b].Value) == 1) //a.satır b.sutun daki deger 1 e esitmi kontrol ediliyor.
                    {
                        float sutun_degeri = sutun_dizisi[b]; //Kolondaki 1 lerin toplam sayisi degiskene ataniyor.
                        degerler_toplami = degerler_toplami + (1 / sutun_degeri); //Degerler toplaniyor.
                    }
                }
                degerler_toplami = degerler_toplami * satir_sayisi; //Toplanan degerler satir sayisi ile carpiliyor.

                matris.Rows[a].Cells["agirlik"].Style = new DataGridViewCellStyle { BackColor = Color.Red, ForeColor = Color.White };
                matris.Rows[a].Cells["agirlik"].Value = degerler_toplami; //Bulunan agırlık degeri "Agırlık" kolonuna yazdiriliyor.
                degerler_toplami = 0; //Toplanan deger her seferinde bir sonraki asama icin sifirlaniyor.
            }

        }

        public void mutlak_satir_sutun_bul_ve_sil()
        {
            int satir = matris.Rows.Count - 1; //Satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //Sutun sayisi tutulan degisken tanimlandi.

            int mutlak_satir = 0;  //Mutlak satir degiskeni olusturuluyor.
            int mutlak_sutun = 0;  //Mutlak sutun degiskeni olusturuluyor.

            int bulundu = 0; //Mutlak satır oldugunu bulup bulmadigimizi kontrol etmek icin bulundu degiskeni olusturuluyor.

            /*Agırlıkları 1 olan sutunlar bulunuyor.*/
            for (int i = 0; i < sutun; i++)
            {
                if (Convert.ToInt32(matris.Rows[satir].Cells[i].Value) == 1) //Sutunun degeri 1'e esitmi kontrol ediliyor.
                {
                    mutlak_sutun = i; //Mutlak sutunun degeri i olarak degistiriliyor.
                    bulundu++; //Bulundu degiskeni kontrol icin degeri arttirliyor.
                    break;
                }
            }
            if (bulundu == 0) //Mutlak sutun bulunamadiysa fonksiyondan cikiliyor.
            {
                MessageBox.Show("Mutlak sutun bulunamadi");
                return; //Fonksiyondan cikiliyor.
            }

            /*Mutlak sutunun 1 oldugu satir araniyor.*/
            for (int i = 0; i < satir; i++)
            {
                if (Convert.ToInt32(matris.Rows[i].Cells[mutlak_satir].Value) == 1) //Satir ve mutlak_sutun'un degeri 1'e esitmi kontrol ediliyor.
                {
                    mutlak_satir = i; //Mutlak satirin degeri i olarak degistiriliyor.
                    break; 
                }
            }

            string sutun_adi = matris.Columns[mutlak_sutun].Name; //Mutlak sutunun adi bulunuyor.
            matris.Columns.Remove(sutun_adi); //Mutlak sutun siliniyor.
            matris.Rows.Remove(matris.Rows[mutlak_satir]); //Mutlak satir siliniyor.

        }


        private void btn_olustur_Click(object sender, EventArgs e)
        {

            /*Kac satır ve sutun olusturulacagı degiskenlere atandı.*/
            int satir = Convert.ToInt32(txt_satir.Text);
            int sutun = Convert.ToInt32(txt_sutun.Text);

            /*Matrise "sutun" degiskeni kadar sutun ekleniyor.*/
            for (int i = 0; i < sutun; i++)
            {
                matris.Columns.Add("x" + i.ToString() + "", "x" + i.ToString() + ""); //Sutun ekleme.
                matris.Columns[i].Width = 30; //Eklenen sütunun genisliğini ayarlandı.
                matris.Columns[i].Resizable = DataGridViewTriState.False; //Kolonların genişliği değiştirilemez olarak ayarlandi.
            }

            matris.Columns.Add("agirlik", "Ağırlık"); //Ağırlık sütununu ekleme.
            matris.Columns["agirlik"].ReadOnly = true; //Ağırlık sütunu üzerinde değişiklik yapma engellendi.
            matris.Columns["agirlik"].Width = 50; //Ağırlık sütununun genişliği ayarlandı.
            matris.Columns["agirlik"].Resizable = DataGridViewTriState.False; //Ağırlık sütunun genişliği değiştilemez olarak ayarlandi.

            /*Matrise "satir" degiskeni kadar satır ekleniyor.*/
            for (int j = 0; j < satir; j++)
            {
                matris.Rows.Add(); //Satir ekleme.
            }
            matris.Rows.Add(); //Ağırlık satiri ekleniyor.

            ilk_deger_ata(); //Matris'in tüm satır ve sütunlarına ilk degerleri atanıyor.

            matris.AllowUserToAddRows = false;
            matris.Size = new Size((36 * sutun) + 80, (36 * satir));  //Matris'in boyutu belirleniyor.
            matris.Location = new Point(20, 80);          //Matris'in lokasyonu belirleniyor.
            matris.Visible = true;                        //Matris'in görünürlüğü aciliyor.
            this.Controls.Add(matris);                    //Matris pencereye ekleniyor.

            txt_satir.Enabled = false;                    //Satır girisi kapatiliyor.
            txt_sutun.Enabled = false;                    //Sutun girisi kapatiliyor.
            btn_olustur.Enabled = false;                  //Olustur butonu kapatiliyor.
            btn_islem_basla.Enabled = true;               //Isleme basla butonu aciliyor.

        }

        /*Islemleri baslatan button*/
        private void btn_islem_basla_Click(object sender, EventArgs e)
        {
            agirlik_hesapla(); //Satır sutun agirliklari hesaplandi.

            btn_islem_basla.Enabled = false; //Isleme baslama butonu kapandi.
            btn_ilerle.Enabled = true;  //Ilerleme butonu acildi.
        }

        /*En kucuk agirlikli satirin sirasi ve degerinin tutulacagi bir struct olusturuldu.*/
        public struct enKucuk
        {
            public float deger;
            public int sira;
        };

        /*Rota algoritmasi ile silme fonksiyonu*/
        public void rota_algoritmasi_ile_sil()
        {
            int satir_sayisi = matris.Rows.Count - 1;
            float[] agirlik_degerleri = new float[satir_sayisi];

            enKucuk en_kucuk; //enKucuk struct'indan bir nesne olusturuluyor.

            /*Ilk eleman en kucuk olarak ataniyor.*/
            en_kucuk.deger = (float)matris.Rows[0].Cells["agirlik"].Value;
            en_kucuk.sira = 0;


            for (int i = 0; i < satir_sayisi; i++)
            {
                agirlik_degerleri[i] = (float)matris.Rows[i].Cells["agirlik"].Value;/*Matrisdeki onceden hesaplanan agirlik degerleri diziye ataniyor.*/

                if (agirlik_degerleri[i] < en_kucuk.deger) /*Dizinin o anki degeri enkucuk degerden kucukmu diye kontrol ediliyor.*/
                {
                    en_kucuk.deger = agirlik_degerleri[i];  //en_kucuk struct'inin degerine bulunan kucuk deger ataniyor.
                    en_kucuk.sira = i;  //en_kucuk struct'inin sirasina bulunan en kucuk degerin sirasi ataniyor.
                }

            }
            DataGridViewRow silinecek_satir = matris.Rows[en_kucuk.sira]; //Silinecek satir belirleniyor.
            matris.Rows.Remove(silinecek_satir); //Belirlenen en kucuk satir siliniyor.
            lbl_durum.Text += "\nRota algoritmasına gore " + en_kucuk.sira + ". satir en dusuk agirlik degerine sahip oldugu icin silindi.";
        }



        public void satir_kapsamalarina_gore_sil()
        {
            int satir = matris.Rows.Count - 1; //satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //sutun sayisi tanimlandi.
            int uyusmayan_bolum = 0;

            /* (i,j) = 0,0 | 0,1 | 0,2
               (k,j) = 1,0 | 1,1 | 1,2  
               
               (i,j) = 0,0 | 0,1 | 0,2
               (k,j= = 2,0 | 2,1 | 2,2  
               
             Seklinde karsilastirma yapiliyor.*/
            for (int i = 0; i < satir; i++)
            {
                for (int j = i + 1; j < satir; j++)
                {
                    for (int k = 0; k < sutun; k++)
                    {
                        MessageBox.Show("i,k(" + i + " , " + k + ") = " + matris.Rows[i].Cells[k].Value + "\n" + " j,k(" + j + " ," + k + ") =" + matris.Rows[j].Cells[k].Value);
                        /*Kapsayacak satirin sutununun degeri 1 mi ve Kapsanan satir'in sutunu ile degeri ayni mi kontrol ediliyor.*/
                        if (Convert.ToInt32(matris.Rows[i].Cells[k].Value) == 1 && Convert.ToInt32(matris.Rows[i].Cells[k].Value) == Convert.ToInt32(matris.Rows[j].Cells[k].Value))
                        {
                            MessageBox.Show(matris.Rows[i].Cells[k].Value + "\n" + matris.Rows[j].Cells[k].Value + " ESITTTTTTT");
                        }
                        else if (Convert.ToInt32(matris.Rows[j].Cells[k].Value) == 1)
                        {
                            uyusmayan_bolum++;
                        }
                    }
                    if (uyusmayan_bolum == 0)
                    {
                        DataGridViewRow silinecek_satir = matris.Rows[j]; //Silinecek satir belirleniyor.
                        matris.Rows.Remove(silinecek_satir); //Belirlenen en kucuk satir siliniyor.

                        lbl_durum.Text += "\nSatir kapsamalarina gore " + i + ". satir " + j + ".satiri kapsadi \n" + "ve " + j + ".satir silindi.";

                        return; //Fonksiyonu bitir
                    }
                    uyusmayan_bolum = 0;
                }
            }
            /*------------------- Tersten Karsilastirma Yapma -----------------------*/

            for (int i = satir - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    for (int k = 0; k < sutun; k++)
                    {
                        MessageBox.Show("i,k(" + i + " , " + k + ") = " + matris.Rows[i].Cells[k].Value + "\n" + " j,k(" + j + " ," + k + ") =" + matris.Rows[j].Cells[k].Value);
                        /*Kapsayacak satirin sutununun degeri 1 mi ve Kapsanan satir'in sutunu ile degeri ayni mi kontrol ediliyor.*/
                        if (Convert.ToInt32(matris.Rows[i].Cells[k].Value) == 1 && Convert.ToInt32(matris.Rows[i].Cells[k].Value) == Convert.ToInt32(matris.Rows[j].Cells[k].Value))
                        {
                            MessageBox.Show(matris.Rows[i].Cells[k].Value + "\n" + matris.Rows[j].Cells[k].Value + " ESITTTTTTT");
                        }
                        else if (Convert.ToInt32(matris.Rows[j].Cells[k].Value) == 1)
                        {
                            uyusmayan_bolum++;
                        }
                    }
                    if (uyusmayan_bolum == 0)
                    {
                        DataGridViewRow silinecek_satir = matris.Rows[j]; //Silinecek satir belirleniyor.
                        matris.Rows.Remove(silinecek_satir); //Belirlenen en kucuk satir siliniyor.

                        lbl_durum.Text += "\nSatir kapsamalarina gore " + i + ". satir " + j + ".satiri kapsadi \n" + "ve " + j + ".satir silindi.";

                        return; //Fonksiyonu bitir
                    }
                    uyusmayan_bolum = 0;
                }
            }

        }

        public void sutun_kapsamalarina_gore_sil()
        {
            int satir = matris.Rows.Count - 1; //satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //sutun sayisi tanimlandi.
            int uyusmayan_bolum = 0;


            /* (k,i) = 0,0 | 
               (k,j) = 0,1 |  

               (k,i) = 1,0 |
               (k,j) = 1,1 |

               (k,i) = 2,0 |
               (k,j) = 2,1 |

             Seklinde karsilastirma yapiliyor.*/
            for (int i = 0; i < sutun; i++)
            {
                for (int j = i + 1; j < sutun; j++)
                {
                    for (int k = 0; k < satir; k++)
                    {
                        MessageBox.Show("k,i(" + k + " , " + i + ") = " + matris.Rows[k].Cells[i].Value + "\n" + " k,j(" + k + " ," + j + ") =" + matris.Rows[k].Cells[j].Value);
                        if (Convert.ToInt32(matris.Rows[k].Cells[i].Value) == 1 && Convert.ToInt32(matris.Rows[k].Cells[i].Value) == Convert.ToInt32(matris.Rows[k].Cells[j].Value))
                        {
                            MessageBox.Show(matris.Rows[k].Cells[i].Value + "\n" + matris.Rows[k].Cells[j].Value + " ESITTTTTTT");
                        }
                        else if (Convert.ToInt32(matris.Rows[k].Cells[j].Value) == 1)
                        {
                            uyusmayan_bolum++;
                            break;
                        }
                    }
                    if (uyusmayan_bolum == 0)
                    {
                        string sutun_adi = matris.Columns[j].Name; //Mutlak sutunun adi bulunuyor.
                        matris.Columns.Remove(sutun_adi); //Mutlak sutun siliniyor.

                        lbl_durum.Text += "\nSutun kapsamalarina gore " + i + ". sutun " + j + ".sutun kapsadi \n" + "ve " + j + ".sutun silindi.";

                        return; //Fonksiyonu bitir
                    }
                    uyusmayan_bolum = 0;
                }
            }


            /*------------------- Tersten Karsilastirma Yapma -----------------------*/


            for (int i = sutun - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    for (int k = 0; k < satir; k++)
                    {
                        MessageBox.Show("k,i(" + k + " , " + i + ") = " + matris.Rows[k].Cells[i].Value + "\n" + " k,j(" + k + " ," + j + ") =" + matris.Rows[k].Cells[j].Value);
                        if (Convert.ToInt32(matris.Rows[k].Cells[i].Value) == 1 && Convert.ToInt32(matris.Rows[k].Cells[i].Value) == Convert.ToInt32(matris.Rows[k].Cells[j].Value))
                        {
                            MessageBox.Show(matris.Rows[k].Cells[i].Value + "\n" + matris.Rows[k].Cells[j].Value + " ESITTTTTTT");
                        }
                        else if (Convert.ToInt32(matris.Rows[k].Cells[j].Value) == 1)
                        {
                            uyusmayan_bolum++;
                            break;
                        }
                    }
                    if (uyusmayan_bolum == 0)
                    {
                        string sutun_adi = matris.Columns[j].Name; //Mutlak sutunun adi bulunuyor.
                        matris.Columns.Remove(sutun_adi); //Mutlak sutun siliniyor.

                        lbl_durum.Text += "\nSutun kapsamalarina gore " + i + ". sutun " + j + ".sutun kapsadi \n" + "ve " + j + ".sutun silindi.";

                        return; //Fonksiyonu bitir
                    }
                    uyusmayan_bolum = 0;
                }
            }

        }

        private void btn_ilerle_Click(object sender, EventArgs e)
        {
            //rota_algoritmasi_ile_sil();
            //mutlak_satir_sutun_bul_ve_sil();
            sutun_kapsamalarina_gore_sil();
            agirlik_hesapla();
            //satir_kapsamalarina_gore_sil();
        }
    }
}
