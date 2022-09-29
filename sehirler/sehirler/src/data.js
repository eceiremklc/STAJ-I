const menu = [
    {
      id: 1,
      title: 'Pamukkale',
      category: 'denizli',
      img: 'https://media.istockphoto.com/photos/pamukkalehierapolis-picture-id179542990?s=612x612',
      desc: `Pamukkale, güneybatı Türkiye'deki Denizli ilinde doğal bir mevkidir. Kent Kaplıcaları ve akan sulardan kalan karbonat minerallerin teraslarını, travertenlerini kapsamaktadır. `,
    },
    {
      id: 2,
      title: 'Hierapolis Antik Kenti',
      category: 'denizli',
      img: 'https://media.istockphoto.com/photos/amphitheater-hierapolis-antik-kenti-picture-id1394260937?s=612x612',
      desc: `Pamukkale (Denizli) yakınlarında bulunan bir antik kenttir.`,
    },
    {
      id: 3,
      title: 'Buldan',
      category: 'denizli',
      img: 'https://media.istockphoto.com/photos/buldan-province-of-denizli-city-in-turkey-picture-id641785046?s=612x612',
      desc: `Buldan, Denizli ilinin bir ilçesidir. Dokumacılık (tekstil) konusunda tüm Türkiye'de meşhur bir ilçedir.`,
    },
    {
      id: 4,
      title: 'Pierre Loti Tepesi',
      category: 'istanbul',
      img: 'https://media.istockphoto.com/photos/sun-rise-at-pierre-loti-3-picture-id505229980?k=20&m=505229980&s=612x612&w=0&h=iK7BAyoSpLY1AHJXiKoJPeARLAIiAYs91K3MhNg1TQ8=',
      desc: `Pierre Loti Tepesi, İstanbul'un Eyüpsultan ilçesinde Haliç'e nazır bir tepedir. Tepe adını, 1876 yılında İstanbul'a gelerek buraya yerleşen ve sık sık bu tepedeki bir kıraathaneye 
      gelmesiyle tanınan Fransız roman yazarı ve doğu bilimci Julien Viaud'dan almıştır. `,
    },
    {
      id: 5,
      title: 'Galata Kulesi',
      category: 'istanbul',
      img: 'https://media.istockphoto.com/photos/galata-tower-in-istanbul-turkey-picture-id1188930099?s=612x612',
      desc: `Türkiye'nin İstanbul şehrinin Beyoğlu ilçesinde bulunan bir kuledir. Adını, bulunduğu Galata semtinden alır. Hem Beyoğlu'nun hem de İstanbul'un sembol yapılarındandır.`,
    },
    {
      id: 6,
      title: 'Gülhane Parkı',
      category: 'istanbul',
      img: 'https://media.istockphoto.com/photos/park-with-tall-green-treesplants-and-paths-inbetween-in-glhane-park-picture-id1349059531?s=612x612',
      desc: `Gülhane Parkı, İstanbul'un Fatih ilçesinin Eminönü semtinde yer alan tarihî bir parktır. `,
    },
    {
      id: 7,
      title: 'Kız Kulesi',
      category: 'istanbul',
      img: 'https://media.istockphoto.com/photos/maidens-tower-kiz-kulesi-xxxl-picture-id159750001?k=20&m=159750001&s=612x612&w=0&h=N08MeTN2a--HZ92ih98ScBPiuLIC8W2Vy86pNGuEBUw=',
      desc: `Kız Kulesi, İstanbul Boğazı'nın Marmara Denizi'ne yakın kısmında, Salacak açıklarında yer alan küçük adacık üzerinde inşa edilmiş yapıdır. `,
    },
    {
      id: 8,
      title: 'Ayasofya Camii',
      category: 'istanbul',
      img: 'https://media.istockphoto.com/photos/blue-mosque-and-hagia-sophia-picture-id475460738?k=20&m=475460738&s=612x612&w=0&h=yJfvCrLKfRY7Ko-80-VOOTDfsK9-qWggdsJ2v98vo38=',
      desc: `Eski adıyla Kutsal Bilgelik Kilisesi ve Ayasofya Müzesi veya günümüzdeki resmî adıyla Ayasofya-i Kebîr Câmi-i Şerîfi (Kutsal Büyük Ayasofya Camii)[4][5], İstanbul'da yer alan bir cami ve eski bazilika, katedral ve müzedir.`,
    },
    {
        id: 9,
        title: 'Selimiye Camii',
        category: 'edirne',
        img: 'https://media.istockphoto.com/photos/selimiye-mosque-picture-id484713584?s=612x612',
        desc: `Selimiye Camiî, Osmanlı padişahı II. Selim döneminde Mimar Sinan'ın yaptığı ve Osmanlı'nın önceki başkenti Edirne'de bulunan bir külliyedir.`,
      },
      {
        id: 10,
        title: 'Tarihi Meriç Köprüsü',
        category: 'edirne',
        img: 'https://media.istockphoto.com/photos/meric-river-and-the-bridge-in-edirne-turkey-picture-id1282880700?s=612x612',
        desc: `Mecidiye Köprüsü veya diğer adıyla Meriç Köprüsü, 1842'de Abdülmecit zamanında yapımına başlanmış ve 1847'de bitirilmiş köprüdür.`,
      },
      {
        id: 11,
        title: 'Mevlana Müzesi/Türbesi',
        category: 'konya',
        img: 'https://media.istockphoto.com/photos/mevlana-picture-id514711986?s=612x612',
        desc: `Mevlânâ Müzesi, Konya'da bulunan, eskiden Mevlâna'nın dergâhı olan yapı kompleksinde 1926 yılından beri faaliyet gösteren müzedir. "Mevlana Türbesi" olarak da anılır.`,
      },
      {
        id: 12,
        title: 'Anıtkabir',
        category: 'ankara',
        img: 'https://media.istockphoto.com/photos/anitkabir-at-dusk-picture-id168635430?s=612x612',
        desc: `Anıtkabir, Türkiye'nin başkenti Ankara'nın Çankaya ilçesinde yer alan ve Mustafa Kemal Atatürk'ün anıt mezarını içeren komplekstir.`,
      },
      {
        id: 13,
        title: 'Sazova Park',
        category: 'eskişehir',
        img: 'https://media.istockphoto.com/photos/lake-in-the-sazova-park-in-eskisehir-city-picture-id1351846473?s=612x612',
        desc: `Eskişehir Bilim Sanat ve Kültür Parkı, Eskişehir'in Sazova Mahallesi'nde 400 bin metrekare üzerine kurulu park.[1]`,
      },
      {
        id: 14,
        title: 'Sinop Kale Hapishanesi',
        category: 'sinop',
        img: 'https://media.istockphoto.com/photos/sinop-fortress-prison-was-a-state-prison-situated-in-the-inside-of-picture-id1214119590?s=612x612',
        desc: `Tarihî Sinop Kapalı Cezaevi, bir dönem "Anadolu'nun Alkatrazı"[1] tabiri ile de tanınan ve 1999 yılında kapatılmış cezaevidir. 2000'de müzeye çevrilmiştir.`,
      },
      {
        id: 15,
        title: 'Tarihi Safranbolu Evleri',
        category: 'karabük',
        img: 'https://media.istockphoto.com/photos/historic-safranbolu-houses-picture-id946525144?s=612x612',
        desc: `Safranbolu evleri, Karabük iline bağlı Safranbolu ilçesinde, 18. ve 19. yüzyıl Osmanlı kent dokusunun günümüze kadar korunduğu bölgenin genel adıdır.`,
      },
      {
        id: 16,
        title: 'Kral Kaya Mezarları',
        category: 'amasya',
        img: 'https://media.istockphoto.com/photos/tombs-of-the-kings-of-pontus-at-amasya-turkey-picture-id618872404?s=612x612',
        desc: `Kral Kaya Mezarları, Helenistik dönem'nde, Amasya'daki Harşena Dağı'nın güney eteklerindeki kalker kayalara oyulmuş olan anıt mezarlardır.`,
      },
      
      
    
  ];
  export default menu;