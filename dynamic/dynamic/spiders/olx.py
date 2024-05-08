import csv
import scrapy
from scrapy import Spider
from dynamic.dynamic.SeleniumRequest import SeleniumRequest
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC


class OLXSpider(Spider):
    name = "olx_powerbank"
    start_urls = ["https://www.olx.ua/uk/list/q-PowerBank/"]

    def start_requests(self):
        for url in self.start_urls:
            yield SeleniumRequest(
                url=url,
                callback=self.parse,
                wait_time=10,
                wait_until=EC.visibility_of_element_located(
                    (By.CSS_SELECTOR, 'a.css-z3gu2d')
                )
            )

    def parse(self, response):
        driver = response.meta['driver']


        ad_elements = driver.find_elements(By.CLASS_NAME, "css-z3gu2d")


        with open('olx_powerbank.csv', 'w', encoding='utf-8', newline='') as csvfile:
            fieldnames = ['Назва оголошення', 'Ціна', 'Місце', 'Дата']
            writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
            writer.writeheader()


            for ad_element in ad_elements:

                title = ad_element.find_element(By.CLASS_NAME, "css-16v5mdi").text
                price = ad_element.find_element(By.CSS_SELECTOR, "p[data-testid='ad-price']").text
                location_date = ad_element.find_element(By.CSS_SELECTOR, "p[data-testid='location-date']").text
                location, date = location_date.split(' - ')


                writer.writerow({'Назва оголошення': title, 'Ціна': price, 'Місце': location, 'Дата': date})

                # Виводимо дані у консоль
                print("Назва оголошення:", title)
                print("Ціна:", price)
                print("Місце:", location)
                print("Дата:", date)
                print()
