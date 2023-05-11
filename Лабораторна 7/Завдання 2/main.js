const number1 = Math.floor(Math.random() * 10) + 1; // генеруємо перше число
const number2 = Math.floor(Math.random() * 10) + 1; // генеруємо друге число
const sum = number1 + number2; // знаходимо їхню суму

document.getElementById("number1").textContent = number1; // виводимо перше 
document.getElementById("number2").textContent = number2; // виводимо друге 



function checkSum() {
  const userInput = Number(document.getElementById("userInput").value); // отримуємо значення 
  const result = document.getElementById("result"); // елемент де буде виводитись результат

  if (userInput === sum) { // перевіряємо 
    result.textContent = "Ок"; // виводимо 
  } else {
    result.textContent = "Не вірно. Спробуйте ще раз."; 
  }
}