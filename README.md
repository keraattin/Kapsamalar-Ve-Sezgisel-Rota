# Minimum Kapsamalar Ve Sezgisel Rota Algoritmasi

## **Minimum Kapsamalar Nedir ?**

- Minimum kapsamalar bize en d�s�k maliyetle veya en az sayida eleman kullanarak
en �ok isi yapabilmemizi saglar.�rnegin bir n�bet �izelgesi olusturulacak ise
kisi sayisi kadar satir ve g�n sayisi kadar sutun olusturulur, 
kisilerin musait oldugu g�nler belirlenir ve tabloya yerlestirilir sonrasinda
minimum kapsama adimlari uygulandiginda en az kisi ile en �ok verim elde edilir,
daha dogrusu t�m g�nler kapatilmis olur.

## **Minimum Kapsamalar Nasil Yapilir ?**

- Minimum kapsamalarda �ncelikli olan sey mutlak satir bulmaktir,
bu y�zden s�rekli olarak mutlak satir aranir bulunamaz ise tekrar kapsama islemleri
veya satir silme islemleri uygulanarak tekrar aranir. Bulunan mutlak satirlar 
kapsamaya yazilir.Bu islemler bos matris elde edilinceye kadar devam eder.

## **Mutlak Satir Nedir ?**

- Sutun agirlik degeri 1 olan degerin bulundugu satir "mutlak satir" olarak adlandirilir.

## **Minimum Kapsamalarin Adimlari**

- __1 - __ Matrisin sutunlarindaki 1'ler sayilir ve o s�tunun agirligi olarak altina yazilir.
- __2 - __ Agirlik degeri 1 olan sutun varmi diye bakilir.Eger bulunur ise bulunan sutun hangi
satirda 1 degerini almis bulunur ve bulunan satir mutlak satir olarak isaretlenir. Mutlak satir 
bastan sonra taranarak icerisinde 1 bulunan h�crelerin ait oldugu sutunlar tablodan silinir ,
mutlak satir olarak isaretlenen satir tablodan silinir ve mutlak satir kapsamalara yazilir.
- __3 - __ Eger agirlik degeri 1 olan sutun bulunamaz ise yani mutlak satir bulunamaz ise
satir kapsamalarina bakilir. Satir kapsamalarinda her satir birbiri ile ikiser ikiser karsilastirilir.
Bir satir diger satir ile ayni degerlere sahip ve baska degerlere de sahip ise bu satir diger satiri
kapsar ve diger satir silinir.Bu islemler yapildiktan sonra tablo g�ncellenir ve tekrar mutlak satir aranir.
Mutlak satir bulunamaz ise satir kapsamalarina tekrar bakilir yani 3.adim tekrar uygulanir.
Eger ki birbirini kapsayan satirlar bulunamaz ise sutun kapsamalarina bakilir yani 4.adima ge�ilir.
- **4 - ** Eger hi�bir satir birbirinin alt k�mesi degil ise yani birbirini kapsamiyor ise s�tun 
kapsamalarina bakilir.S�tun kapsamalarinda her s�tun birbiri ile karsilastirilir , eger bir sutun
diger bir sutun ile ayni degere sahip ve sadece 1 fazla degere sahip ise 1 fazla degere sahip olan sutun
tablodan silinir.Bu islemler yapildiktan sonra tablo g�ncellenir ve mutlak satir aranir , bulunamaz ise 
mutlak satir aranir eger o da bulunamaz ise tekrar s�tun kapsamalarina bakilir ,  bulunamaz ise 
**sezgisel rota algoritmasi**'na yani 5. adima ge�ilir.
- **5 -** Eger hi� mutlak satir , satir kapsamasi veya s�tun kapsamasi yok ise **sezgisel rota algoritmasi**ndan 
yararlanilir. Bu adimda satirlarin agirliklari hesaplanir.  �ncelikle en d�s�k agirlik degerine sahip s�tunlar 
isaretlenir ardindan o s�tunlarin bulundugu satirlar isaretlenir. Isaretlenen satirlar bastan sona taranir ve 
1 degerine sahip olan h�crelerin ait oldugu s�tunlarin agirliklari "1/Sutun agirligi" seklinde alinir birbiri 
ile toplanir. �ikan sonu� matrisdeki o an bulunan toplam satir sayisi ile �arpilir.Bulunan sonuc o satirin agirligi
olarak bulunur ve satirin kenarina yazilir.Bu islemler en d�s�k agirlik degerine sahip olan b�t�n sutunlar i�in
yapildiktan sonra bulunan satir agirliklarindan en d�s�k agirliga sahip olan satir tablodan silinir. 
Bu islem ger�eklestikten sonra program tekrar 1.adima d�ner. Agirliklari g�nceller , mutlak satir arar , 
satir kapsamasi arar , s�tun kapsamasi arar hicbiri yok ise yine bu adim uygulanir bu islemler bos matris 
elde edilene kadar devam ettirilir.