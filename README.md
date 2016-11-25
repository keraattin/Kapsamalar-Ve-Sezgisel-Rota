# Minimum Kapsamalar Ve Sezgisel Rota Algoritmasi

## **Minimum Kapsamalar Nedir ?**

- Minimum kapsamalar bize en düsük maliyetle veya en az sayida eleman kullanarak
en çok isi yapabilmemizi saglar.Örnegin bir nöbet çizelgesi olusturulacak ise
kisi sayisi kadar satir ve gün sayisi kadar sutun olusturulur, 
kisilerin musait oldugu günler belirlenir ve tabloya yerlestirilir sonrasinda
minimum kapsama adimlari uygulandiginda en az kisi ile en çok verim elde edilir,
daha dogrusu tüm günler kapatilmis olur.

## **Minimum Kapsamalar Nasil Yapilir ?**

- Minimum kapsamalarda öncelikli olan sey mutlak satir bulmaktir,
bu yüzden sürekli olarak mutlak satir aranir bulunamaz ise tekrar kapsama islemleri
veya satir silme islemleri uygulanarak tekrar aranir. Bulunan mutlak satirlar 
kapsamaya yazilir.Bu islemler bos matris elde edilinceye kadar devam eder.

## **Mutlak Satir Nedir ?**

- Sutun agirlik degeri 1 olan degerin bulundugu satir "mutlak satir" olarak adlandirilir.

## **Minimum Kapsamalarin Adimlari**

- **1 - ** Matrisin sutunlarindaki 1'ler sayilir ve o sütunun agirligi olarak altina yazilir.
- **2 - ** Agirlik degeri 1 olan sutun varmi diye bakilir.Eger bulunur ise bulunan sutun hangi
satirda 1 degerini almis bulunur ve bulunan satir mutlak satir olarak isaretlenir. Mutlak satir 
bastan sonra taranarak icerisinde 1 bulunan hücrelerin ait oldugu sutunlar tablodan silinir ,
mutlak satir olarak isaretlenen satir tablodan silinir ve mutlak satir kapsamalara yazilir.
- **3 - ** Eger agirlik degeri 1 olan sutun bulunamaz ise yani mutlak satir bulunamaz ise
satir kapsamalarina bakilir. Satir kapsamalarinda her satir birbiri ile ikiser ikiser karsilastirilir.
Bir satir diger satir ile ayni degerlere sahip ve baska degerlere de sahip ise bu satir diger satiri
kapsar ve diger satir silinir.Bu islemler yapildiktan sonra tablo güncellenir ve tekrar mutlak satir aranir.
Mutlak satir bulunamaz ise satir kapsamalarina tekrar bakilir yani 3.adim tekrar uygulanir.
Eger ki birbirini kapsayan satirlar bulunamaz ise sutun kapsamalarina bakilir yani 4.adima geçilir.
- **4 - ** Eger hiçbir satir birbirinin alt kümesi degil ise yani birbirini kapsamiyor ise sütun 
kapsamalarina bakilir.Sütun kapsamalarinda her sütun birbiri ile karsilastirilir , eger bir sutun
diger bir sutun ile ayni degere sahip ve sadece 1 fazla degere sahip ise 1 fazla degere sahip olan sutun
tablodan silinir.Bu islemler yapildiktan sonra tablo güncellenir ve mutlak satir aranir , bulunamaz ise 
mutlak satir aranir eger o da bulunamaz ise tekrar sütun kapsamalarina bakilir ,  bulunamaz ise 
**sezgisel rota algoritmasi**'na yani 5. adima geçilir.
- **5 -** Eger hiç mutlak satir , satir kapsamasi veya sütun kapsamasi yok ise **sezgisel rota algoritmasi**ndan 
yararlanilir. Bu adimda satirlarin agirliklari hesaplanir.  Öncelikle en düsük agirlik degerine sahip sütunlar 
isaretlenir ardindan o sütunlarin bulundugu satirlar isaretlenir. Isaretlenen satirlar bastan sona taranir ve 
1 degerine sahip olan hücrelerin ait oldugu sütunlarin agirliklari "1/Sutun agirligi" seklinde alinir birbiri 
ile toplanir. Çikan sonuç matrisdeki o an bulunan toplam satir sayisi ile çarpilir.Bulunan sonuc o satirin agirligi
olarak bulunur ve satirin kenarina yazilir.Bu islemler en düsük agirlik degerine sahip olan bütün sutunlar için
yapildiktan sonra bulunan satir agirliklarindan en düsük agirliga sahip olan satir tablodan silinir. 
Bu islem gerçeklestikten sonra program tekrar 1.adima döner. Agirliklari günceller , mutlak satir arar , 
satir kapsamasi arar , sütun kapsamasi arar hicbiri yok ise yine bu adim uygulanir bu islemler bos matris 
elde edilene kadar devam ettirilir.