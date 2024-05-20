from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import csv

# ініціалізую драйвер
driver = webdriver.Chrome()

url = 'https://www.olx.ua/uk/elektronika/telefony-i-aksesuary/q-%D1%81%D0%BC%D0%B0%D1%80%D1%82%D1%84%D0%BE%D0%BD%D0%B8/?currency=UAH'
driver.get(url)


wait = WebDriverWait(driver, 10)
wait.until(EC.presence_of_all_elements_located((By.CLASS_NAME, 'css-1sw7q4x')))

def extract_smartphone_data(container):
    try:
        title_element = container.find_element(By.CLASS_NAME, 'css-16v5mdi')
        title = title_element.text
    except:
        title = 'N/A'
    try:
        price_element = container.find_element(By.CSS_SELECTOR, '[data-testid="ad-price"]')
        price = price_element.text
    except:
        price = 'N/A'
    try:
        location_date_element = container.find_element(By.CSS_SELECTOR, '[data-testid="location-date"]')
        location_date_text = location_date_element.text
        location, date = location_date_text.split(' - ')
    except:
        location = 'N/A'
        date = 'N/A'

    data = {
        'Title': title,
        'Price': price,
        'Location': location,
        'Date': date
    }
    return data


smartphone_containers = driver.find_elements(By.CLASS_NAME, 'css-1sw7q4x')
all_smartphone_data = []
for container in smartphone_containers:
    smartphone_data = extract_smartphone_data(container)
    all_smartphone_data.append(smartphone_data)

# закриваю драйвер
driver.quit()

# зберігаю і перевіряю дані і якщо NA то дані не записую
csv_file = 'smartphone_offers.csv'
with open(csv_file, 'w', newline='', encoding='utf-8') as file:
    writer = csv.DictWriter(file, fieldnames=['Title', 'Price', 'Location', 'Date'])
    writer.writeheader()
    for data_row in all_smartphone_data:
        if all(value != 'N/A' for value in data_row.values()):
            writer.writerow(data_row)

print("Data saved to", csv_file)