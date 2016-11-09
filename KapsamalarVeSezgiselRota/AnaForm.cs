﻿using System;
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

        public DataGridView matris1 = new DataGridView();  //Matris icin datagridview olusturuldu.

        public DataGridView matris2 = new DataGridView();  //Matris icin datagridview olusturuldu.

        public DataGridView matris3 = new DataGridView(); //Matris icin datagridview olusturuldu

        public RichTextBox rtb = new RichTextBox(); //Islemlerin yazilacagi RichTextBox olusturuldu.

        public int islem_sayisi = 0; //Islem sayilarinin tutulacagi degisken olusturuldu.

        private void AnaForm_Load(object sender, EventArgs e)
        {
            btn_islem_basla.Enabled = false;
            btn_ilerle.Enabled = false;
            this.AcceptButton = btn_olustur;
            rd_el_ile.Checked = true;
        }

        public void matris_olustur(int satir,int sutun,int x,int y,DataGridView matris)
        {
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

            matris.TopLeftHeaderCell.Value = "y\\x"; //Sol en ustteki hücreye "y\x" yazildi.
           
            /*Matrise "satir" degiskeni kadar satır ekleniyor.*/
            for (int j = 0; j < satir; j++)
            {
                matris.Rows.Add(); //Satir ekleme.
                matris.Rows[j].Height = 20; //Satirlarin yuksekligi ayarlandi.
                matris.Rows[j].HeaderCell.Value = "y" + j; //Satirlarin basina isim verildi.
                matris.Rows[j].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight; //Satir basindaki yazilar saga dayali hale getirildi.
            }
            matris.Rows.Add(); //Ağırlık satiri ekleniyor.

            matris.RowHeadersWidth = 50;  //Header satirinin genisligi ayarlaniyor. 
            matris.SelectionMode = DataGridViewSelectionMode.CellSelect; //Secimin sadece hücre bazli yapilmasi saglaniyor.
            matris.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; //Satir basindaki hucrenin yeniden boyutlandirilmasi engelleniyor.
            matris.MultiSelect = false; //Kullanicilarin birden cok secim yapmasi engelleniyor.
            matris.AllowUserToDeleteRows = false; //Kullanicilarin matristen satir silmesi engelleniyor.
            matris.AllowUserToResizeRows = false; //Kullanicillarin matirisin satirlarinin boyutunu degistirmesi engelleniyor.
            matris.AllowUserToAddRows = false; //Matrise kullanicilarin satir eklemesi engelleniyor.
            matris.Size = new Size((30*sutun)+106,(20*satir)+48);  //Matris'in boyutu belirleniyor.
            matris.Location = new Point(x, y);            //Matris'in lokasyonu belirleniyor.
            matris.Visible = true;                        //Matris'in görünürlüğü aciliyor.
            this.Controls.Add(matris);                    //Matris pencereye ekleniyor.
        }

        /*Olusturulan matrisin butun degerleri 0 a esitleniyor.*/
        public void ilk_deger_ata(DataGridView matris)
        {
            int satir = matris.Rows.Count - 1;
            int sutun = matris.Columns.Count - 1;

            if(rd_random.Checked == true)
            {
                Random rnd = new Random();

                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        matris.Rows[i].Cells[j].Value = rnd.Next(0,2); //0 ile 1 arasi random sayilar uretiliyor.
                        matris.Rows[i].Cells[j].ReadOnly = true; //Her hucre yazmaya korumali hale getiriliyor.
                    }
                }

            }
            else if(rd_el_ile.Checked == true)
            {
                /*Deger atanacak satir ve sutunlar 0 ile dolduruluyor.*/
                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        matris.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

        }

        /*Matris 1 deki degerleri Matris 2 ye aktarma fonksiyonu.*/
        public void degerleri_aktar(DataGridView m1, DataGridView m2)
        {
            int satir = m1.Rows.Count - 1;
            int sutun = m1.Columns.Count - 1;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    m2.Rows[i].Cells[j].Value = m1.Rows[i].Cells[j].Value; //Matris1 deki degerler Matris2 ye aktariliyor.
                }
            }
        }

        /*Satır ve sutunların ağırlıklarının hesaplandiği fonksiyon*/
        public void agirlik_hesapla(DataGridView matris)
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

        /*Sadece sutunlarin agiliklarini hesaplayan fonksiyon.*/
        public void sadece_sutun_agirlik_hesapla(DataGridView matris)
        {
            int satir = matris.Rows.Count - 1; //satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //sutun sayisi tutulan degsiken tanimlandi.

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
                matris.Rows[satir].Cells[i].ReadOnly = true; //1 lerin sayisinin yazildigi sutun sadece okunabilir yapildi.
                matris.Rows[satir].Cells[i].Style = new DataGridViewCellStyle { BackColor = Color.Red, ForeColor = Color.White }; //1 lerin yazıldıgı kolona yeni stil eklendi.
                matris.Rows[satir].Cells[i].Value = toplam;  //1 lerin sayisi en alt sutunlara yazildi.
                toplam = 0; //Toplam degiskeni diger degerlere bakabilmek icin sifirlandi.
            }

        }


        public int mutlak_satir_sutun_bul_ve_sil(DataGridView matris)
        {
            int satir = matris.Rows.Count - 1; //Satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //Sutun sayisi tutulan degisken tanimlandi.

            int mutlak_satir = 0;  //Mutlak satir degiskeni olusturuluyor.
            int mutlak_sutun = 0;  //Mutlak sutun degiskeni olusturuluyor.

            int bulundu = 0; //Mutlak satır oldugunu bulup bulmadigimizi kontrol etmek icin bulundu degiskeni olusturuluyor.

            /*Agırlıkları 1 olan sutunlar bulunuyor.*/
            for (int i = 0; i < sutun; i++)
            {
                if (Convert.ToInt32(matris.Rows[satir].Cells[i].Value) == 1) //Agirlik sutunun degeri 1'e esitmi kontrol ediliyor.
                {
                    mutlak_sutun = i; //Mutlak sutunun degeri i olarak degistiriliyor.
                    bulundu++; //Bulundu degiskeni kontrol icin degeri arttirliyor.
                    break;
                }
            }
            if (bulundu == 0) //Mutlak sutun bulunamadiysa fonksiyondan cikiliyor.
            {
                return 0; //Fonksiyondan cikiliyor.
            }

            /*Mutlak sutunun 1 oldugu satir araniyor.*/
            for (int i = 0; i < satir; i++)
            {
                if (Convert.ToInt32(matris.Rows[i].Cells[mutlak_sutun].Value) == 1) //Satir ve mutlak_sutun'un degeri 1'e esitmi kontrol ediliyor.
                {
                    mutlak_satir = i; //Mutlak satirin degeri i olarak degistiriliyor.
                    break; 
                }
            }

            string sutun_adi = matris.Columns[mutlak_sutun].Name; //Mutlak sutunun adi bulunuyor.
            matris.Columns.Remove(sutun_adi); //Mutlak sutun siliniyor.

            DataGridViewRow satir_adi = matris.Rows[mutlak_satir]; //Silinecek satirin bilgileri aliniyor.
            matris.Rows.RemoveAt(mutlak_satir); //Mutlak satir siliniyor.

            if(matris == matris2)
            {
                lbl_kapsamalar.Text += satir_adi.HeaderCell.Value + " "; //Kapsamalar yaziliyor.
                islem_sayisi++; //Islem gerceklestigi icin islem sayisi 1 arttiriliyor.
                rtb.Text += "\n" + islem_sayisi + " => "+ satir_adi.HeaderCell.Value +" Mutlak satir olarak bulundu ve "+ satir_adi.HeaderCell.Value + " satiri ve "+sutun_adi+" sutun silindi.\n";
            }
            return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
        }



        /*En kucuk agirlikli satirin sirasi ve degerinin tutulacagi bir struct olusturuldu.*/
        public struct enKucuk
        {
            public float deger;
            public int sira;
        };

        /*Rota algoritmasi ile silme fonksiyonu*/
        public void rota_algoritmasi_ile_sil(DataGridView matris)
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

            if(matris ==matris2)
            {
                islem_sayisi++;
                rtb.Text += "\n" + islem_sayisi + " => Rota algoritmasına gore " + silinecek_satir.HeaderCell.Value + " satiri en dusuk agirlik degerine sahip oldugu icin silindi.\n";
            }
            
        }



        public int satir_kapsamalarina_gore_sil(DataGridView matris)
        {
            int satir = matris.Rows.Count - 1; //satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //sutun sayisi tutulan degisken tanimlandi.
            int ust_kapsar = 0;
            int alt_kapsar = 0;

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
                        if (Convert.ToInt32(matris.Rows[i].Cells[k].Value) == 1 && Convert.ToInt32(matris.Rows[j].Cells[k].Value) == 0)
                        {
                            ust_kapsar++; //Ust tarafta 1 alt tarafta 0 oldugu icin ust_kapsar degiskeni arttirildi.
                            if (alt_kapsar > 0) //Alt tarafta onceden 1 elemanı bulunmusmu kontrol ediliyor.   
                                break; //Alt tarafta onceden 1 elemanı bulunmussa kapsama yoktur.

                            /*Daha onceden alt tarafta 1 elemanı bulunmadiysa devam ediliyor.*/
                            ust_kapsar++; //Ust taraf , alt tarafi kapsayacagi icin ust_kapsar degiskeni arttiriliyor.
                        }
                        else if (Convert.ToInt32(matris.Rows[j].Cells[k].Value) == 1 && Convert.ToInt32(matris.Rows[i].Cells[k].Value) == 1)
                        {
                        }
                        else if (Convert.ToInt32(matris.Rows[j].Cells[k].Value) == 1 && Convert.ToInt32(matris.Rows[i].Cells[k].Value) == 0)
                        {
                            alt_kapsar++; //Alt tarafta 1 ust tarafta 0 oldugu icin alt_kapsar degiskeni arttirildi.
                            if (ust_kapsar > 0) //Ust tarafta onceden 1 elemanı bulunmusmu kontrol ediliyor. 
                                break; //Ust tarafta onceden 1 elemanı bulunmussa kapsama yoktur.

                            /*Daha onceden ust tarafta 1 elemanı bulunmadiysa devam ediliyor.*/
                            alt_kapsar++; //Alt taraf , ust tarafi kapsayacagi icin alt_kapsar degiskeni arttiriliyor.
                        }
                    }
                    if (ust_kapsar > 0 && alt_kapsar == 0 || ust_kapsar == 0 && alt_kapsar == 0)
                    {
                        DataGridViewRow silinecek_satir = matris.Rows[j]; //Silinecek satir belirleniyor.
                        matris.Rows.Remove(silinecek_satir); //Belirlenen en kucuk satir siliniyor.
                        DataGridViewRow kapsayan_satir = matris.Rows[i];
                        //MessageBox.Show("Kapsayan satir = "+i+"\n header cell = "+kapsayan_satir.HeaderCell.Value+"\nsilinecek satir = " + j + " \n header cell = " + silinecek_satir.HeaderCell.Value);

                        if(matris == matris2) //Matris2 üzerinde islem yapiliyorsa islem sayisini arttir ve yazdir.
                        {
                            islem_sayisi++; //Islem gerceklestigi icin islem sayisi 1 arttiriliyor.
                            rtb.Text += "\n" + islem_sayisi + " => Satir kapsamalarina gore " + kapsayan_satir.HeaderCell.Value + " satiri " + silinecek_satir.HeaderCell.Value + "satirini kapsadi ve " + silinecek_satir.HeaderCell.Value + " satiri silindi. \n";
                        }

                        return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                    }
                    else if (alt_kapsar > 0 && ust_kapsar == 0)
                    {
                        DataGridViewRow silinecek_satir = matris.Rows[i]; //Silinecek satir belirleniyor.
                        matris.Rows.Remove(silinecek_satir); //Belirlenen en kucuk satir siliniyor.
                        DataGridViewRow kapsayan_satir = matris.Rows[j];
                        //MessageBox.Show("Kapsayan satir = " + j + "\n header cell = " + kapsayan_satir.HeaderCell.Value + "\nsilinecek satir = " + i + " \n header cell = " + silinecek_satir.HeaderCell.Value);

                        if (matris == matris2) //Matris2 üzerinde islem yapiliyorsa islem sayisini arttir ve yazdir.
                        {
                            islem_sayisi++; //Islem gerceklestigi icin islem sayisi 1 arttiriliyor.
                            rtb.Text += "\n" + islem_sayisi + " => Satir kapsamalarina gore " + kapsayan_satir.HeaderCell.Value + " satiri " + silinecek_satir.HeaderCell.Value + " satirini kapsadi ve " + matris.Rows[i].HeaderCell.Value + " satiri silindi. \n";
                        }

                        return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                    }
                    else //Kapsama yoktur.
                    {
                        alt_kapsar = 0;
                        ust_kapsar = 0;
                    }
                    alt_kapsar = 0;
                    ust_kapsar = 0;
                }
            }
            return 0; //Kapsanan satir bulunamadi.
        }

        public int sutun_kapsamalarina_gore_sil(DataGridView matris)
        {
            int satir = matris.Rows.Count - 1; //Satir sayisi tutulan degisken tanimlandi.
            int sutun = matris.Columns.Count - 1; //Sutun sayisi tutulan degisken tanimlandi.
            int sol_kapsar = 0;
            int sag_kapsar = 0;


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
                        if (Convert.ToInt32(matris.Rows[k].Cells[i].Value) == 1 && Convert.ToInt32(matris.Rows[k].Cells[j].Value) == 0)
                        {
                            sol_kapsar++; //Sol tarafta 1 sag tarafta 0 oldugu icin sol_kapsar degiskeni arttirildi.
                            if (sag_kapsar > 0) //Sag tarafta onceden 1 elemanı bulunmusmu kontrol ediliyor. 
                                break; //Sag tarafta onceden 1 elemanı bulunmussa kapsama yoktur.

                            /*Daha onceden sag tarafta 1 elemanı bulunmadiysa devam ediliyor.*/
                            sol_kapsar++; // Sol taraf , sag tarafi kapsayacagi icin sol_kapsar degiskeni arttiriliyor.
                        }
                        else if (Convert.ToInt32(matris.Rows[k].Cells[i].Value) == 1 && Convert.ToInt32(matris.Rows[k].Cells[j].Value) == 1)
                        {
                        }
                        else if (Convert.ToInt32(matris.Rows[k].Cells[j].Value) == 1 && Convert.ToInt32(matris.Rows[k].Cells[i].Value) == 0)
                        {
                            sag_kapsar++; //Sag tarafta 1 sol tarafta 0 oldugu icin sag_kapsar degiskeni arttirildi.
                            if (sol_kapsar > 0) //Sol tarafta daha onceden 1 elemanı bulunmusmu kontrol ediliyor. 
                                break; //Sol tarafta onceden 1 elemanı bulunmussa kapsama yoktur

                            /*Daha onceden sol tarafta 1 elemanı bulunmadiysa devam ediliyor.*/
                            sag_kapsar++; // Sag taraf , sol tarafi kapsayacagi icin sag_kapsar degiskeni arttiriliyor.
                        }
                    }
                    if (sol_kapsar > 0 && sag_kapsar == 0 || (sol_kapsar == 0 && sag_kapsar == 0))
                    {
                        string sutun_adi = matris.Columns[j].Name; //Kapsanan sutunun adi bulunuyor.
                        matris.Columns.Remove(sutun_adi); //Kapsanan sutun siliniyor.

                        string kapsayan_sutun_adi = matris.Columns[i].Name; //Kapsayan sutunun adi bulunuyor.

                        if(matris == matris2)  //Matris2 üzerinde islem yapiliyorsa islem sayisini arttir ve yazdir.
                        {
                            islem_sayisi++; //Islem gerceklestigi icin islem sayisi 1 arttiriliyor.
                            rtb.Text += "\n" + islem_sayisi + " => Sutun kapsamalarina gore " + kapsayan_sutun_adi + " sutunu " + sutun_adi + " sutununu kapsadi ve " + sutun_adi + " sutunu silindi.\n";
                        }

                        return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                    }
                    else if (sag_kapsar > 0 && sol_kapsar == 0)
                    {
                        string sutun_adi = matris.Columns[i].Name; //Kapsanan sutunun adi bulunuyor.
                        matris.Columns.Remove(sutun_adi); //Kapsanan sutun siliniyor.

                        string kapsayan_sutun_adi = matris.Columns[j].Name; //Kapsayan sutunun ismi bulunuyor.

                        if (matris == matris2) //Matris2 üzerinde islem yapiliyorsa islem sayisini arttir ve yazdir.
                        {
                            islem_sayisi++; //Islem gerceklestigi icin islem sayisi 1 arttiriliyor.
                            rtb.Text += "\n" + islem_sayisi + " => Sutun kapsamalarina gore " + kapsayan_sutun_adi + " sutunu " + sutun_adi + " sutununu kapsadi ve " + sutun_adi + " sutunu silindi.\n";
                        }

                        return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                    }
                    else //Kapsama yoktur.
                    {
                        sag_kapsar = 0; //Degiskenler bir sonraki kontroller icin 0 laniyor.
                        sol_kapsar = 0; //Degiskenler bir sonraki kontroller icin 0 laniyor.
                    }
                    sag_kapsar = 0; //Degiskenler bir sonraki kontroller icin 0 laniyor.
                    sol_kapsar = 0; //Degiskenler bir sonraki kontroller icin 0 laniyor.
                }
            }
            return 0; //Kapsanan sutun bulunamadi.
        }

        /*Mutlak sutun , Satir kapsamasi , Sutun kapsamasi , Rota algoritmasi islemlerinin yapilmasi.*/
        public int islem_yap(DataGridView matris)
        {
            if ((matris.Rows.Count-1) < 1 || (matris.Columns.Count-1) < 1) //Islemler bitmismi kontrol ediliyor.
            {
               if(matris == matris2) rtb.Text += "\n\n ISLEM SONLANDI \n\n";
                return 0; //Islem sonlandigi ve bir daha islem yapmayacagi icin 0 donduruyor.
            }
            else if(chk_rota.Checked == true) //Sadece sezgisel rota algoritmasi ile indirgeme yapiliyor.
            {
                if(mutlak_satir_sutun_bul_ve_sil(matris)==0)
                {
                    agirlik_hesapla(matris); //Rota algoritmasinin calisabilmesi icin satir agirliklari hesaplanmali.
                    rota_algoritmasi_ile_sil(matris);
                    return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                }
                else
                {
                    return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                }

            }
            else
            {
                if (mutlak_satir_sutun_bul_ve_sil(matris) == 0)
                {
                   if(matris == matris2) rtb.Text += "\nMutlak sutun bulunamadi ";
                    if (satir_kapsamalarina_gore_sil(matris) == 0)
                    {
                      if(matris == matris2)  rtb.Text += " , Kapsanan satir bulunamadi ";
                        if (sutun_kapsamalarina_gore_sil(matris) == 0)
                        {
                           if(matris == matris2) rtb.Text += " , Kapsanan sutun bulunamadi ";
                            agirlik_hesapla(matris); //Rota algoritmasinin calisabilmesi icin satir agirliklari hesaplanmali.
                            rota_algoritmasi_ile_sil(matris); //Hicbir fonksiyon calismadiysa rota algoritmasina gore en dusuk agirligi olan satir siliniyor.
                            return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                        }
                        else
                        {
                            return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                        }
                    }
                    else
                    {
                        return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                    }
                }
                else
                {
                    return 1; //Islem gerceklestigi icin 1 degeri geri donduruyor.
                }
            }
            
        }

        /*-------------------------- Eventler --------------------------*/

        private void btn_olustur_Click(object sender, EventArgs e)
        {

            /*Kac satır ve sutun olusturulacagı degiskenlere atandı.*/
            int satir = Convert.ToInt32(txt_satir.Text);
            int sutun = Convert.ToInt32(txt_sutun.Text);

            matris_olustur(satir, sutun, 20, 80, matris1); //Matris olusturma fonksiyonu cagirilip 1.Matris olusturuluyor.

            ilk_deger_ata(matris1); //Ilk deger atamasi yapan fonksyiona matris1 gonderiliyor.

            grb_baslangic.Enabled = false;                //grb_baslangic grubBox'u kapatiliyor.
            txt_satir.Enabled = false;                    //Satır girisi kapatiliyor.
            txt_sutun.Enabled = false;                    //Sutun girisi kapatiliyor.
            btn_olustur.Enabled = false;                  //Olustur butonu kapatiliyor.
            btn_islem_basla.Enabled = true;               //Isleme basla butonu aciliyor.

        }


        /*Islemleri baslatan button*/
        private void btn_islem_basla_Click(object sender, EventArgs e)
        {
            sadece_sutun_agirlik_hesapla(matris1); //Satir sutun agirliklari hesaplandi.

            /*Ikinci matris olusturuluyor ve 1.Matrisdeki degelerler 2.Matrise aktariliyor.*/
            int satir = matris1.Rows.Count - 1;
            int sutun = matris1.Columns.Count - 1;
            int x = matris1.Width; //1.Matrisin genislik degeri bulunuyor.
            matris_olustur(satir, sutun, x + 40, 80, matris2); //Matris olusturma fonksiyonu cagirilip 2.Matris olusturuluyor.
            degerleri_aktar(matris1, matris2); //Matris1 deki degerler Matris2 ye aktarildi.
            sadece_sutun_agirlik_hesapla(matris2); //Satir sutun agirliklari hesaplandi.

            /*Yapilan islemlerin yazilacagi RichTextBox tanimlaniyor.*/
            rtb.Size = new Size ( 600 , 400 ); //Boyutu belirlendi.
            rtb.Top = (matris1.Height) + 100; //Ustten ne kadar asagida olacagi belirlendi.
            rtb.Left = 20; //Soldan ne kadar sagda olacagi belirlendi
            rtb.Text += islem_sayisi.ToString() +" => Islemlere baslandi \n"; //Baslangic yazisi yazildi.
            rtb.Visible = true; //RichTextBox'un gorunurlugu acildi.
            rtb.ReadOnly = true; //RichTextBox'un kullanici tarafından degistirilmesi engellendi.
            this.Controls.Add(rtb); //RichTextBox Form a eklendi.

            btn_islem_basla.Enabled = false; //Isleme baslama butonu kapandi.
            btn_ilerle.Enabled = true;  //Ilerleme butonu acildi.

            matris_olustur(satir, sutun, x+x+60, 80, matris3); //Matris olusturma fonksiyonu cagirilip 3.Matris olusturuluyor.
            degerleri_aktar(matris1, matris3); //Matris1 deki degerler Matris3 ye aktarildi.
            agirlik_hesapla(matris3); //Matris3 deki agirliklar hesaplaniyor

            islem_yap(matris2); //Matris2'nin onden gidebilmesi icin islemler onceden basliyor.
        }

        private void btn_ilerle_Click(object sender, EventArgs e)
        {
            if (islem_yap(matris2) == 1) //2.Matriste sonuc bulunmamis ise diger matriste islem yapiliyor.
            {
                sadece_sutun_agirlik_hesapla(matris2);
                islem_yap(matris1);
                sadece_sutun_agirlik_hesapla(matris1);
            }

        }
    }
}
