const currencyTable = document.getElementById('currencyTable');

    async function getCurrencyRates() {
      let response = await fetch('https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json');
      let data = await response.json();

      return data.reduce((rates, item) => {
        rates[item.cc] = {
          rate: item.rate
        };
        return rates;
      }, {});
    }

    function updateCurrencyTable(rates) {
      let tbody = currencyTable.querySelector('tbody');
      tbody.innerHTML = '';

      for (const currency in rates) {
        let row = document.createElement('tr');
        row.innerHTML = `<td>${currency}</td><td>${rates[currency].rate}</td>`;
        tbody.appendChild(row);
      }
    }

    (async () => {
      try {
        let rates = await getCurrencyRates();
        updateCurrencyTable(rates);
      } catch (error) {
        console.log(error);
      }
    })();