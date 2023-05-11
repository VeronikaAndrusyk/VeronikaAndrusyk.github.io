

  function findRegion() {
    const carNumber = document.getElementById("carNumber").value;
    const regionCode = carNumber.substring(0, 2);
    let regionName = " ";
    
    switch (regionCode[0] + regionCode[1]) {
      case "AO"||'KO' :
        regionName = "Закарпатська область";
        break;
      case "BC"|| "HC":
        regionName = "Львівська область";
        break;
      case "AT" || "KT":
        regionName = "Івано-Франківська область";
        break;
      case "CE" || "IE":
        regionName = "Чернівецька область";
        break;
      case "BO" || "HO":
        regionName = "Тернопільська область";
        break;
      case "AC" || "KC":
        regionName = "Волинська область";
        break;
      case "BK" || "HK":
        regionName = "Рівненська область";
        break;
      case "AM" || "KM":
        regionName = "Житомирська область";
        break;
      case "AA" || "KA" || "AI" || "KI":
        regionName = "Київська область";
        break;
      case "CB" || "IB":
        regionName = "Чернігівська область";
        break;
      case "BM" || "HM":
        regionName = "Сумська область";
        break;
      case "AX" || "KX":
        regionName = "Харківська область";
        break;
      case "BB" || "HB":
        regionName = "Луганська область";
        break;
      case "AH" || "KH":
        regionName = "Донецька область";
        break;
      case "BI" || "HI":
        regionName = "Полтавська область";
        break;
      case "CA" || "IA":
        regionName = "Черкаська область";
        break;
      case "AE" || "KE":
        regionName = "Дніпровська область";
        break;
      case "BT" || "HT":
        regionName = "Херсонська область";
        break;
      case "AK" || "KK":
        regionName = "АТ Крим";
        break;
      case "BA" || "HA":
        regionName = "Кіровоградська область";
        break;
      case "BE" || "HE":
        regionName = "Миколаївська область";
        break;
      case "BH" || "HH":
        regionName = "Одеська обаласть";
        break;
      case "AB" || "KB":
        regionName = "Вінницька область";
        break;
      case "BX" || "HX":
        regionName = "Житомирська область";
        break;

      default:
        regionName = "Область не знайдена";
    }
    
    alert(`Автомобіль зареєстровано в ${regionName}`);
  }
